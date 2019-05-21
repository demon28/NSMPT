using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
namespace NSMPT.Facade
{
    public class ImapEmail : FacadeBase
    {


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
                    searchWhere = SearchQuery.DeliveredAfter(SerchTime.Value);
                }

                var uids = folder.Search(searchWhere);

                foreach (var uid in uids)
                {
                    MimeMessage message = folder.GetMessage(uid);

                    //邮件只能获取到当天，mailkit没找到精确到秒的筛选,需要自己过滤
                    if (SerchTime.HasValue)
                    {
                        if (message.Date.DateTime > SerchTime.Value)
                        {
                            messages.Add(message);
                        }

                    }
                    else
                    {
                        messages.Add(message);
                    }



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

        public bool KitAttFileHelper(MimeEntity attachment, int userid, out string url)
        {

            try
            {
                if (!attachment.IsAttachment)
                {
                    url = string.Empty;
                    return false;
                }
                string filepath = "/File/UserFile/" + userid + "/RecAttachment/";
                filepath = HttpContext.Current.Server.MapPath(filepath);
                if (Directory.Exists(filepath) == false)
                {
                    Directory.CreateDirectory(filepath);
                }

                var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
                fileName = fileName.Remove(fileName.LastIndexOf('.')) + "(" + DateTime.Now.ToString("yyyyMMddHHmmss") + ")" + Path.GetExtension(fileName);

                filepath += fileName;

                using (var stream = File.Create(filepath))
                {
                    if (attachment is MessagePart rfc822)
                    {
                        rfc822.Message.WriteTo(stream);
                    }
                    else
                    {
                        var part = (MimePart)attachment;
                        part.Content.DecodeTo(stream);
                    }
                }
                url = filepath;
                var mailFileInfo = new FileInfo(filepath);


                return true;

            }
            catch (Exception)
            {
                url = string.Empty;
                Log.Info("下载附件失败!");
                return false;

            }

        }




    }
}
