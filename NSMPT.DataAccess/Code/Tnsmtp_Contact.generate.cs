/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Contact.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-04-28 17:12:42  
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
    /// Data Access Layer Object Of Tnsmtp_Contact
    /// </summary>
    public partial class Tnsmtp_Contact : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Contact() : base() { }

        public Tnsmtp_Contact(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _CONTACT_ID="CONTACT_ID";
		public const string _CONTACT_NAME="CONTACT_NAME";
		public const string _EMAIL="EMAIL";
		public const string _TEL="TEL";
		public const string _CATE_ID="CATE_ID";
		public const string _ACCOUNT_ID="ACCOUNT_ID";
		public const string _USER_ID="USER_ID";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";
		public const string _GID="GID";

    
        public const string _TABLENAME="Tnsmtp_Contact";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int ContactId
		{
			get { return Convert.ToInt32(DataRow[_CONTACT_ID]); }
			set { setProperty(_CONTACT_ID,value); }
		}
		/// <summary>
		/// 姓名
		/// [default:string.Empty]
		/// </summary>
		public string ContactName
		{
			get { return DataRow[_CONTACT_NAME].ToString(); }
			set { setProperty(_CONTACT_NAME,value); }
		}
		/// <summary>
		/// email
		/// [default:string.Empty]
		/// </summary>
		public string Email
		{
			get { return DataRow[_EMAIL].ToString(); }
			set { setProperty(_EMAIL,value); }
		}
		/// <summary>
		/// 电话
		/// [default:string.Empty]
		/// </summary>
		public string Tel
		{
			get { return DataRow[_TEL].ToString(); }
			set { setProperty(_TEL,value); }
		}
		/// <summary>
		/// 类型id，冗余
		/// [default:DBNull.Value]
		/// </summary>
		public int? CateId
		{
			get { return Helper.ToInt32(DataRow[_CATE_ID]); }
			set { setProperty(_CATE_ID,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 账户id，冗余
		/// [default:DBNull.Value]
		/// </summary>
		public int? AccountId
		{
			get { return Helper.ToInt32(DataRow[_ACCOUNT_ID]); }
			set { setProperty(_ACCOUNT_ID,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 用户id
		/// [default:DBNull.Value]
		/// </summary>
		public int? UserId
		{
			get { return Helper.ToInt32(DataRow[_USER_ID]); }
			set { setProperty(_USER_ID,Helper.FromInt32(value)); }
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
		/// 分组id
		/// [default:DBNull.Value]
		/// </summary>
		public int? Gid
		{
			get { return Helper.ToInt32(DataRow[_GID]); }
			set { setProperty(_GID,Helper.FromInt32(value)); }
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
			dt.Columns.Add(_CONTACT_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_CONTACT_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_EMAIL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_TEL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CATE_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_ACCOUNT_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_USER_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_GID, typeof(int)).DefaultValue = DBNull.Value;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_CONTACT WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int contactId)
        {
            string condition = "CONTACT_ID=:CONTACT_ID";
            AddParameter(_CONTACT_ID, contactId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "CONTACT_ID=:CONTACT_ID";
            AddParameter(_CONTACT_ID, ContactId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			ContactId=base.GetSequence("SELECT SEQ_TNSMTP_CONTACT.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_CONTACT(
  CONTACT_ID,
  CONTACT_NAME,
  EMAIL,
  TEL,
  CATE_ID,
  ACCOUNT_ID,
  USER_ID,
  STATUS,
  REMARKS,
  GID)
VALUES(
  :CONTACT_ID,
  :CONTACT_NAME,
  :EMAIL,
  :TEL,
  :CATE_ID,
  :ACCOUNT_ID,
  :USER_ID,
  :STATUS,
  :REMARKS,
  :GID)";
			AddParameter(_CONTACT_ID,DataRow[_CONTACT_ID]);
			AddParameter(_CONTACT_NAME,DataRow[_CONTACT_NAME]);
			AddParameter(_EMAIL,DataRow[_EMAIL]);
			AddParameter(_TEL,DataRow[_TEL]);
			AddParameter(_CATE_ID,DataRow[_CATE_ID]);
			AddParameter(_ACCOUNT_ID,DataRow[_ACCOUNT_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_GID,DataRow[_GID]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_CONTACT_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_CONTACT SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE CONTACT_ID=:CONTACT_ID");
            AddParameter(_CONTACT_ID, DataRow[_CONTACT_ID]);
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
  CONTACT_ID,
  CONTACT_NAME,
  EMAIL,
  TEL,
  CATE_ID,
  ACCOUNT_ID,
  USER_ID,
  STATUS,
  CREATETIME,
  REMARKS,
  GID
FROM TNSMTP_CONTACT
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int contactId)
        {
            string condition = "CONTACT_ID=:CONTACT_ID";
            AddParameter(_CONTACT_ID, contactId);
            return SelectByCondition(condition);
        }
		public Tnsmtp_Contactgroup Get_Tnsmtp_Contactgroup_ByGid()
		{
			Tnsmtp_Contactgroup da=new Tnsmtp_Contactgroup();
			da.SelectByPK(Gid.Value);
			return da;
		}



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Contact
    /// </summary>
    public partial class Tnsmtp_ContactCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_ContactCollection() { }

        public Tnsmtp_ContactCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Contact(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Contact().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Contact._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  CONTACT_ID,
  CONTACT_NAME,
  EMAIL,
  TEL,
  CATE_ID,
  ACCOUNT_ID,
  USER_ID,
  STATUS,
  CREATETIME,
  REMARKS,
  GID
FROM TNSMTP_CONTACT
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByContactId(int contactId)
        {
            string condition = "CONTACT_ID=:CONTACT_ID";
            AddParameter(Tnsmtp_Contact._CONTACT_ID, contactId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_CONTACT WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Contact this[int index]
        {
            get
            {
                return new Tnsmtp_Contact(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Contact Find(Predicate<Tnsmtp_Contact> match)
        {
            foreach (Tnsmtp_Contact item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_ContactCollection FindAll(Predicate<Tnsmtp_Contact> match)
        {
            Tnsmtp_ContactCollection list = new Tnsmtp_ContactCollection();
            foreach (Tnsmtp_Contact item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Contact> match)
        {
            foreach (Tnsmtp_Contact item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Contact> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Contact item in this)
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