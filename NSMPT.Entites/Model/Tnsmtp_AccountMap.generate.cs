/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tnsmtp_Account.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-20 23:51:31  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace NSMPT.Entites
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Account
    /// </summary>
    public partial class Tnsmtp_AccountMap
    {
        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Aid { get; set; }

		/// <summary>
		/// 账户
		/// [default:string.Empty]
		/// </summary>
		public string Account { get; set; }

		/// <summary>
		/// 密码
		/// [default:string.Empty]
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 企业邮箱类型
		/// [default:0]
		/// </summary>
		public int MailType { get; set; }

		/// <summary>
		/// 用户id
		/// [default:0]
		/// </summary>
		public int Userid { get; set; }

		/// <summary>
		/// 状态:0启用，1删除
		/// [default:0]
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime Createtime { get; set; }

		/// <summary>
		/// 备注
		/// [default:string.Empty]
		/// </summary>
		public string Remarks { get; set; }

		/// <summary>
		/// 0,为非默认，1为默认,
		/// [default:0]
		/// </summary>
		public int Isdefault { get; set; }



        #endregion 公开属性
    } 
}           