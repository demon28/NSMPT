/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Mailtype.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-15 19:18:19  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.Entites
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Mailtype
    /// </summary>
    public partial class Tnsmtp_MailtypeMap
    {
        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Mtid { get; set; }

		/// <summary>
		/// 企业邮箱名称，腾讯企业邮箱，163企业邮箱
		/// [default:string.Empty]
		/// </summary>
		public string Mailname { get; set; }

		/// <summary>
		/// 邮箱smtp地址: stmp.exmail.qq.com
		/// [default:string.Empty]
		/// </summary>
		public string SmtpUrl { get; set; }

		/// <summary>
		/// 邮箱端口:25
		/// [default:DBNull.Value]
		/// </summary>
		public int? SmtpPort { get; set; }

		/// <summary>
		/// SSL邮箱端口：465
		/// [default:DBNull.Value]
		/// </summary>
		public int? SmtpSsl { get; set; }

		/// <summary>
		/// 状态：0启动，1不启用
		/// [default:DBNull.Value]
		/// </summary>
		public int? Status { get; set; }

		/// <summary>
		/// 创建时间
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Createtime { get; set; }

		/// <summary>
		/// 备注
		/// [default:string.Empty]
		/// </summary>
		public string Remarks { get; set; }

		/// <summary>
		/// POP3收件地址
		/// [default:string.Empty]
		/// </summary>
		public string PopUrl { get; set; }

		/// <summary>
		/// POP3收件端口
		/// [default:string.Empty]
		/// </summary>
		public string PopPort { get; set; }



        #endregion 公开属性
    } 
}