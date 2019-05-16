/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Receivefile.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-16 18:16:47  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Receivefile
    /// </summary>
    public partial class Tnsmtp_ReceivefileMap
    {
        #region 公开属性
        
		/// <summary>
		/// 主键
		/// [default:0]
		/// </summary>
		public int RecfileId { get; set; }

		/// <summary>
		/// 归属邮件id
		/// [default:0]
		/// </summary>
		public int RecMailid { get; set; }

		/// <summary>
		/// 文件名
		/// [default:string.Empty]
		/// </summary>
		public string Filename { get; set; }

		/// <summary>
		/// 文件下载地址
		/// [default:string.Empty]
		/// </summary>
		public string Downloadurl { get; set; }

		/// <summary>
		/// 账户id
		/// [default:0]
		/// </summary>
		public int Accountid { get; set; }

		/// <summary>
		/// 用户id
		/// [default:DBNull.Value]
		/// </summary>
		public int? Userid { get; set; }

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
		public string Remark { get; set; }

		/// <summary>
		/// 文件本地路径
		/// [default:string.Empty]
		/// </summary>
		public string Fileurl { get; set; }

		/// <summary>
		/// 文件大小
		/// [default:DBNull.Value]
		/// </summary>
		public int? Filesize { get; set; }



        #endregion 公开属性
    } 
}