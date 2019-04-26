
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
        public bool SelectByDefault(int defaultstatus)
        {
            string strwhere = " isdefault=:defaultstatus";
            AddParameter("isdefault", defaultstatus);

            return SelectByCondition(strwhere);

        }
    }
	/// <summary>
	/// 账户表[集合对象]
	/// </summary>
	public partial class Tnsmtp_AccountCollection
	{
		public bool ListByUserId(int userid)
        {
            string strwhere = " userid=:userid";
            AddParameter("userid", userid);

           return ListByCondition(strwhere);

        }
	}
}