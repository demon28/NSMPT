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
    public class ImapEmail:FacadeBase
    {
        public bool GetMail(int  AccountId,int userid) {


            Tnsmtp_Account tnsmtp_Account = new Tnsmtp_Account();


            if (!tnsmtp_Account.SelectByPK(AccountId))
            {
                Alert("获取账户信息失败！");
                return false;
            }

            Tnsmtp_Mailtype tnsmtp_Mailtype = new Tnsmtp_Mailtype();
            if (!tnsmtp_Mailtype.SelectByPK(tnsmtp_Account.MailType.Value))
            {
                Alert("获取邮件配置失败！");
                return false;
            }


            ImapClient client = new ImapClient();
            client.Connect(tnsmtp_Mailtype.PopUrl, int.Parse(tnsmtp_Mailtype.PopPort), true);

            client.Authenticate(tnsmtp_Account.Account, tnsmtp_Account.Password);

            //获取所有的文件夹
            List<IMailFolder> mailFolderList = client.GetFolders(client.PersonalNamespaces[0]).ToList();

            //只获取收件箱文件夹
            var folder = client.GetFolder("INBOX");
           
            folder.Open(MailKit.FolderAccess.ReadOnly);

            var uids = folder.Search(SearchQuery.All) ;

            var header = folder.Fetch(uids, MessageSummaryItems.UniqueId | MessageSummaryItems.Full);

            Tnsmtp_Recmail tnsmtp_Recmail = new Tnsmtp_Recmail();
        
            if (tnsmtp_Recmail.SelectMaxRecEmail(AccountId, userid))
            {
                uids = folder.Search(SearchQuery.DeliveredBefore(tnsmtp_Recmail.Rectimer.Value));
            }

            BeginTransaction();

            foreach (var uid in uids)
            {
                var message = folder.GetMessage(uid);
                if (!InserRecTable(message, tnsmtp_Account, userid,(int)uid.Id))
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




        public bool InserRecTable(MimeMessage message, Tnsmtp_Account account, int userid,int euid) {

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
                Log.Info("获取邮件后添加数据库失败！"+ message.MessageId);
                Alert("获取邮件后添加数据库失败！" + message.MessageId);
            
                return false;
            }
            var attachments = message.Attachments.ToList();
            if (attachments.Any())
            {
                    foreach (var item in attachments)
                    {
                        if (!InserAttchmentFileTable(tnsmtp_Recmail.Recid, account.Aid,item))
                        {
                        Log.Info("添加附件失败！" + message.MessageId);
                        Alert("添加附件失败！" + message.MessageId);
                        return false;
                        }
                    }

            }
            return true;
        }



        public bool InserAttchmentFileTable(int Recid,int accountid, MimeKit.MimeEntity entity)
        {


            DataAccess.Tnsmtp_Receivefile tnsmtp_Receivefile = new Tnsmtp_Receivefile();

            tnsmtp_Receivefile.ReferenceTransactionFrom(this.Transaction);

            tnsmtp_Receivefile.RecMailid = Recid;
            tnsmtp_Receivefile.Userid = Recid;
            tnsmtp_Receivefile.Accountid = accountid;
            tnsmtp_Receivefile.Fileurl = entity.ContentDisposition.FileName;
            tnsmtp_Receivefile.Filename = entity.ContentDisposition.FileName;
            tnsmtp_Receivefile.Downloadurl = entity.ContentDisposition.FileName;
            tnsmtp_Receivefile.Filesize =0;

            if (!tnsmtp_Receivefile.Insert())
            {
                Alert("添加附件信息时报"+ entity.ContentDisposition);
               
                return false;

            }

            return true;
        }

    }
}
