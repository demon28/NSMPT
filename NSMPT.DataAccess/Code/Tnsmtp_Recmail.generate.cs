/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Recmail.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-07 15:39:30  
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
    /// Data Access Layer Object Of Tnsmtp_Recmail
    /// </summary>
    public partial class Tnsmtp_Recmail : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Recmail() : base() { }

        public Tnsmtp_Recmail(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _RECID="RECID";
		public const string _SENDER_MAIL="SENDER_MAIL";
		public const string _SENDER_NAME="SENDER_NAME";
		public const string _RECIVER_NAME="RECIVER_NAME";
		public const string _RECIVER_MAIL="RECIVER_MAIL";
		public const string _SUBJECT="SUBJECT";
		public const string _CONTENT="CONTENT";
		public const string _FLAG_READ="FLAG_READ";
		public const string _FLAG_STATUS="FLAG_STATUS";
		public const string _ACCOUNT_ID="ACCOUNT_ID";
		public const string _USERID="USERID";
		public const string _CREATETIME="CREATETIME";
		public const string _STATUS="STATUS";
		public const string _REMARKS="REMARKS";

    
        public const string _TABLENAME="Tnsmtp_Recmail";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Recid
		{
			get { return Convert.ToInt32(DataRow[_RECID]); }
			set { setProperty(_RECID,value); }
		}
		/// <summary>
		/// 发送者邮件
		/// [default:string.Empty]
		/// </summary>
		public string SenderMail
		{
			get { return DataRow[_SENDER_MAIL].ToString(); }
			set { setProperty(_SENDER_MAIL,value); }
		}
		/// <summary>
		/// 发送者名称
		/// [default:string.Empty]
		/// </summary>
		public string SenderName
		{
			get { return DataRow[_SENDER_NAME].ToString(); }
			set { setProperty(_SENDER_NAME,value); }
		}
		/// <summary>
		/// 接收者名称
		/// [default:string.Empty]
		/// </summary>
		public string ReciverName
		{
			get { return DataRow[_RECIVER_NAME].ToString(); }
			set { setProperty(_RECIVER_NAME,value); }
		}
		/// <summary>
		/// 接收者邮件
		/// [default:string.Empty]
		/// </summary>
		public string ReciverMail
		{
			get { return DataRow[_RECIVER_MAIL].ToString(); }
			set { setProperty(_RECIVER_MAIL,value); }
		}
		/// <summary>
		/// 主题
		/// [default:string.Empty]
		/// </summary>
		public string Subject
		{
			get { return DataRow[_SUBJECT].ToString(); }
			set { setProperty(_SUBJECT,value); }
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
		/// 是否已读
		/// [default:DBNull.Value]
		/// </summary>
		public int? FlagRead
		{
			get { return Helper.ToInt32(DataRow[_FLAG_READ]); }
			set { setProperty(_FLAG_READ,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 接收状态
		/// [default:DBNull.Value]
		/// </summary>
		public int? FlagStatus
		{
			get { return Helper.ToInt32(DataRow[_FLAG_STATUS]); }
			set { setProperty(_FLAG_STATUS,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 邮件账户id
		/// [default:DBNull.Value]
		/// </summary>
		public int? AccountId
		{
			get { return Helper.ToInt32(DataRow[_ACCOUNT_ID]); }
			set { setProperty(_ACCOUNT_ID,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 用户di
		/// [default:DBNull.Value]
		/// </summary>
		public int? Userid
		{
			get { return Helper.ToInt32(DataRow[_USERID]); }
			set { setProperty(_USERID,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 时间
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Createtime
		{
			get { return Convert.ToDateTime(DataRow[_CREATETIME].ToString()); }
		}
		/// <summary>
		/// 状态
		/// [default:DBNull.Value]
		/// </summary>
		public int? Status
		{
			get { return Helper.ToInt32(DataRow[_STATUS]); }
			set { setProperty(_STATUS,Helper.FromInt32(value)); }
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

        #endregion 公开属性
        
        #region 私有成员
        
        protected override string TableName
        {
            get { return _TABLENAME; }
        }

        protected override DataRow BuildRow()
        {
            DataTable dt = new DataTable(_TABLENAME);
			dt.Columns.Add(_RECID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_SENDER_MAIL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_SENDER_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_RECIVER_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_RECIVER_MAIL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_SUBJECT, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CONTENT, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_FLAG_READ, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_FLAG_STATUS, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_ACCOUNT_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_USERID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_RECMAIL WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int recid)
        {
            string condition = "RECID=:RECID";
            AddParameter(_RECID, recid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "RECID=:RECID";
            AddParameter(_RECID, Recid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			Recid=base.GetSequence("SELECT SEQ_TNSMTP_RECMAIL.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_RECMAIL(
  RECID,
  SENDER_MAIL,
  SENDER_NAME,
  RECIVER_NAME,
  RECIVER_MAIL,
  SUBJECT,
  CONTENT,
  FLAG_READ,
  FLAG_STATUS,
  ACCOUNT_ID,
  USERID,
  STATUS,
  REMARKS)
VALUES(
  :RECID,
  :SENDER_MAIL,
  :SENDER_NAME,
  :RECIVER_NAME,
  :RECIVER_MAIL,
  :SUBJECT,
  :CONTENT,
  :FLAG_READ,
  :FLAG_STATUS,
  :ACCOUNT_ID,
  :USERID,
  :STATUS,
  :REMARKS)";
			AddParameter(_RECID,DataRow[_RECID]);
			AddParameter(_SENDER_MAIL,DataRow[_SENDER_MAIL]);
			AddParameter(_SENDER_NAME,DataRow[_SENDER_NAME]);
			AddParameter(_RECIVER_NAME,DataRow[_RECIVER_NAME]);
			AddParameter(_RECIVER_MAIL,DataRow[_RECIVER_MAIL]);
			AddParameter(_SUBJECT,DataRow[_SUBJECT]);
			AddParameter(_CONTENT,DataRow[_CONTENT]);
			AddParameter(_FLAG_READ,DataRow[_FLAG_READ]);
			AddParameter(_FLAG_STATUS,DataRow[_FLAG_STATUS]);
			AddParameter(_ACCOUNT_ID,DataRow[_ACCOUNT_ID]);
			AddParameter(_USERID,DataRow[_USERID]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_RECID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_RECMAIL SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE RECID=:RECID");
            AddParameter(_RECID, DataRow[_RECID]);
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
  RECID,
  SENDER_MAIL,
  SENDER_NAME,
  RECIVER_NAME,
  RECIVER_MAIL,
  SUBJECT,
  CONTENT,
  FLAG_READ,
  FLAG_STATUS,
  ACCOUNT_ID,
  USERID,
  CREATETIME,
  STATUS,
  REMARKS
FROM TNSMTP_RECMAIL
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int recid)
        {
            string condition = "RECID=:RECID";
            AddParameter(_RECID, recid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Recmail
    /// </summary>
    public partial class Tnsmtp_RecmailCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_RecmailCollection() { }

        public Tnsmtp_RecmailCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Recmail(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Recmail().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Recmail._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  RECID,
  SENDER_MAIL,
  SENDER_NAME,
  RECIVER_NAME,
  RECIVER_MAIL,
  SUBJECT,
  CONTENT,
  FLAG_READ,
  FLAG_STATUS,
  ACCOUNT_ID,
  USERID,
  CREATETIME,
  STATUS,
  REMARKS
FROM TNSMTP_RECMAIL
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByRecid(int recid)
        {
            string condition = "RECID=:RECID";
            AddParameter(Tnsmtp_Recmail._RECID, recid);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_RECMAIL WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Recmail this[int index]
        {
            get
            {
                return new Tnsmtp_Recmail(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Recmail Find(Predicate<Tnsmtp_Recmail> match)
        {
            foreach (Tnsmtp_Recmail item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_RecmailCollection FindAll(Predicate<Tnsmtp_Recmail> match)
        {
            Tnsmtp_RecmailCollection list = new Tnsmtp_RecmailCollection();
            foreach (Tnsmtp_Recmail item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Recmail> match)
        {
            foreach (Tnsmtp_Recmail item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Recmail> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Recmail item in this)
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