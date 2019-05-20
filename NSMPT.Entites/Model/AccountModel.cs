   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Account.cs
 * CreateTime : 2019-04-26 15:47:24
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


namespace NSMPT.Entites
{
	/// <summary>
	/// 账户表
	/// </summary>
	public class AccountModel
	{			
		/// <summary>
		/// 0,为非默认，1为默认,(可空)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int
        Isdefault{ get; set; }
		/// <summary>
		/// id(必填)
		/// <para>
		/// defaultValue: 0;   Length: 10Byte
		/// </para>
		/// </summary>
		public int Aid{ get; set; }
		/// <summary>
		/// 账户(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Account{ get; set; }
		/// <summary>
		/// 密码(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Password{ get; set; }
		/// <summary>
		/// 企业邮箱类型(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 10Byte
		/// </para>
		/// </summary>
		public int Mail_Type{ get; set; }
		/// <summary>
		/// 用户id(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 10Byte
		/// </para>
		/// </summary>
		public int? Userid{ get; set; }
		/// <summary>
		/// 状态(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 10Byte
		/// </para>
		/// </summary>
		public int? Status{ get; set; }
		/// <summary>
		/// 时间(可空)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Createtime{ get; set; }
		/// <summary>
		/// 备注(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 500Byte
		/// </para>
		/// </summary>
		public string Remarks{ get; set; }
	}
}