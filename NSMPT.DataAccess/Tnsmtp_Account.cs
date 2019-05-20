
 /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnsmtp_Account.cs
 * CreateTime : 2019-04-26 15:20:50
 * CodeGenerateVersion : 1.0.0.0
 * TemplateVersion: 2.0.0
 * E_Mail : zhj.pavel@gmail.com
 * Blog : 
 * Copyright (C) YXH
 * 
 ***************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NSMPT.DataAccess
{
	/// <summary>
	/// 账户表
	/// </summary>
	public partial class Tnsmtp_Account
	{
        public bool SelecByUserDefault(int userid) {

            string str = " isdefault=1 and Userid=:userid";
            AddParameter("userid", userid);
            return SelectByCondition(str);

        }

    }
	/// <summary>
	/// 账户表[集合对象]
	/// </summary>
	public partial class Tnsmtp_AccountCollection
	{
		public bool ListByUserId(int userid)
        {


            string sql = "select t.aid,t.account,t.userid,t.status,t.isdefault,tm.mailname,t.createtime,t.password,t.mail_type from tnsmtp_account t left join tnsmtp_mailtype tm on t.mail_type=tm.mtid where t.status=0 and t.userid=:userid order by t.createtime asc";
            AddParameter("userid", userid);

           return ListBySql(sql);

        }

       

      

	}
}