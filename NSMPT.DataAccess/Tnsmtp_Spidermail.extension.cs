﻿/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Spidermail.extension.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-23 20:34:38  
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
    /// Data Access Layer Object Of Tnsmtp_Spidermail
    /// </summary>
    public partial class Tnsmtp_Spidermail : DataAccessBase
    {

        public bool SelectByEmail(string mail)
        {
            string where = " email=:email";
            AddParameter("email", mail);

            return SelectByCondition(where);

        }


        //Custom Extension Class
    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Spidermail
    /// </summary>
    public partial class Tnsmtp_SpidermailCollection : DataAccessCollectionBase
    {
        //Custom Extension Class

        public bool ListByAllSp()
        {
            string sql = "select t.spid,t.firstname,t.lastname,t.email,t.address,t.city,t.state,t.zip,t.homephone,t.status,t.createtime from tnsmtp_spidermail t  order by t.spid asc";
            return ListBySql(sql);

        }

        public bool ListBySpids(List<int> spids)
        {

            string sql = " select t.spid,t.firstname,t.email from tnsmtp_spidermail t where  t.spid in (";

            foreach (var item in spids)
            {
                sql += item + ",";
                    
            }
            sql = sql.Substring(0, sql.LastIndexOf(','));
            sql += ")";
            return ListBySql(sql);
        }

    }
}