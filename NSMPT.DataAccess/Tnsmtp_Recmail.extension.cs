/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Recmail.extension.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-07 15:40:34  
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
    /// Data Access Layer Object Of Tnsmtp_Recmail
    /// </summary>
    public partial class Tnsmtp_Recmail : DataAccessBase
    {
        //Custom Extension Class

        public bool SelectMaxRecEmail(int accountid, int userid) {

            string sql = @"select a.* from tnsmtp_recmail a where a.rectimer in (
select Max(t.rectimer)  from tnsmtp_recmail t where t.account_id=:accountid and t.userid =:userid )";

            AddParameter("accountid", accountid);
            AddParameter("userid", userid);

            return SelectBySql(sql);

        }

    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Recmail
    /// </summary>
    public partial class Tnsmtp_RecmailCollection : DataAccessCollectionBase
    {
        //Custom Extension Class

        public bool ListByAccount(int accountid, int userid,string keywords) {
            string where = " status=0 and account_id=:accountid and userid=:userid  ";

            AddParameter("accountid", accountid);
            AddParameter("userid",userid);
            if (!string.IsNullOrEmpty(keywords))
            {
                where += "  and subject like '%'|| :keyword  ||'%' ";
                AddParameter("keyword", keywords);
            }
            where += " order by createtime desc";

            return ListByCondition(where);

        }


    }
}