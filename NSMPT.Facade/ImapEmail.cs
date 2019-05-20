using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
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
    public class ImapEmail : FacadeBase
    {
        [Obsolete]
        public bool GetMail(int AccountId, int userid)
        {


            Tnsmtp_Account tnsmtp_Account = new Tnsmtp_Account();


            if (!tnsmtp_Account.SelectByPK(AccountId))
            {
                Alert("获取账户信息失败！");
                return false;
            }

            Tnsmtp_Mailtype tnsmtp_Mailtype = new Tnsmtp_Mailtype();
            if (!tnsmtp_Mailtype.SelectByPK(tnsmtp_Account.MailType))
            {
                Alert("获取邮件配置失败！");
                return false;
            }


            ImapClient client = new ImapClient();
            client.Connect(tnsmtp_Mailtype.PopUrl,tnsmtp_Mailtype.PopPort, true);

            client.Authenticate(tnsmtp_Account.Account, tnsmtp_Account.Password);

            //获取所有的文件夹
            List<IMailFolder> mailFolderList = client.GetFolders(client.PersonalNamespaces[0]).ToList();

            //只获取收件箱文件夹
            var folder = client.GetFolder("INBOX");

            folder.Open(MailKit.FolderAccess.ReadOnly);

            var uids = folder.Search(SearchQuery.All);

            var header = folder.Fetch(uids, MessageSummaryItems.UniqueId | MessageSummaryItems.Full);

            Tnsmtp_Recmail tnsmtp_Recmail = new Tnsmtp_Recmail();

            if (tnsmtp_Recmail.SelectMaxRecEmail(AccountId, userid))
            {
                uids = folder.Search(SearchQuery.DeliveredBefore(tnsmtp_Recmail.Rectimer));
            }

            BeginTransaction();

            foreach (var uid in uids)
            {
                var message = folder.GetMessage(uid);
                if (!InserRecTable(message, tnsmtp_Account, userid, uid.Id.ToString()))
                {
                    Log.Info("获取邮件后添加数据库失败！");
                    Alert("获取邮件后添加数据库失败！");
                    Rollback();
                    return false;
                }
            }


            Commit();
            client.Disconnect(true);


            return true;

        }
        [Obsolete]

        public bool InserRecTable(MimeMessage message, Tnsmtp_Account account, int userid, string euid)
        {

            DataAccess.Tnsmtp_Recmail tnsmtp_Recmail = new Tnsmtp_Recmail();
            tnsmtp_Recmail.ReferenceTransactionFrom(this.Transaction);
            tnsmtp_Recmail.Userid = userid;
            tnsmtp_Recmail.AccountId = account.Aid;
            tnsmtp_Recmail.Content = message.HtmlBody;
            tnsmtp_Recmail.Rectimer = message.Date.DateTime;
            tnsmtp_Recmail.Euid = euid;
            tnsmtp_Recmail.Subject = message.Subject;
            tnsmtp_Recmail.Hasfile = message.Attachments.ToList().Count > 0 ? 1 : 0;
            tnsmtp_Recmail.ReciverMail = account.Account;
            tnsmtp_Recmail.ReciverName = account.Account;
            tnsmtp_Recmail.SenderName = message.From.Mailboxes.ToList()[0].Name;
            tnsmtp_Recmail.SenderMail = message.From.Mailboxes.ToList()[0].Address;

            if (!tnsmtp_Recmail.Insert())
            {
                Log.Info("获取邮件后添加数据库失败！" + message.MessageId);
                Alert("获取邮件后添加数据库失败！" + message.MessageId);

                return false;
            }
            var attachments = message.Attachments.ToList();
            if (attachments.Any())
            {
                foreach (var item in attachments)
                {
                    if (!InserAttchmentFileTable(tnsmtp_Recmail.Recid, account.Aid, item))
                    {
                        Log.Info("添加附件失败！" + message.MessageId);
                        Alert("添加附件失败！" + message.MessageId);
                        return false;
                    }
                }

            }
            return true;
        }

        [Obsolete]
        public bool InserAttchmentFileTable(int Recid, int accountid, MimeKit.MimeEntity entity)
        {


            DataAccess.Tnsmtp_Receivefile tnsmtp_Receivefile = new Tnsmtp_Receivefile();

            tnsmtp_Receivefile.ReferenceTransactionFrom(this.Transaction);

            tnsmtp_Receivefile.RecMailid = Recid;
            tnsmtp_Receivefile.Userid = Recid;
            tnsmtp_Receivefile.Accountid = accountid;
            tnsmtp_Receivefile.Fileurl = entity.ContentDisposition.FileName;
            tnsmtp_Receivefile.Filename = entity.ContentDisposition.FileName;
            tnsmtp_Receivefile.Downloadurl = entity.ContentDisposition.FileName;
            tnsmtp_Receivefile.Filesize = 0;

            if (!tnsmtp_Receivefile.Insert())
            {
                Alert("添加附件信息时报" + entity.ContentDisposition);

                return false;

            }

            return true;
        }


        public bool KitEmailHelper(string PopUrl, int PopPort, string Account, string Pwd, DateTime? SerchTime, out List<MimeMessage> messages)
        {
            messages = new List<MimeMessage>();

            try
            {
                ImapClient client = new ImapClient();
                client.Connect(PopUrl, PopPort, true);

                client.Authenticate(Account, Pwd);

                List<IMailFolder> mailFolderList = client.GetFolders(client.PersonalNamespaces[0]).ToList();

                var folder = client.GetFolder("INBOX");

                folder.Open(MailKit.FolderAccess.ReadOnly);

                //如果没有最新数据，就获取全部的邮件，有则获取该时间往后的

                SearchQuery searchWhere = SearchQuery.All;
                if (SerchTime.HasValue)
                {
                    searchWhere = SearchQuery.DeliveredBefore(SerchTime.Value);
                }

                var uids = folder.Search(searchWhere);

                foreach (var uid in uids)
                {
                    MimeMessage message = folder.GetMessage(uid);
                    messages.Add(message);
                }

                client.Disconnect(true);
                return true;


            }
            catch (Exception ex)
            {

                Log.Info(ex);
                return false;
            
            }
        }

    }
}
