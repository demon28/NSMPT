using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;

namespace NSMPT.Facade
{
    public class ImportContactFacade: FacadeBase
    {

        public bool Import(DataTable dt,int userid) {

            if (dt.Rows.Count<=0)
            {
                Alert("没有数据！");
                return false;
            }
            RemoveEmpty(dt); 
            BeginTransaction();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
                ReferenceTransactionFrom(Transaction);
                tnsmtp_Contact.ContactName = dt.Rows[i]["name"].ToString();
                tnsmtp_Contact.Email = dt.Rows[i]["email"].ToString();
                int gid = 0;
                int.TryParse(dt.Rows[i]["gid"].ToString(),out gid);
                tnsmtp_Contact.Gid= gid;
                tnsmtp_Contact.Status = 0;
                tnsmtp_Contact.UserId = userid;

                if (!tnsmtp_Contact.Insert())
                {
                    Rollback();
                    Alert("插入数据失败：" + tnsmtp_Contact.ContactName);
                    return false;
                }
            }

            Commit();


            return true;
        }

        [Obsolete]
        public bool ImportNoStep(DataTable dt, int userid) {
            if (dt.Rows.Count <= 0)
            {
                Alert("没有数据！");
                return false;
            }
            RemoveEmpty(dt);

            string sql = "INSERT ALL ";
             DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gid = 0;
                int.TryParse(dt.Rows[i]["gid"].ToString(), out gid);
                sql += " INTO tnsmtp_contact(CONTACT_NAME,EMAIL,USER_ID,STATUS,CREATETIME,GID) VALUES ('" + dt.Rows[i]["name"]+ "','" + dt.Rows[i]["email"] + "','"+userid+"',0, sysdate,"+ gid + ") ";


            }

            sql += " SELECT 1 FROM DUAL;";
            if (!tnsmtp_Contact.InsertAllContact(sql))
            {
                Alert("导入失败！");
                return false;
            }
            return true;

        }

        /// <summary>
        /// 删掉空行
        /// </summary>
        /// <param name="dt"></param>
        protected void RemoveEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
        }


    }
}
