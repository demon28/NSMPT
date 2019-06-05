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

            string where = " status=1 and userid=:userid and mail_id=:mailid ";
            AddParameter("userid", userid);
            AddParameter("mailid", mailid);

            return SelectByCondition(where);
        }

        public bool SelectByTotal(int userid) {

            string sql = @" select a.total,a.completed,a.sending,a.Faileds,b.isread,b.noread from (
 
 select  count(0) total,
         sum(decode(t.flag_status, 0, 1, 0)) completed,
         sum(decode(t.flag_status, 1, 1, 0)) sending,
         sum(decode(t.flag_status, 2, 1, 0)) Faileds
        
    from tnsmtp_email t
   where t.userid =:userid
   
 ) a
inner join

( select sum(decode(t.flag_read,0,1,0)) noread,
        sum(decode(t.flag_read,1,1,0)) isread
        from tnsmtp_email t
   where t.userid = :userid and  t.status=1 
  )b
 
 on 1=1 ";

            AddParameter("userid", userid);

            return SelectBySql(sql);

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
                where += "  and subject like '%'|| :keyword  ||'%' ";
                AddParameter("keyword", keywords);
            }

            where += " order by mail_id desc";
            AddParameter("userid", userid);
            return ListByCondition(where);
        }


        public bool ListSendByUserid(int userid, string keywords)
        {

            string where = "  status=1 and userid=:userid ";

            if (!string.IsNullOrEmpty(keywords))
            {
                where += "  and subject like '%'|| :keyword  ||'%' ";
                AddParameter("keyword", keywords);
            }
            AddParameter("userid", userid);

            where += " order by mail_id desc";

            return ListByCondition(where);
        }


        public bool ListSendByFlagStatus(int status)
        {

            string where = "  status=1 and flag_status=:flagstatus";
          
            AddParameter("flagstatus", status);

            where += " order by mail_id desc";

            return ListByCondition(where);
        }

    }
}