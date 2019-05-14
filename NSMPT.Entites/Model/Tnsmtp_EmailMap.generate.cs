/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Email.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-08 18:43:55  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.Entites
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Email
    /// </summary>
    public partial class Tnsmtp_EmailMap
    {
        #region 公开属性
        
		/// <summary>
		/// 邮件id
		/// [default:0]
		/// </summary>
		public int MailId { get; set; }

		/// <summary>
		/// 发送邮件账号
		/// [default:string.Empty]
		/// </summary>
		public string Tomail { get; set; }

		/// <summary>
		/// 接收邮件账号，多账号以逗号分隔
		/// [default:string.Empty]
		/// </summary>
		public string Inmail { get; set; }

		/// <summary>
		/// 邮件主题
		/// [default:string.Empty]
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// 抄送
		/// [default:string.Empty]
		/// </summary>
		public string Wcc { get; set; }

		/// <summary>
		/// 密送
		/// [default:string.Empty]
		/// </summary>
		public string Bcc { get; set; }

		/// <summary>
		/// 内容
		/// [default:string.Empty]
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// 发送日期
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Senddate { get; set; }

		/// <summary>
		/// 是否已读 0：未读，1：已读
		/// [default:DBNull.Value]
		/// </summary>
		public int FlagRead { get; set; }

		/// <summary>
		/// 邮箱状态 1，已发送 2，草稿，3，已删除
		/// [default:0]
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 邮件发送状态：0：已发送；1：发送中，2:发送失败
		/// [default:0]
		/// </summary>
		public int FlagStatus { get; set; }

		/// <summary>
		/// 外键账户表
		/// [default:0]
		/// </summary>
		public int AccountId { get; set; }

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
		/// 用户id
		/// [default:0]
		/// </summary>
		public int Userid { get; set; }

		/// <summary>
		/// 联系人id
		/// [default:DBNull.Value]
		/// </summary>
		public int? RecId { get; set; }



        #endregion 公开属性
    } 
}