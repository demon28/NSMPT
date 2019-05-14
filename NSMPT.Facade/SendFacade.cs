using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using NSMPT.Entites;
using Winner.Framework.Core.Facade;
using System.IO;
using System.Web;
using System.Collections;
using NSMPT.DataAccess;

namespace NSMPT.Facade
{
    public class SendFacade : FacadeBase
    {
        /// <summary>
        /// 向用户发送普通邮件
        /// </summary>
        public bool SingleSend(Tnsmtp_EmailMap model)
        {
            BeginTransaction();

            #region 前期准备工作

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
            if (!tnsmtp_Mailtype.SelectByPK(tnsmtp_Account.MailType.Value))
            {
                Rollback();
                Alert("获取企业邮箱失败");
                return false;
            }
            #endregion

            #region 判断收件人是否存在常用联系人，不存在则添加
            if (!AddContactTable(model))
            {
                Rollback();
                return false;
            }

            #endregion

            #region 如果存在模板标签则替换模板标签
            string content=string.Empty;
            if (!ReplaceMark(model, model.Userid, out content))
            {
                Rollback();
                Alert("替换模板标签失败！");
                return false;
            }

            #endregion

            #region 添加数据库 邮件表
         
            model.Senddate = DateTime.Now;
            if (!AddEmailTable(model))
            {
                Rollback();
                Alert("添加邮件失败");
                return false;
            }
         
            #endregion

            #region 如果有附件，则添加附件到数据库
            Dictionary<string, string> filelist = new Dictionary<string, string>();
            if (!AddAtthachmentTable(model, tnsmtp_Account, out filelist))
            {
                Rollback();
                Alert("添加附件失败！");
                return false;
            }

            #endregion

            #region 判断是否有抄送或者密送


            List<string> Bcc = new List<string>();
            List<string> Wcc = new List<string>();


            if (!GetCCArray(model.Bcc, out Bcc))
            {
                Alert("密送联系人地址有误");
                Rollback();
                return false;
            }


            if (!GetCCArray(model.Wcc, out Wcc))
            {
                Alert("抄送联系人地址有误");
                Rollback();
                return false;
            }


            #endregion


            #endregion

            try
            {

                #region 调用SMTP 发送邮件
                SmtpMail smtp = new SmtpMail();
                smtp.AddRecipient(model.Inmail);

                smtp.MailDomain = tnsmtp_Mailtype.SmtpUrl;
                smtp.Html = true;
                smtp.From = model.Tomail;
                smtp.FromName = model.Tomail;
                smtp.RecipientName = model.Inmail;
                smtp.MailDomainPort = tnsmtp_Mailtype.SmtpSsl.Value;
                smtp.Subject = model.Subject;
                smtp.Body = model.Content;
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

                #endregion


            }
            catch (Exception e)
            {
                Rollback();
                Alert(e.Message);
                return false;
            }

            Commit();
            return true;
        }


        /// <summary>
        /// 定时发送===等待服务去跑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool TimerSend(Tnsmtp_EmailMap model)
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
            if (!tnsmtp_Mailtype.SelectByPK(tnsmtp_Account.MailType.Value))
            {
                Rollback();
                Alert("获取企业邮箱失败");
                return false;
            }
            #endregion

            #region 判断收件人是否存在常用联系人，不存在则添加
            if (!AddContactTable(model))
            {
                Rollback();
                return false;
            }

            #endregion

            #region 如果存在模板标签则替换模板标签
            string content = string.Empty;
            if (!ReplaceMark(model, model.Userid, out content))
            {
                Rollback();
                Alert("替换模板标签失败！");
                return false;
            }

            #endregion

            #region 添加数据库 邮件表

            model.FlagStatus = 3;

            if (!AddEmailTable(model))
            {
                Rollback();
                Alert("添加邮件失败");
                return false;
            }
            
            #endregion

            #region 如果有附件，则添加附件到数据库
            Dictionary<string, string> filelist = new Dictionary<string, string>();
            if (!AddAtthachmentTable(model, tnsmtp_Account, out filelist))
            {
                Rollback();
                Alert("添加附件失败！");
                return false;
            }

            #endregion


            Commit();
            return true;
        }


        /// <summary>
        /// 标签替换
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userid"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public bool ReplaceMark(Tnsmtp_EmailMap model, int userid, out string replace)
        {

            string value = string.Empty;

            DataAccess.Tnsmtp_RaplcemarkCollection tnsmtp_Raplcemark = new DataAccess.Tnsmtp_RaplcemarkCollection();

            if (!tnsmtp_Raplcemark.ListByUser(userid))
            {
                replace = model.Content;
                Alert("获取模板信息失败！");
                return false;
            }


            for (int i = 0; i < tnsmtp_Raplcemark.DataTable.Rows.Count; i++)
            {
                MarkKey markKey = (MarkKey)int.Parse(tnsmtp_Raplcemark.DataTable.Rows[i]["rid"].ToString());
                string markvalue = tnsmtp_Raplcemark.DataTable.Rows[i]["mark_value"].ToString();

                switch (markKey)
                {
                    case MarkKey.收件人名称:

                        ReplacceContactName(model, markvalue, out value);
                        model.Content = value;
                        break;
                    case MarkKey.收件人邮箱:
                        ReplacceContactEmailSingle(model, markvalue, out value);
                        model.Content = value;
                        break;
                    case MarkKey.收件人电话:
                        break;
                }


            }
            replace = value;

            return true;

        }

        /// <summary>
        /// 系统标签替换收件人姓名
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mark"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        private bool ReplacceContactName(Tnsmtp_EmailMap model, string mark, out string replace)
        {


            if (!model.Content.Contains(mark))
            {
                replace = model.Content;
                return false;
            }

            replace = model.Content.Replace(mark, model.Inmail);
            return true;

        }

        /// <summary>
        /// 系统标签替换收件人邮箱(普通邮件)，没有收件人名字
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mark"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        private bool ReplacceContactEmailSingle(Tnsmtp_EmailMap model, string mark, out string replace)
        {

            if (!model.Content.Contains(mark))
            {
                replace = model.Content;
                return false;
            }
          
            replace = model.Content.Replace(mark, model.Inmail);
            return true;

        }

        /// <summary>
        /// 以分号分割抄送人和密送人
        /// </summary>
        /// <param name="str"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool GetCCArray(string str, out List<string> list)
        {
            list = new List<string>();

            if (string.IsNullOrEmpty(str))
            {
                return true;
            }

            if (str.Contains(';'))
            {
                string[] CCList = str.Split(';');

                foreach (var item in CCList)
                {
                    if (!item.Contains('@'))
                    {
                        return false;
                    }
                    list.Add(item);
                }
            }
            else
            {
                if (!str.Contains('@'))
                {
                    return false;
                }
                list.Add(str);
            }

            return true;
        }

        /// <summary>
        /// 添加回执功能
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public string SetReceipt(string context, int mid)
        {

            string src = Entites.Tool.GetUrl.GetSiteUrl() + "/SendEmail/Receipt?mid=" + mid;

            string img = "<img src='" + src + "' alt='' style='display: inline - block; width: 0; height: 0' />";


            return context += "<br/><br/><br/>" + img;

        }

        /// <summary>
        /// 添加邮件表数据
        /// </summary>
        /// <returns></returns>
        private bool AddEmailTable(Tnsmtp_EmailMap model)
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
            tnsmtp_Email.Status = 1;
            tnsmtp_Email.Senddate = model.Senddate;
            tnsmtp_Email.FlagRead = 0;
            tnsmtp_Email.FlagStatus = model.FlagStatus;

            if (!tnsmtp_Email.Insert())
            {
                Alert("添加邮件失败！");
                return false;
            }



            model.MailId = tnsmtp_Email.MailId;
            model.Content = SetReceipt(model.Content, tnsmtp_Email.MailId);  //加入回执功能
            return true;
        }


        /// <summary>
        /// 添加附件表数据
        /// </summary>
        /// <returns></returns>
        private bool AddAtthachmentTable(Tnsmtp_EmailMap model, Tnsmtp_Account tnsmtp_Account, out Dictionary<string, string> filelist)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (model.Atthachment == null && model.Atthachment.Length <= 0)
            {
                filelist = dic;
                return true;
            }


            foreach (var file in model.Atthachment)
            {
                DataAccess.Tnsmtp_Attachment tnsmtp_Attachment = new DataAccess.Tnsmtp_Attachment();
                tnsmtp_Attachment.ReferenceTransactionFrom(this.Transaction);

                tnsmtp_Attachment.AccountId = tnsmtp_Account.Aid;
                tnsmtp_Attachment.FileUrl = file;
                tnsmtp_Attachment.FileName = Path.GetFileName(file);
                tnsmtp_Attachment.MailId = model.MailId;
                tnsmtp_Attachment.Status = 0;
                tnsmtp_Attachment.UserId = model.Userid;

                if (!tnsmtp_Attachment.Insert())
                {
                    filelist = dic;
                    return false;
                }

                string path = HttpContext.Current.Server.MapPath("~/File/UserFile/" + model.Userid + "/Attachment/" + tnsmtp_Attachment.FileName);

                dic.Add(tnsmtp_Attachment.FileName, path);
            }
            filelist = dic;
            return true;

        }

        /// <summary>
        /// 添加联系人表数据
        /// </summary>
        /// <returns></returns>
        private bool AddContactTable(Tnsmtp_EmailMap model)
        {
            DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
            tnsmtp_Contact.ReferenceTransactionFrom(this.Transaction);
            if (tnsmtp_Contact.SelectByEmail(model.Userid, model.Inmail))
            {
                model.RecId = tnsmtp_Contact.ContactId;
            }


            if (!model.RecId.HasValue)
            {

                #region 如果用户没有 "常用联系人" 这个组则添加这个组


                DataAccess.Tnsmtp_Contactgroup tnsmtp_Contactgroup = new DataAccess.Tnsmtp_Contactgroup();
                tnsmtp_Contactgroup.ReferenceTransactionFrom(this.Transaction);
                if (!tnsmtp_Contactgroup.SelectByGroupName(model.Userid, "常用联系人"))
                {

                    tnsmtp_Contactgroup.Groupname = "常用联系人";
                    tnsmtp_Contactgroup.Userid = model.Userid;
                    tnsmtp_Contactgroup.Status = 0;
                    if (!tnsmtp_Contactgroup.Insert())
                    {
                        Alert("添加常用联系人分组失败");
                        return false;
                    }

                }


                #endregion


                #region 添加联系人

                tnsmtp_Contact.ContactName = model.Inmail;
                tnsmtp_Contact.Email = model.Inmail;
                tnsmtp_Contact.Gid = tnsmtp_Contactgroup.Gid;
                tnsmtp_Contact.Status = 0;
                tnsmtp_Contact.UserId = model.Userid;
                tnsmtp_Contact.CateId = 1;

                if (!tnsmtp_Contact.Insert())
                {
                    Alert("添加常用联系人失败");
                    return false;
                }
                #endregion

            }

            return true;

        }
    }
}
