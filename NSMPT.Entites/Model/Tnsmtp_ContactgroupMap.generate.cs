/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Contactgroup.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-04-28 17:12:41  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.Entites
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Contactgroup
    /// </summary>
    public partial class Tnsmtp_ContactgroupMap
    {
        #region 公开属性
        
		/// <summary>
		/// 联系人id
		/// [default:0]
		/// </summary>
		public int Gid { get; set; }

		/// <summary>
		/// 分组名称
		/// [default:string.Empty]
		/// </summary>
		public string Groupname { get; set; }

		/// <summary>
		/// 用户id
		/// [default:0]
		/// </summary>
		public int Userid { get; set; }

		/// <summary>
		/// 状态
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



        #endregion 公开属性
    } 
}