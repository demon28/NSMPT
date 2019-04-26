   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Mailtype.cs
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
	/// 邮箱类型表
	/// </summary>
	public class Mailtype
	{			
		/// <summary>
		/// id(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal Mtid{ get; set; }
		/// <summary>
		/// 企业邮箱名称，腾讯企业邮箱，163企业邮箱(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Mailname{ get; set; }
		/// <summary>
		/// 邮箱smtp地址: stmp.exmail.qq.com(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 200Byte
		/// </para>
		/// </summary>
		public string Smtp_Url{ get; set; }
		/// <summary>
		/// 邮箱端口:25(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal? Smtp_Port{ get; set; }
		/// <summary>
		/// SSL邮箱端口：465(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal? Smtp_Ssl{ get; set; }
		/// <summary>
		/// 状态：0启动，1不启用(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal? Status{ get; set; }
		/// <summary>
		/// 创建时间(可空)
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