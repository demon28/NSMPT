/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Spidermail.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-23 20:34:47  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.Entites
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Spidermail
    /// </summary>
    public partial class Tnsmtp_SpidermailMap
    {
        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Spid { get; set; }

		/// <summary>
		/// 姓
		/// [default:string.Empty]
		/// </summary>
		public string Firstname { get; set; }

		/// <summary>
		/// 名
		/// [default:string.Empty]
		/// </summary>
		public string Lastname { get; set; }

		/// <summary>
		/// 邮箱
		/// [default:string.Empty]
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// 地址
		/// [default:string.Empty]
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// 城市
		/// [default:string.Empty]
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// 州
		/// [default:string.Empty]
		/// </summary>
		public string State { get; set; }

		/// <summary>
		/// 邮编
		/// [default:string.Empty]
		/// </summary>
		public string Zip { get; set; }

		/// <summary>
		/// 家庭电话
		/// [default:string.Empty]
		/// </summary>
		public string Homephone { get; set; }

		/// <summary>
		/// 来源
		/// [default:string.Empty]
		/// </summary>
		public string Source { get; set; }

		/// <summary>
		/// ip地址
		/// [default:string.Empty]
		/// </summary>
		public string Ipaddress { get; set; }

		/// <summary>
		/// 抓取时间
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Regdate { get; set; }

		/// <summary>
		/// 邮件分类
		/// [default:0]
		/// </summary>
		public int Class { get; set; }

		/// <summary>
		/// 状态
		/// [default:0]
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 入库时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime Createtime { get; set; }

		/// <summary>
		/// 备注
		/// [default:string.Empty]
		/// </summary>
		public string Remarks { get; set; }



        #endregion 公开属性
    } 
}