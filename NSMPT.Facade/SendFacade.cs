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

namespace NSMPT.Facade
{
    public class SendFacade : FacadeBase
    {
        /// <summary>
        /// 向用户发送普通邮件
        /// </summary>
        public bool SingleSend(Tnsmtp_EmailMap model)
        {
           
                string content = string.Empty;

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
                DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
                tnsmtp_Contact.ReferenceTransactionFrom(this.Transaction);
                if (tnsmtp_Contact.SelectByEmail(model.Userid,model.Inmail))
                {
                    model.RecId = tnsmtp_Contact.ContactId;
                }

               
                if (!model.RecId.HasValue)
                {
                    //TODO:添加收件人为联系人
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
                            Rollback();
                            Alert("添加常用联系人分组失败");
                            return false;
                        }

                    }


                    #endregion


                    #region 添加联系人
                   
                    tnsmtp_Contact.ContactName = model.Inmail;
                    tnsmtp_Contact.Email= model.Inmail;
                    tnsmtp_Contact.Gid = tnsmtp_Contactgroup.Gid;
                    tnsmtp_Contact.Status = 0;
                    tnsmtp_Contact.UserId = model.Userid;
                    tnsmtp_Contact.CateId = 1;
                    if (!tnsmtp_Contact.Insert())
                    {
                        Rollback();
                        Alert("添加常用联系人失败");
                        return false;
                    }
                    #endregion

                }
                #endregion

                #region 如果存在模板标签则替换模板标签
                if (!ReplaceMark(model, model.Userid, out content))
                {
                    Rollback();
                    Alert("替换模板标签失败！");
                    return false;
                }
                #endregion


                #region 添加数据库 邮件表
                DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();
                tnsmtp_Email.ReferenceTransactionFrom(this.Transaction);

                tnsmtp_Email.Bcc = model.Bcc;
                tnsmtp_Email.AccountId = model.AccountId;
                tnsmtp_Email.Userid = model.Userid;
                tnsmtp_Email.Content = content;
                tnsmtp_Email.Tomail = model.Tomail;
                tnsmtp_Email.Inmail = model.Inmail;
                tnsmtp_Email.Subject = model.Subject;
                tnsmtp_Email.Wcc = model.Wcc;
                tnsmtp_Email.Status = 1;
                tnsmtp_Email.Senddate = DateTime.Now;


                if (!tnsmtp_Email.Insert())
                {
                    Rollback();
                    Alert("添加邮件失败");
                    return false;
                }

                #endregion

                #region 如果有附件，则添加附件到数据库

                Dictionary<string, string> dic = new Dictionary<string, string>();

                if (model.Atthachment.Length > 0)
                {
                    foreach (var file in model.Atthachment)
                    {
                        DataAccess.Tnsmtp_Attachment tnsmtp_Attachment = new DataAccess.Tnsmtp_Attachment();
                        tnsmtp_Attachment.ReferenceTransactionFrom(this.Transaction);

                        tnsmtp_Attachment.AccountId = tnsmtp_Account.Aid;
                        tnsmtp_Attachment.FileUrl = file;
                        tnsmtp_Attachment.FileName = Path.GetFileName(file);
                        tnsmtp_Attachment.MailId = tnsmtp_Email.MailId;
                        tnsmtp_Attachment.Status = 0;
                        tnsmtp_Attachment.UserId = model.Userid;

                        if (!tnsmtp_Attachment.Insert())
                        {
                            Rollback();
                            Alert("添加附件失败！");
                            return false;
                        }
                        dic.Add(tnsmtp_Attachment.FileName, tnsmtp_Attachment.FileUrl);
                    }

                }


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
                smtp.AttachmentFile = dic;

                smtp.MailServerUserName = tnsmtp_Account.Account;
                smtp.MailServerPassWord = tnsmtp_Account.Password;

                string message = string.Empty;

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


        public bool ReplaceMark(Tnsmtp_EmailMap model,int userid ,out string replace) {

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
                MarkKey markKey = (MarkKey) int.Parse(tnsmtp_Raplcemark.DataTable.Rows[i]["rid"].ToString());
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
        private bool ReplacceContactName(Tnsmtp_EmailMap model,string mark,out string replace) {

           
            if (!model.Content.Contains(mark))
            {
                replace = model.Content;
                return false;
            }

            replace= model.Content.Replace(mark, model.Inmail);
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
            //TODO:没有收件人姓名
            replace = model.Content.Replace(mark, model.Inmail);
            return true;

        }


    }
}
