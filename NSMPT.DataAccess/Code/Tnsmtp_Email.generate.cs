/***************************************************
*
* Data Access Layer Of Winner Framework
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
using Winner.Framework.Core;
using Winner.Framework.Core.DataAccess;
using Winner.Framework.Core.DataAccess.Oracle;
using Winner.Framework.Utils;
namespace NSMPT.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Email
    /// </summary>
    public partial class Tnsmtp_Email : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Email() : base() { }

        public Tnsmtp_Email(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _MAIL_ID="MAIL_ID";
		public const string _TOMAIL="TOMAIL";
		public const string _INMAIL="INMAIL";
		public const string _SUBJECT="SUBJECT";
		public const string _WCC="WCC";
		public const string _BCC="BCC";
		public const string _CONTENT="CONTENT";
		public const string _SENDDATE="SENDDATE";
		public const string _FLAG_READ="FLAG_READ";
		public const string _STATUS="STATUS";
		public const string _FLAG_STATUS="FLAG_STATUS";
		public const string _ACCOUNT_ID="ACCOUNT_ID";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";
		public const string _USERID="USERID";
		public const string _REC_ID="REC_ID";

    
        public const string _TABLENAME="Tnsmtp_Email";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// 邮件id
		/// [default:0]
		/// </summary>
		public int MailId
		{
			get { return Convert.ToInt32(DataRow[_MAIL_ID]); }
			set { setProperty(_MAIL_ID,value); }
		}
		/// <summary>
		/// 发送邮件账号
		/// [default:string.Empty]
		/// </summary>
		public string Tomail
		{
			get { return DataRow[_TOMAIL].ToString(); }
			set { setProperty(_TOMAIL,value); }
		}
		/// <summary>
		/// 接收邮件账号，多账号以逗号分隔
		/// [default:string.Empty]
		/// </summary>
		public string Inmail
		{
			get { return DataRow[_INMAIL].ToString(); }
			set { setProperty(_INMAIL,value); }
		}
		/// <summary>
		/// 邮件主题
		/// [default:string.Empty]
		/// </summary>
		public string Subject
		{
			get { return DataRow[_SUBJECT].ToString(); }
			set { setProperty(_SUBJECT,value); }
		}
		/// <summary>
		/// 抄送
		/// [default:string.Empty]
		/// </summary>
		public string Wcc
		{
			get { return DataRow[_WCC].ToString(); }
			set { setProperty(_WCC,value); }
		}
		/// <summary>
		/// 密送
		/// [default:string.Empty]
		/// </summary>
		public string Bcc
		{
			get { return DataRow[_BCC].ToString(); }
			set { setProperty(_BCC,value); }
		}
		/// <summary>
		/// 内容
		/// [default:string.Empty]
		/// </summary>
		public string Content
		{
			get { return DataRow[_CONTENT].ToString(); }
			set { setProperty(_CONTENT,value); }
		}
		/// <summary>
		/// 发送日期
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Senddate
		{
			get { return Helper.ToDateTime(DataRow[_SENDDATE]); }
			set { setProperty(_SENDDATE,Helper.FromDateTime(value)); }
		}
		/// <summary>
		/// 是否已读 0：未读，1：已读
		/// [default:DBNull.Value]
		/// </summary>
		public int? FlagRead
		{
			get { return Helper.ToInt32(DataRow[_FLAG_READ]); }
			set { setProperty(_FLAG_READ,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 邮箱状态 1，已发送 2，草稿，3，已删除
		/// [default:0]
		/// </summary>
		public int Status
		{
			get { return Convert.ToInt32(DataRow[_STATUS]); }
			set { setProperty(_STATUS,value); }
		}
		/// <summary>
		/// 邮件发送状态：0：已发送；1：发送中，2:发送失败
		/// [default:0]
		/// </summary>
		public int FlagStatus
		{
			get { return Convert.ToInt32(DataRow[_FLAG_STATUS]); }
			set { setProperty(_FLAG_STATUS,value); }
		}
		/// <summary>
		/// 外键账户表
		/// [default:0]
		/// </summary>
		public int AccountId
		{
			get { return Convert.ToInt32(DataRow[_ACCOUNT_ID]); }
			set { setProperty(_ACCOUNT_ID,value); }
		}
		/// <summary>
		/// 创建时间
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Createtime
		{
			get { return Convert.ToDateTime(DataRow[_CREATETIME].ToString()); }
		}
		/// <summary>
		/// 备注
		/// [default:string.Empty]
		/// </summary>
		public string Remarks
		{
			get { return DataRow[_REMARKS].ToString(); }
			set { setProperty(_REMARKS,value); }
		}
		/// <summary>
		/// 用户id
		/// [default:0]
		/// </summary>
		public int Userid
		{
			get { return Convert.ToInt32(DataRow[_USERID]); }
			set { setProperty(_USERID,value); }
		}
		/// <summary>
		/// 联系人id
		/// [default:DBNull.Value]
		/// </summary>
		public int? RecId
		{
			get { return Helper.ToInt32(DataRow[_REC_ID]); }
			set { setProperty(_REC_ID,Helper.FromInt32(value)); }
		}

        #endregion 公开属性
        
        #region 私有成员
        
        protected override string TableName
        {
            get { return _TABLENAME; }
        }

        protected override DataRow BuildRow()
        {
            DataTable dt = new DataTable(_TABLENAME);
			dt.Columns.Add(_MAIL_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_TOMAIL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_INMAIL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_SUBJECT, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_WCC, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_BCC, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CONTENT, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_SENDDATE, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_FLAG_READ, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_FLAG_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_ACCOUNT_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_USERID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_REC_ID, typeof(int)).DefaultValue = DBNull.Value;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_EMAIL WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int mailId)
        {
            string condition = "MAIL_ID=:MAIL_ID";
            AddParameter(_MAIL_ID, mailId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "MAIL_ID=:MAIL_ID";
            AddParameter(_MAIL_ID, MailId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			MailId=base.GetSequence("SELECT SEQ_TNSMTP_EMAIL.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_EMAIL(
  MAIL_ID,
  TOMAIL,
  INMAIL,
  SUBJECT,
  WCC,
  BCC,
  CONTENT,
  SENDDATE,
  FLAG_READ,
  STATUS,
  FLAG_STATUS,
  ACCOUNT_ID,
  REMARKS,
  USERID,
  REC_ID)
VALUES(
  :MAIL_ID,
  :TOMAIL,
  :INMAIL,
  :SUBJECT,
  :WCC,
  :BCC,
  :CONTENT,
  :SENDDATE,
  :FLAG_READ,
  :STATUS,
  :FLAG_STATUS,
  :ACCOUNT_ID,
  :REMARKS,
  :USERID,
  :REC_ID)";
			AddParameter(_MAIL_ID,DataRow[_MAIL_ID]);
			AddParameter(_TOMAIL,DataRow[_TOMAIL]);
			AddParameter(_INMAIL,DataRow[_INMAIL]);
			AddParameter(_SUBJECT,DataRow[_SUBJECT]);
			AddParameter(_WCC,DataRow[_WCC]);
			AddParameter(_BCC,DataRow[_BCC]);
			AddParameter(_CONTENT,DataRow[_CONTENT]);
			AddParameter(_SENDDATE,DataRow[_SENDDATE]);
			AddParameter(_FLAG_READ,DataRow[_FLAG_READ]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_FLAG_STATUS,DataRow[_FLAG_STATUS]);
			AddParameter(_ACCOUNT_ID,DataRow[_ACCOUNT_ID]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_USERID,DataRow[_USERID]);
			AddParameter(_REC_ID,DataRow[_REC_ID]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_MAIL_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_EMAIL SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE MAIL_ID=:MAIL_ID");
            AddParameter(_MAIL_ID, DataRow[_MAIL_ID]);
            if (!string.IsNullOrEmpty(condition))
                sql.AppendLine(" AND " + condition);
                
            bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
        }

        protected bool SelectByCondition(string condition)
        {
            string sql = @"
SELECT
  MAIL_ID,
  TOMAIL,
  INMAIL,
  SUBJECT,
  WCC,
  BCC,
  CONTENT,
  SENDDATE,
  FLAG_READ,
  STATUS,
  FLAG_STATUS,
  ACCOUNT_ID,
  CREATETIME,
  REMARKS,
  USERID,
  REC_ID
FROM TNSMTP_EMAIL
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int mailId)
        {
            string condition = "MAIL_ID=:MAIL_ID";
            AddParameter(_MAIL_ID, mailId);
            return SelectByCondition(condition);
        }
		public Tnsmtp_Account Get_Tnsmtp_Account_ByAccountId()
		{
			Tnsmtp_Account da=new Tnsmtp_Account();
			da.SelectByPK(AccountId);
			return da;
		}



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Email
    /// </summary>
    public partial class Tnsmtp_EmailCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_EmailCollection() { }

        public Tnsmtp_EmailCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Email(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Email().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Email._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  MAIL_ID,
  TOMAIL,
  INMAIL,
  SUBJECT,
  WCC,
  BCC,
  CONTENT,
  SENDDATE,
  FLAG_READ,
  STATUS,
  FLAG_STATUS,
  ACCOUNT_ID,
  CREATETIME,
  REMARKS,
  USERID,
  REC_ID
FROM TNSMTP_EMAIL
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByMailId(int mailId)
        {
            string condition = "MAIL_ID=:MAIL_ID";
            AddParameter(Tnsmtp_Email._MAIL_ID, mailId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_EMAIL WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Email this[int index]
        {
            get
            {
                return new Tnsmtp_Email(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Email Find(Predicate<Tnsmtp_Email> match)
        {
            foreach (Tnsmtp_Email item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_EmailCollection FindAll(Predicate<Tnsmtp_Email> match)
        {
            Tnsmtp_EmailCollection list = new Tnsmtp_EmailCollection();
            foreach (Tnsmtp_Email item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Email> match)
        {
            foreach (Tnsmtp_Email item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Email> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Email item in this)
            {
                item.ReferenceTransactionFrom(Transaction);
                if (!match(item))
                    continue;
                if (!item.Delete())
                {
                    Rollback();
                    return false;
                }
            }
            Commit();
            return true;
        }
        #endregion Linq
        #endregion
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
} 