/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Mailtemplate.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-06 11:33:59  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.Entites
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Mailtemplate
    /// </summary>
    public partial class Tnsmtp_MailtemplateMap
    {
        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int MtId { get; set; }

		/// <summary>
		/// 模板名称
		/// [default:string.Empty]
		/// </summary>
		public string TempName { get; set; }

		/// <summary>
		/// 模板内容
		/// [default:string.Empty]
		/// </summary>
		public string TempContent { get; set; }

		/// <summary>
		/// 模板识别表情
		/// [default:DBNull.Value]
		/// </summary>
		public int? ReplaceId { get; set; }

		/// <summary>
		/// 模板状态
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
		/// 用户id
		/// [default:DBNull.Value]
		/// </summary>
		public int? Userid { get; set; }



        #endregion 公开属性
    } 
}