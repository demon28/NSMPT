using NSMPT.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;

namespace NSMPT.Facade
{
    public class Spider2Contact : FacadeBase
    {
        public bool Enter(List<int> spids, int gid,int userid)
        {

            Tnsmtp_SpidermailCollection collection = new Tnsmtp_SpidermailCollection();

            if (!collection.ListBySpids(spids))
            {
                Alert("查询失败！");
                return false;
            }
            DataAccess.Tnsmtp_ContactCollection tnsmtp_ContactCollection = new DataAccess.Tnsmtp_ContactCollection();
            tnsmtp_ContactCollection.ListCount(userid, gid);
            if (tnsmtp_ContactCollection.DataTable.Rows.Count > 2000)
            {
               Alert("该小组已超过2000条邮箱！");
                return false;
            }



            BeginTransaction();

            for (int i = 0; i < collection.DataTable.Rows.Count; i++)
            {
                string email = collection.DataTable.Rows[i][Tnsmtp_Spidermail._EMAIL].ToString();

                Tnsmtp_Contact tnsmtp = new DataAccess.Tnsmtp_Contact();
                if (tnsmtp.SelectIsExtByEmail(userid, email, gid))
                {
                    continue;
                }

                DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
                tnsmtp_Contact.ReferenceTransactionFrom(this.Transaction);


                tnsmtp_Contact.ContactName = collection.DataTable.Rows[i][Tnsmtp_Spidermail._FIRSTNAME].ToString();
                tnsmtp_Contact.Email = email;
                tnsmtp_Contact.Gid = gid;
                tnsmtp_Contact.Status = 0;
                tnsmtp_Contact.UserId = userid;

                if (!tnsmtp_Contact.Insert())
                {
                    Rollback();
                    Alert("添加失败！");
                    return false;
                }
           

            }
            Commit();
            return true;

        }


    }
}
