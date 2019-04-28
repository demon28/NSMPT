﻿/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Contactgroup.extension.cs 
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
    /// Data Access Layer Object Of Tnsmtp_Contactgroup
    /// </summary>
    public partial class Tnsmtp_Contactgroup : DataAccessBase
    {
        //Custom Extension Class

        public bool SelecByUserid(int userid ,int gid) {
            string where = " userid=:userid  and gid=:gid";
            AddParameter("userid", userid);
            AddParameter("gid", gid);

            return SelectByCondition(where);

        }
    }


    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Contactgroup
    /// </summary>
    public partial class Tnsmtp_ContactgroupCollection : DataAccessCollectionBase
    {
        //Custom Extension Class

        public bool ListByUserid(int userid) {

            string where = " userid=:userid and status=0 ";

            AddParameter("userid", userid);
            return ListByCondition(where);
        }
    }
}