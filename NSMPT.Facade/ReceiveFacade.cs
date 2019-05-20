using MimeKit;
using NSMPT.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;

namespace NSMPT.Facade
{
    public class ReceiveFacade : FacadeBase
    {



        public bool GetAccountEmail(int accountId)
        {

            DateTime? beforeDate = null;

            DataAccess.Tnsmtp_Account tnsmtp_Account = new DataAccess.Tnsmtp_Account();

            if (!tnsmtp_Account.SelectByPK(accountId))
            {
                Log.Info("获取邮件账户信息错误");
                return false;
            }

            Tnsmtp_Mailtype tnsmtp_Mailtype = new Tnsmtp_Mailtype();
            if (!tnsmtp_Mailtype.SelectByPK(tnsmtp_Account.MailType))
            {
                Alert("获取邮件配置失败！");
                return false;
            }

            Tnsmtp_Recmail tnsmtp_Recmail = new Tnsmtp_Recmail();

            if (tnsmtp_Recmail.SelectMaxRecEmail(accountId, tnsmtp_Account.Userid))
            {
                beforeDate = tnsmtp_Recmail.Rectimer;
            }
            List<MimeKit.MimeMessage> messages = new List<MimeKit.MimeMessage>();

            ImapEmail imap = new ImapEmail();

            if (!imap.KitEmailHelper(tnsmtp_Mailtype.PopUrl, tnsmtp_Mailtype.PopPort, tnsmtp_Account.Account, tnsmtp_Account.Password, beforeDate, out messages))
            {
                Alert("获取邮件失败！");
                return false;
            }

            if (messages.Count <= 0)
            {
                Alert("没有信息的邮件！");
                return true;
            }


            foreach (MimeMessage item in messages)
            {
                if (!InserRecTable(item, tnsmtp_Account))
                {
                    Log.Info("添加收件箱失败");
                    Alert("获取邮件失败！");
                    return false;
                }
            }

            return true;

        }


        private bool InserRecTable(MimeMessage message, Tnsmtp_Account tnsmtp_Account)
        {
            BeginTransaction();

            DataAccess.Tnsmtp_Recmail tnsmtp_Recmail = new Tnsmtp_Recmail();
            tnsmtp_Recmail.ReferenceTransactionFrom(this.Transaction);
            tnsmtp_Recmail.Userid = tnsmtp_Account.Userid;
            tnsmtp_Recmail.AccountId = tnsmtp_Account.Aid;
            tnsmtp_Recmail.Content = message.HtmlBody;
            tnsmtp_Recmail.Rectimer = message.Date.DateTime;
            tnsmtp_Recmail.Euid = message.MessageId;
            tnsmtp_Recmail.Subject = message.Subject;
            tnsmtp_Recmail.Hasfile = message.Attachments.Any() ? 1 : 0;
            tnsmtp_Recmail.ReciverMail = tnsmtp_Account.Account;
            tnsmtp_Recmail.ReciverName = tnsmtp_Account.Account;
            tnsmtp_Recmail.SenderName = message.From.ToList()[0].Name;
            tnsmtp_Recmail.SenderMail = message.From.Mailboxes.ToList()[0].Address;

            if (!tnsmtp_Recmail.Insert())
            {
                Log.Info("获取邮件后添加数据库失败！" + message.MessageId);
                Alert("获取邮件后添加数据库失败！" + message.MessageId);

                Rollback();
                return false;
            }



            if (message.Attachments.Any())
            {
                foreach (MimeEntity item in message.Attachments)
                {
                    if (!InsertAttTable(item, tnsmtp_Account, tnsmtp_Recmail))
                    {
                        Log.Info("获取邮件后添加附件失败！");
                        Alert("获取邮件后添加附件失败！");
                        Rollback();
                        return false;
                    }
                }
            }



            Commit();
            return true;

        }


        private bool InsertAttTable(MimeEntity entity, Tnsmtp_Account tnsmtp_Account, Tnsmtp_Recmail tnsmtp_Recmail)
        {
            DataAccess.Tnsmtp_Receivefile tnsmtp_Receivefile = new Tnsmtp_Receivefile();

            tnsmtp_Receivefile.ReferenceTransactionFrom(this.Transaction);

            tnsmtp_Receivefile.RecMailid = tnsmtp_Recmail.Recid;
            tnsmtp_Receivefile.Userid = tnsmtp_Recmail.Recid;
            tnsmtp_Receivefile.Accountid = tnsmtp_Account.Aid;
            tnsmtp_Receivefile.Fileurl = entity.ContentDisposition.FileName;
            tnsmtp_Receivefile.Filename = entity.ContentDisposition.FileName;
            tnsmtp_Receivefile.Downloadurl = entity.ContentDisposition.FileName;
            tnsmtp_Receivefile.Filesize = 0;

            if (!tnsmtp_Receivefile.Insert())
            {
                Alert("添加附件信息失败" );
                return false;

            }

            return true;
        }

    }
}
