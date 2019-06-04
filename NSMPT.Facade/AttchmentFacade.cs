using NSMPT.DataAccess;
using NSMPT.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;

namespace NSMPT.Facade
{
  public  class AttchmentFacade : FacadeBase
    {


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
                list.Add(dr[Tnsmtp_Attachment._FILE_NAME].ToString(), dr[Tnsmtp_Attachment._REMARKS].ToString());

            }
            filelist = list;
            return true;

        }

        /// <summary>
        /// 添加附件表数据
        /// </summary>
        /// <returns></returns>
        public bool AddAtthachmentTable(Tnsmtp_EmailMap model, Tnsmtp_Account tnsmtp_Account, out Dictionary<string, string> filelist)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (model.Atthachment == null || model.Atthachment.Length <= 0)
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
                string path = HttpContext.Current.Server.MapPath("~/File/UserFile/" + model.Userid + "/Attachment/" + tnsmtp_Attachment.FileName);

                tnsmtp_Attachment.Remarks = path;   //保存物理路径

                if (!tnsmtp_Attachment.Insert())
                {
                    filelist = dic;
                    return false;
                }



                dic.Add(tnsmtp_Attachment.FileName, path);
            }
            filelist = dic;
            return true;

        }


    }
}
