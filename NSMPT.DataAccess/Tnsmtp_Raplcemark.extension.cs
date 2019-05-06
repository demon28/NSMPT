﻿/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Raplcemark.extension.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-06 11:41:14  
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
    /// Data Access Layer Object Of Tnsmtp_Raplcemark
    /// </summary>
    public partial class Tnsmtp_Raplcemark : DataAccessBase
    {
        //Custom Extension Class
    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Raplcemark
    /// </summary>
    public partial class Tnsmtp_RaplcemarkCollection : DataAccessCollectionBase
    {
        //Custom Extension Class
        public bool ListByUser(int? userid) {

            string where = "  status=0";

            if (userid.HasValue)
            {
                where += " and userid=:userid";
                AddParameter("userid", userid.Value);
            }

            where += " or userid is null";

          

            return ListByCondition(where);

        }
    }
}