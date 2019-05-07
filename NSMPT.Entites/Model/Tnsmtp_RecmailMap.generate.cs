/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Recmail.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-07 15:41:55  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.Entites
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Recmail
    /// </summary>
    public partial class Tnsmtp_RecmailMap
    {
        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Recid { get; set; }

		/// <summary>
		/// 发送者邮件
		/// [default:string.Empty]
		/// </summary>
		public string SenderMail { get; set; }

		/// <summary>
		/// 发送者名称
		/// [default:string.Empty]
		/// </summary>
		public string SenderName { get; set; }

		/// <summary>
		/// 接收者名称
		/// [default:string.Empty]
		/// </summary>
		public string ReciverName { get; set; }

		/// <summary>
		/// 接收者邮件
		/// [default:string.Empty]
		/// </summary>
		public string ReciverMail { get; set; }

		/// <summary>
		/// 主题
		/// [default:string.Empty]
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// 内容
		/// [default:string.Empty]
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// 是否已读
		/// [default:DBNull.Value]
		/// </summary>
		public int? FlagRead { get; set; }

		/// <summary>
		/// 接收状态
		/// [default:DBNull.Value]
		/// </summary>
		public int? FlagStatus { get; set; }

		/// <summary>
		/// 邮件账户id
		/// [default:DBNull.Value]
		/// </summary>
		public int? AccountId { get; set; }

		/// <summary>
		/// 用户di
		/// [default:DBNull.Value]
		/// </summary>
		public int? Userid { get; set; }

		/// <summary>
		/// 时间
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Createtime { get; set; }

		/// <summary>
		/// 状态
		/// [default:DBNull.Value]
		/// </summary>
		public int? Status { get; set; }

		/// <summary>
		/// 备注
		/// [default:string.Empty]
		/// </summary>
		public string Remarks { get; set; }



        #endregion 公开属性
    } 
}