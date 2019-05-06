/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Raplcemark.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-06 12:02:57  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.Entites
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Raplcemark
    /// </summary>
    public partial class Tnsmtp_RaplcemarkMap
    {
        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Rid { get; set; }

		/// <summary>
		/// 标签名称
		/// [default:string.Empty]
		/// </summary>
		public string MarkName { get; set; }

		/// <summary>
		/// 标签值
		/// [default:string.Empty]
		/// </summary>
		public string MarkValue { get; set; }

		/// <summary>
		/// 标签类型0，公共标签，1私有标签
		/// [default:0]
		/// </summary>
		public int MarkType { get; set; }

		/// <summary>
		/// mark对应的动态表
		/// [default:DBNull.Value]
		/// </summary>
		public int? TableId { get; set; }

		/// <summary>
		/// 状态
		/// [default:0]
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 时间
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
		/// [default:DBNull.Value]
		/// </summary>
		public int? Userid { get; set; }



        #endregion 公开属性
    } 
}