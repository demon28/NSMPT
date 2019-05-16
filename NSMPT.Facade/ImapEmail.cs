using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using NSMPT.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;

namespace NSMPT.Facade
{
    public class ImapEmail:FacadeBase
    {
        public bool GetMail(int  AccountId) {


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

            List<IMailFolder> mailFolderList = client.GetFolders(client.PersonalNamespaces[0]).ToList();

            //只获取收件箱文件夹
            client.Inbox.Open(FolderAccess.ReadOnly);

            var uids = client.Inbox.Search(SearchQuery.All);
            foreach (var uid in uids)
            {
                var message = client.Inbox.GetMessage(uid);
               
            }

           
            client.Disconnect(true);


            return true;

        }


        public bool DownloadBodyParts(ImapClient client) {

           

            using (client)
            {


                



            }

            return true;

        }
    }
}
