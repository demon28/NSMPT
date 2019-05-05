/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Contact.extension.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-04-28 17:13:57  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Winner.Framework.Core;
using Winner.Framework.Core.DataAccess;
using Winner.Framework.Core.DataAccess.Oracle;
using Winner.Framework.Utils;
namespace NSMPT.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Contact
    /// </summary>
    public partial class Tnsmtp_Contact : DataAccessBase
    {
        //Custom Extension Class

        public bool SelectByUserId(int userid,int contactid) {
            string where = " user_id=:userid  and CONTACT_ID=:contactid";
            AddParameter("userid", userid);
            AddParameter("contactid", contactid);
            return SelectByCondition(where);

        }
        public bool SelectByGidCount(int Gid)
        {
            string sql = "select  count(0) gcount  from tnsmtp_contact t where t.gid=:gid";
            AddParameter("gid",Gid);
            return SelectBySql(sql);

        }
        public bool InsertAllContact(string sql) {

            return ExecuteNonQuery(sql)>0;
        }

    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Contact
    /// </summary>
    public partial class Tnsmtp_ContactCollection : DataAccessCollectionBase
    {
        //Custom Extension Class

        public bool ListByUserid(int userid,string keyword,int? gid)
        {
            string sql = "select t.*,tc.groupname from tnsmtp_contact t left join tnsmtp_contactgroup tc on t.gid=tc.gid where t.user_id=:userid  and t.status=0";
            AddParameter("userid", userid);

            if (!string.IsNullOrEmpty( keyword))
            {
                sql += " and " + SQLHelper.ToSQLLike("t.CONTACT_NAME ",keyword);
            }
            if (gid.HasValue)
            {
                sql += " and tc.gid=:gid";
                AddParameter("gid", gid.Value);
            }
            sql += "  order by t.createtime desc";


            return ListBySql(sql);
        }



    }
}