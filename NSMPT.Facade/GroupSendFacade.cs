using NSMPT.DataAccess;
using NSMPT.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;

namespace NSMPT.Facade
{
   public class GroupSendFacade : FacadeBase
    {

        /// <summary>
        /// 群发邮件====让服务即时去跑
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Gid"></param>
        /// <returns></returns>
        public bool GroupSend(Tnsmtp_EmailMap model, int Gid)
        {

            BeginTransaction();

            #region 获取发件账户信息
            DataAccess.Tnsmtp_Account tnsmtp_Account = new DataAccess.Tnsmtp_Account();
            if (!tnsmtp_Account.SelectByPK(model.AccountId))
            {
                Rollback();
                Alert("获取发件账户失败");
                return false;
            }
            #endregion

            #region 获取企业邮箱信息
            DataAccess.Tnsmtp_Mailtype tnsmtp_Mailtype = new DataAccess.Tnsmtp_Mailtype();
            if (!tnsmtp_Mailtype.SelectByPK(tnsmtp_Account.MailType))
            {
                Rollback();
                Alert("获取企业邮箱失败");
                return false;
            }
            #endregion

            #region 如果存在模板标签则替换模板标签
            string content = string.Empty;
            ReplaceMark replace = new ReplaceMark();
            if (!replace.Replace(model, model.Userid, out content))
            {
                Rollback();
                Alert("替换模板标签失败！");
                return false;
            }

            #endregion


            DataAccess.Tnsmtp_ContactCollection tnsmtp_ContactCollection = new Tnsmtp_ContactCollection();

            if (!tnsmtp_ContactCollection.ListByUserid(model.Userid, string.Empty, Gid))
            {
                Rollback();
                Alert("查找分组联系人失败");
                return false;
            }

            foreach (DataRow dr in tnsmtp_ContactCollection.DataTable.Rows)
            {
                model.FlagStatus = (int)Entites.EmailFlagStatus.群发;
                model.Inmail = dr[Tnsmtp_Contact._EMAIL].ToString();

                if (!GroupAddEmailTable(model))
                {
                    Rollback();
                    Alert("添加邮件失败");
                    return false;
                }


                Dictionary<string, string> filelist = new Dictionary<string, string>();
                AttchmentFacade attchment = new AttchmentFacade();
                if (!attchment.AddAtthachmentTable(model, tnsmtp_Account, out filelist))
                {
                    Rollback();
                    Alert("添加附件失败！");
                    return false;
                }

            }




            Commit();
            return true;
        }


        private bool GroupAddEmailTable(Tnsmtp_EmailMap model)
        {
            DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();
            tnsmtp_Email.ReferenceTransactionFrom(this.Transaction);

            tnsmtp_Email.Bcc = model.Bcc;
            tnsmtp_Email.AccountId = model.AccountId;
            tnsmtp_Email.Userid = model.Userid;


            tnsmtp_Email.Content = model.Content;
            tnsmtp_Email.Tomail = model.Tomail;
            tnsmtp_Email.Inmail = model.Inmail;
            tnsmtp_Email.Subject = model.Subject;
            tnsmtp_Email.Wcc = model.Wcc;
            tnsmtp_Email.Status = (int)Entites.EmailFlagStatus.群发;
            tnsmtp_Email.Senddate = model.Senddate;
            tnsmtp_Email.FlagRead = 0;
            tnsmtp_Email.FlagStatus = model.FlagStatus;

            if (!tnsmtp_Email.Insert())
            {
                Alert("添加邮件失败！");
                return false;
            }


            return true;
        }


        /// <summary>
        /// 定时群发邮件====等待服务去跑
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Gid"></param>
        /// <returns></returns>
        public bool GroupTimerSend(Tnsmtp_EmailMap model, int Gid)
        {

            BeginTransaction();

            #region 获取发件账户信息
            DataAccess.Tnsmtp_Account tnsmtp_Account = new DataAccess.Tnsmtp_Account();
            if (!tnsmtp_Account.SelectByPK(model.AccountId))
            {
                Rollback();
                Alert("获取发件账户失败");
                return false;
            }
            #endregion

            #region 获取企业邮箱信息
            DataAccess.Tnsmtp_Mailtype tnsmtp_Mailtype = new DataAccess.Tnsmtp_Mailtype();
            if (!tnsmtp_Mailtype.SelectByPK(tnsmtp_Account.MailType))
            {
                Rollback();
                Alert("获取企业邮箱失败");
                return false;
            }
            #endregion

            #region 如果存在模板标签则替换模板标签
            string content = string.Empty;
            ReplaceMark replaceMark = new ReplaceMark();
            if (!replaceMark.Replace(model, model.Userid, out content))
            {
                Rollback();
                Alert("替换模板标签失败！");
                return false;
            }

            #endregion


            DataAccess.Tnsmtp_ContactCollection tnsmtp_ContactCollection = new Tnsmtp_ContactCollection();

            if (!tnsmtp_ContactCollection.ListByUserid(model.Userid, string.Empty, Gid))
            {
                Rollback();
                Alert("查找分组联系人失败");
                return false;
            }

            foreach (DataRow dr in tnsmtp_ContactCollection.DataTable.Rows)
            {
                model.FlagStatus = (int)Entites.EmailFlagStatus.定时群发;
                model.Inmail = dr[Tnsmtp_Contact._EMAIL].ToString();

                if (!GroupAddEmailTable(model))
                {
                    Rollback();
                    Alert("添加邮件失败");
                    return false;
                }


                Dictionary<string, string> filelist = new Dictionary<string, string>();
                AttchmentFacade attchment = new AttchmentFacade();
                if (!attchment.AddAtthachmentTable(model, tnsmtp_Account, out filelist))
                {
                    Rollback();
                    Alert("添加附件失败！");
                    return false;
                }

            }



            Commit();
            return true;


        }


        /// <summary>
        /// 发送邮件By DataRow 由windows服务调取发送
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public bool SendEmail(DataRow dr)
        {

            string inmail = dr[Tnsmtp_Email._INMAIL].ToString();
            string tomail = dr[Tnsmtp_Email._TOMAIL].ToString();
            string subject = dr[Tnsmtp_Email._SUBJECT].ToString();
            string content = dr[Tnsmtp_Email._CONTENT].ToString();
            int accountid = int.Parse(dr[Tnsmtp_Email._ACCOUNT_ID].ToString());
            int mailid = int.Parse(dr[Tnsmtp_Email._MAIL_ID].ToString());
            int userid = int.Parse(dr[Tnsmtp_Email._USERID].ToString());
            string bccstr = dr[Tnsmtp_Email._BCC].ToString();
            string wccstr = dr[Tnsmtp_Email._WCC].ToString();
            #region 获取发件账户信息
            DataAccess.Tnsmtp_Account tnsmtp_Account = new DataAccess.Tnsmtp_Account();
            if (!tnsmtp_Account.SelectByPK(accountid))
            {

                Alert("获取发件账户失败");
                return false;
            }
            #endregion

            #region 获取企业邮箱信息
            DataAccess.Tnsmtp_Mailtype tnsmtp_Mailtype = new DataAccess.Tnsmtp_Mailtype();
            if (!tnsmtp_Mailtype.SelectByPK(tnsmtp_Account.MailType))
            {

                Alert("获取企业邮箱失败");
                return false;
            }
            #endregion

            #region 获取附件信息
            Dictionary<string, string> filelist = new Dictionary<string, string>();
            AttchmentFacade attchment = new AttchmentFacade();
            if (!attchment.GetAttchment(mailid, userid, out filelist))
            {
                Alert("获取附件失败");
                return false;
            }
            #endregion



            #region 增加回执


            content = Receipt.SetReceipt(content, mailid);

            #endregion

            #region 判断是否有抄送或者密送


            List<string> Bcc = new List<string>();
            List<string> Wcc = new List<string>();


            if (!Entites.Tool.SplitContact.GetCCArray(bccstr, out Bcc))
            {
                Log.Info("密送联系人地址有误！");
                Alert("密送联系人地址有误");

                return false;
            }


            if (!Entites.Tool.SplitContact.GetCCArray(wccstr, out Wcc))
            {
                Log.Info("抄送联系人地址有误！");
                Alert("抄送联系人地址有误");
                return false;
            }


            #endregion

            try
            {

                SmtpMail smtp = new SmtpMail();
                smtp.AddRecipient(inmail);

                smtp.MailDomain = tnsmtp_Mailtype.SmtpUrl;
                smtp.Html = true;
                smtp.From = tomail;
                smtp.FromName = tomail;
                smtp.RecipientName = inmail;
                smtp.MailDomainPort = tnsmtp_Mailtype.SmtpSsl;
                smtp.Subject = subject;
                smtp.Body = content;
                smtp.AttachmentFile = filelist;

                smtp.MailServerUserName = tnsmtp_Account.Account;
                smtp.MailServerPassWord = tnsmtp_Account.Password;

                smtp.RecipientBCC1 = Bcc;
                smtp.RecipientWCC1 = Wcc;



                if (!smtp.Send())
                {
                    Alert(smtp.PromptInfo.Message);
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {

                Alert(e.Message);
                return false;
            }



        }

    }
}
