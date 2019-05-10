/***************************************************
*
* Data Access Layer Of Winner Framework
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
using Winner.Framework.Core;
using Winner.Framework.Core.DataAccess;
using Winner.Framework.Core.DataAccess.Oracle;
using Winner.Framework.Utils;

namespace NSMPT.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Attachment
    /// </summary>
    public partial class Tnsmtp_Attachment : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Attachment() : base() { }

        public Tnsmtp_Attachment(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _AT_ID="AT_ID";
		public const string _FILE_URL="FILE_URL";
		public const string _FILE_NAME="FILE_NAME";
		public const string _MAIL_ID="MAIL_ID";
		public const string _TEMP_ID="TEMP_ID";
		public const string _ACCOUNT_ID="ACCOUNT_ID";
		public const string _USER_ID="USER_ID";
		public const string _FILE_ID="FILE_ID";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";
		public const string _FILE_SIZE="FILE_SIZE";

    
        public const string _TABLENAME="Tnsmtp_Attachment";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// 附件id
		/// [default:0]
		/// </summary>
		public int AtId
		{
			get { return Convert.ToInt32(DataRow[_AT_ID]); }
			set { setProperty(_AT_ID,value); }
		}
		/// <summary>
		/// 附件路径
		/// [default:string.Empty]
		/// </summary>
		public string FileUrl
		{
			get { return DataRow[_FILE_URL].ToString(); }
			set { setProperty(_FILE_URL,value); }
		}
		/// <summary>
		/// 文件名
		/// [default:string.Empty]
		/// </summary>
		public string FileName
		{
			get { return DataRow[_FILE_NAME].ToString(); }
			set { setProperty(_FILE_NAME,value); }
		}
		/// <summary>
		/// 邮件id，外键邮件表
		/// [default:0]
		/// </summary>
		public int MailId
		{
			get { return Convert.ToInt32(DataRow[_MAIL_ID]); }
			set { setProperty(_MAIL_ID,value); }
		}
		/// <summary>
		/// 临时的保存标识
		/// [default:DBNull.Value]
		/// </summary>
		public int? TempId
		{
			get { return Helper.ToInt32(DataRow[_TEMP_ID]); }
			set { setProperty(_TEMP_ID,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 邮件账户id，外键邮箱账户表
		/// [default:0]
		/// </summary>
		public int AccountId
		{
			get { return Convert.ToInt32(DataRow[_ACCOUNT_ID]); }
			set { setProperty(_ACCOUNT_ID,value); }
		}
		/// <summary>
		/// 用户id，外键系统用户表
		/// [default:0]
		/// </summary>
		public int UserId
		{
			get { return Convert.ToInt32(DataRow[_USER_ID]); }
			set { setProperty(_USER_ID,value); }
		}
		/// <summary>
		/// 文件id，如有文件系统，外键文件系统表
		/// [default:DBNull.Value]
		/// </summary>
		public int? FileId
		{
			get { return Helper.ToInt32(DataRow[_FILE_ID]); }
			set { setProperty(_FILE_ID,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 状态
		/// [default:0]
		/// </summary>
		public int Status
		{
			get { return Convert.ToInt32(DataRow[_STATUS]); }
			set { setProperty(_STATUS,value); }
		}
		/// <summary>
		/// 创建时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime Createtime
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
		/// 文件大小
		/// [default:string.Empty]
		/// </summary>
		public string FileSize
		{
			get { return DataRow[_FILE_SIZE].ToString(); }
			set { setProperty(_FILE_SIZE,value); }
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
			dt.Columns.Add(_AT_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_FILE_URL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_FILE_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_MAIL_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_TEMP_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_ACCOUNT_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_USER_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_FILE_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_FILE_SIZE, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_ATTACHMENT WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int atId)
        {
            string condition = "AT_ID=:AT_ID";
            AddParameter(_AT_ID, atId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "AT_ID=:AT_ID";
            AddParameter(_AT_ID, AtId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			AtId=base.GetSequence("SELECT SEQ_TNSMTP_ATTACHMENT.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_ATTACHMENT(
  AT_ID,
  FILE_URL,
  FILE_NAME,
  MAIL_ID,
  TEMP_ID,
  ACCOUNT_ID,
  USER_ID,
  FILE_ID,
  STATUS,
  REMARKS,
  FILE_SIZE)
VALUES(
  :AT_ID,
  :FILE_URL,
  :FILE_NAME,
  :MAIL_ID,
  :TEMP_ID,
  :ACCOUNT_ID,
  :USER_ID,
  :FILE_ID,
  :STATUS,
  :REMARKS,
  :FILE_SIZE)";
			AddParameter(_AT_ID,DataRow[_AT_ID]);
			AddParameter(_FILE_URL,DataRow[_FILE_URL]);
			AddParameter(_FILE_NAME,DataRow[_FILE_NAME]);
			AddParameter(_MAIL_ID,DataRow[_MAIL_ID]);
			AddParameter(_TEMP_ID,DataRow[_TEMP_ID]);
			AddParameter(_ACCOUNT_ID,DataRow[_ACCOUNT_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_FILE_ID,DataRow[_FILE_ID]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_FILE_SIZE,DataRow[_FILE_SIZE]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_AT_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_ATTACHMENT SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE AT_ID=:AT_ID");
            AddParameter(_AT_ID, DataRow[_AT_ID]);
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
  AT_ID,
  FILE_URL,
  FILE_NAME,
  MAIL_ID,
  TEMP_ID,
  ACCOUNT_ID,
  USER_ID,
  FILE_ID,
  STATUS,
  CREATETIME,
  REMARKS,
  FILE_SIZE
FROM TNSMTP_ATTACHMENT
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int atId)
        {
            string condition = "AT_ID=:AT_ID";
            AddParameter(_AT_ID, atId);
            return SelectByCondition(condition);
        }
		public Tnsmtp_Account Get_Tnsmtp_Account_ByAccountId()
		{
			Tnsmtp_Account da=new Tnsmtp_Account();
			da.SelectByPK(AccountId);
			return da;
		}
		public Tnsmtp_Email Get_Tnsmtp_Email_ByMailId()
		{
			Tnsmtp_Email da=new Tnsmtp_Email();
			da.SelectByPK(MailId);
			return da;
		}



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Attachment
    /// </summary>
    public partial class Tnsmtp_AttachmentCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_AttachmentCollection() { }

        public Tnsmtp_AttachmentCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Attachment(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Attachment().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Attachment._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  AT_ID,
  FILE_URL,
  FILE_NAME,
  MAIL_ID,
  TEMP_ID,
  ACCOUNT_ID,
  USER_ID,
  FILE_ID,
  STATUS,
  CREATETIME,
  REMARKS,
  FILE_SIZE
FROM TNSMTP_ATTACHMENT
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByAtId(int atId)
        {
            string condition = "AT_ID=:AT_ID";
            AddParameter(Tnsmtp_Attachment._AT_ID, atId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_ATTACHMENT WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Attachment this[int index]
        {
            get
            {
                return new Tnsmtp_Attachment(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Attachment Find(Predicate<Tnsmtp_Attachment> match)
        {
            foreach (Tnsmtp_Attachment item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_AttachmentCollection FindAll(Predicate<Tnsmtp_Attachment> match)
        {
            Tnsmtp_AttachmentCollection list = new Tnsmtp_AttachmentCollection();
            foreach (Tnsmtp_Attachment item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Attachment> match)
        {
            foreach (Tnsmtp_Attachment item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Attachment> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Attachment item in this)
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