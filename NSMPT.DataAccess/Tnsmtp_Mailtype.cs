
 /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnsmtp_Mailtype.cs
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
	/// 邮箱类型表
	/// </summary>
	public partial class Tnsmtp_Mailtype
	{
		
	}
	/// <summary>
	/// 邮箱类型表[集合对象]
	/// </summary>
	public partial class Tnsmtp_MailtypeCollection
	{
        public bool ListMailtype() {

            string sql = "select t.mtid,t.mailname from tnsmtp_mailtype t where t.status = 0";

            return ListBySql(sql);
        }
	}
}