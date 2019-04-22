using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace NSMPT.Facade
{
    public class SendFacade
    {
        /// <summary>
       /// 向用户发送邮件
       /// </summary>
       /// <param name="ReceiveUser">接收邮件的用户</param>
       /// <param name="SendUser">发送者显求的邮箱地址,可为空</param>
       /// <param name="DisplayName">收件人显示发件人的联系人名，可为中文</param>
       /// <param name="SendUserName">发送者的邮箱登陆名，可以与发送者地址一样</param>
       /// <param name="UserPassword">发送者的登陆密码</param>
       /// <param name="MailTitle">发送标题</param>
       /// <param name="MailContent">发送的内容</param>
        public bool SingleSend(string ReceiveUser, string DisplayName, string SendUser, string SendUserName, string Username,string UserPassword, string MailTitle, string MailContent,string Domain)
        {

            try
            {

            ISmtpMail smtp = new SmtpMail();

            smtp.AddRecipient(ReceiveUser);

            smtp.MailDomain = Domain;
            smtp.Html = true;
            smtp.From = SendUser;
            smtp.FromName = SendUserName;
            smtp.RecipientName = DisplayName;
            smtp.MailDomainPort = 25;
            smtp.Subject = MailTitle;
            smtp.Body = MailContent;

            smtp.MailServerUserName = Username;
            smtp.MailServerPassWord = UserPassword;


             return smtp.Send();

            }
            catch (Exception)
            {

                return false;
            }


         
        }
    }
}
