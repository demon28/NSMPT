using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using NSMPT.Entites;
using Winner.Framework.Core.Facade;

namespace NSMPT.Facade
{
    public class SendFacade : FacadeBase
    {
        /// <summary>
        /// 向用户发送普通邮件
        /// </summary>
        public bool SingleSend(Tnsmtp_EmailMap model, int userid)
        {
            try
            {
                //获取发件账户信息
                DataAccess.Tnsmtp_Account tnsmtp_Account = new DataAccess.Tnsmtp_Account();
                if (!tnsmtp_Account.SelectByPK(model.AccountId))
                {
                    Alert("获取发件账户失败");
                    return false;
                }
                //获取企业邮箱信息
                DataAccess.Tnsmtp_Mailtype tnsmtp_Mailtype = new DataAccess.Tnsmtp_Mailtype();
                if (!tnsmtp_Mailtype.SelectByPK(tnsmtp_Account.MailType.Value))
                {
                    Alert("获取企业邮箱失败");
                    return false;
                }
                //判断收件人是否存在，不存在则添加
                DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
                if (!tnsmtp_Contact.SelectByUserId(userid,model.RecId.Value))
                {
                    //TODO:添加收件人为联系人
                    tnsmtp_Contact.Status = 0;
                }



                DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();
                tnsmtp_Email.Bcc = model.Bcc;
                tnsmtp_Email.AccountId = model.AccountId;
                tnsmtp_Email.Userid = userid;
                tnsmtp_Email.Content = model.Content;
                tnsmtp_Email.Tomail = model.Tomail;
                tnsmtp_Email.Inmail = model.Inmail;
                tnsmtp_Email.Subject = model.Subject;
                tnsmtp_Email.Wcc = model.Wcc;
                tnsmtp_Email.Status = 1;


                if (!tnsmtp_Email.Insert())
                {
                    Alert("添加邮件失败");
                    return false;
                }


                ISmtpMail smtp = new SmtpMail();
                smtp.AddRecipient(model.Inmail);

                smtp.MailDomain = tnsmtp_Mailtype.SmtpUrl;
                smtp.Html = true;
                smtp.From = model.Tomail;
                smtp.FromName = model.Tomail;
                smtp.RecipientName = model.Inmail;
                smtp.MailDomainPort = tnsmtp_Mailtype.SmtpPort.Value;
                smtp.Subject = model.Subject;
                smtp.Body = model.Content;

                smtp.MailServerUserName = tnsmtp_Account.Account;
                smtp.MailServerPassWord = tnsmtp_Account.Password;


                if (!smtp.Send())
                {
                    Alert("发送邮件失败！");
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
                MarkKey markKey = (MarkKey)tnsmtp_Raplcemark.DataTable.Rows[i]["rid"];
                string markvalue = tnsmtp_Raplcemark.DataTable.Rows[i]["rid"].ToString();

                switch (markKey)
                {
                    case MarkKey.收件人名称:

                        ReplacceContactName(model, markvalue, out value);

                        break;
                    case MarkKey.收件人邮箱:
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
        public bool ReplacceContactName(Tnsmtp_EmailMap model,string mark,out string replace) {

           
            if (!model.Content.Contains(mark))
            {
                replace = model.Content;
                return false;
            }

            replace= model.Content.Replace(mark, model.Inmail);
            return true;

        }

        /// <summary>
        /// 系统标签替换收件人邮箱
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mark"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public bool ReplacceContactEmail(Tnsmtp_EmailMap model, string mark, out string replace)
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
