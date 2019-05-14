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
    public class TimerSendFacade : FacadeBase
    {
        public bool Send()
        {


            Log.Info("=====开始发送定时邮件=====");
            DataAccess.Tnsmtp_EmailCollection tnsmtp_EmailCollection = new DataAccess.Tnsmtp_EmailCollection();


            if (!tnsmtp_EmailCollection.ListSendByFlagStatus((int)EmailFlagStatus.定时邮件))
            {
                Log.Info("查询定时邮件失败");
                Alert("查询定时邮件失败！");
                return false;
            }

            if (tnsmtp_EmailCollection.DataTable.Rows.Count == 0)
            {
                Log.Info("没有定时邮件");
                Alert("没有定时邮件");
                return true;
            }

            foreach (DataRow dr in tnsmtp_EmailCollection.DataTable.Rows)
            {
                DateTime sendtime = new DateTime();
                if (!DateTime.TryParse(dr[Tnsmtp_Email._SENDDATE].ToString(), out sendtime))
                {
                    Log.Info("发送时间为空");
                    continue;
                }

                int mailid = int.Parse(dr[Tnsmtp_Email._MAIL_ID].ToString());

                if (sendtime < DateTime.Now)
                {
                    continue;
                }


                DataAccess.Tnsmtp_Email tnsmtp_Email = new Tnsmtp_Email();

                if (!SendEmail(dr))
                {
                    continue;
                }

                if (!tnsmtp_Email.SelectByPK(mailid))
                {
                    Log.Info("异常，邮件不存在！");
                    Alert("邮件不存在");
                    return false;
                }

                tnsmtp_Email.FlagStatus = (int)EmailFlagStatus.已发送;

                if (!tnsmtp_Email.Update())
                {
                    Log.Info("修改发送状态失败");
                    Alert("修改发送状态失败!");
                    return false;
                }
                


            }

            Log.Info("=====结束发送定时邮件=====");
            return true;


        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool SendEmail(DataRow dr)
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
            if (!tnsmtp_Mailtype.SelectByPK(mailid))
            {

                Alert("获取企业邮箱失败");
                return false;
            }
            #endregion

            #region 获取附件信息
            Dictionary<string, string> filelist = new Dictionary<string, string>();

            if (!GetAttchment(mailid, userid, out filelist))
            {
                Alert("获取附件失败");
                return false;
            }
            #endregion

            SendFacade sendFacade = new SendFacade();

            #region 增加回执


            content = sendFacade.SetReceipt(content, mailid);

            #endregion

            #region 判断是否有抄送或者密送


            List<string> Bcc = new List<string>();
            List<string> Wcc = new List<string>();


            if (!sendFacade.GetCCArray(bccstr, out Bcc))
            {
                Log.Info("密送联系人地址有误！");
                Alert("密送联系人地址有误");

                return false;
            }


            if (!sendFacade.GetCCArray(wccstr, out Wcc))
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
                smtp.MailDomainPort = tnsmtp_Mailtype.SmtpSsl.Value;
                smtp.Subject = subject;
                smtp.Body = content;
                smtp.AttachmentFile = filelist;

                smtp.MailServerUserName = tnsmtp_Account.Account;
                smtp.MailServerPassWord = tnsmtp_Account.Password;

                smtp.RecipientBCC1 = Bcc;
                smtp.RecipientWCC1 = Wcc;



                if (!smtp.Send())
                {
                    Rollback();
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


        /// <summary>
        /// 获取附件
        /// </summary>
        /// <param name="mailid"></param>
        /// <param name="userid"></param>
        /// <param name="filelist"></param>
        /// <returns></returns>
        public bool GetAttchment(int mailid, int userid, out Dictionary<string, string> filelist)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            DataAccess.Tnsmtp_AttachmentCollection tnsmtp_AttachmentCollection = new Tnsmtp_AttachmentCollection();
            if (!tnsmtp_AttachmentCollection.ListByMailId(mailid, userid))
            {
                Log.Info("查询附件信息出错！");
                Alert("查询附件信息错误");
                filelist = list;
                return false;
            }

            if (tnsmtp_AttachmentCollection.DataTable.Rows.Count <= 0)
            {
                filelist = list;
                return true;
            }

            foreach (DataRow dr in tnsmtp_AttachmentCollection.DataTable.Rows)
            {

                list.Add(dr[Tnsmtp_Attachment._FILE_NAME].ToString(), dr[Tnsmtp_Attachment._FILE_URL].ToString());

            }
            filelist = list;
            return true;

        }

    }
}
