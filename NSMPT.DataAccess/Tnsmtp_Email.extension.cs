/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Email.extension.cs 
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
    /// Data Access Layer Object Of Tnsmtp_Email
    /// </summary>
    public partial class Tnsmtp_Email : DataAccessBase
    {
        //Custom Extension Class

        public bool SelectDraftByUserid(int userid, int mailid) {

            string where = " status=2 and userid=:userid and mail_id=:mailid";
            AddParameter("userid", userid);
            AddParameter("mailid", mailid);

            return SelectByCondition(where);
        }

        public bool SelectSendByUserid(int userid, int mailid)
        {

            string where = " status=1 and userid=:userid and mail_id=:mailid";
            AddParameter("userid", userid);
            AddParameter("mailid", mailid);

            return SelectByCondition(where);
        }

    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Email
    /// </summary>
    public partial class Tnsmtp_EmailCollection : DataAccessCollectionBase
    {
        //Custom Extension Class
        public bool ListDraftByUserid(int userid ,string keywords) {

            string where = "  status=2 and userid=:userid ";

            if (!string.IsNullOrEmpty(keywords))
            {
                where += "  and subject like '%'|| :keyword  ||'%'";
                AddParameter("keyword", keywords);
            }
            AddParameter("userid", userid);
            return ListByCondition(where);
        }


        public bool ListSendByUserid(int userid, string keywords)
        {

            string where = "  status=1 and userid=:userid ";

            if (!string.IsNullOrEmpty(keywords))
            {
                where += "  and subject like '%'|| :keyword  ||'%'";
                AddParameter("keyword", keywords);
            }
            AddParameter("userid", userid);
            return ListByCondition(where);
        }
    }
}