/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Attachment.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-10 16:49:03  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.Entites
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Attachment
    /// </summary>
    public partial class Tnsmtp_AttachmentMap
    {
        #region 公开属性
        
		/// <summary>
		/// 附件id
		/// [default:0]
		/// </summary>
		public int AtId { get; set; }

		/// <summary>
		/// 附件路径
		/// [default:string.Empty]
		/// </summary>
		public string FileUrl { get; set; }

		/// <summary>
		/// 文件名
		/// [default:string.Empty]
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// 邮件id，外键邮件表
		/// [default:0]
		/// </summary>
		public int MailId { get; set; }

		/// <summary>
		/// 临时的保存标识
		/// [default:DBNull.Value]
		/// </summary>
		public int? TempId { get; set; }

		/// <summary>
		/// 邮件账户id，外键邮箱账户表
		/// [default:0]
		/// </summary>
		public int AccountId { get; set; }

		/// <summary>
		/// 用户id，外键系统用户表
		/// [default:0]
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// 文件id，如有文件系统，外键文件系统表
		/// [default:DBNull.Value]
		/// </summary>
		public int? FileId { get; set; }

		/// <summary>
		/// 状态
		/// [default:0]
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 创建时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime Createtime { get; set; }

		/// <summary>
		/// 备注
		/// [default:string.Empty]
		/// </summary>
		public string Remarks { get; set; }

		/// <summary>
		/// 文件大小
		/// [default:string.Empty]
		/// </summary>
		public string FileSize { get; set; }



        #endregion 公开属性
    } 
}