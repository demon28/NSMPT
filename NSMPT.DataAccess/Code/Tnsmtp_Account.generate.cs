/***************************************************
*
* Data Access Layer Of Winner Framework
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
using Winner.Framework.Core;
using Winner.Framework.Core.DataAccess;
using Winner.Framework.Core.DataAccess.Oracle;
using Winner.Framework.Utils;

namespace NSMPT.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tnsmtp_Account
    /// </summary>
    public partial class Tnsmtp_Account : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Account() : base() { }

        public Tnsmtp_Account(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _AID="AID";
		public const string _ACCOUNT="ACCOUNT";
		public const string _PASSWORD="PASSWORD";
		public const string _MAIL_TYPE="MAIL_TYPE";
		public const string _USERID="USERID";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";
		public const string _ISDEFAULT="ISDEFAULT";

    
        public const string _TABLENAME="Tnsmtp_Account";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Aid
		{
			get { return Convert.ToInt32(DataRow[_AID]); }
			set { setProperty(_AID,value); }
		}
		/// <summary>
		/// 账户
		/// [default:string.Empty]
		/// </summary>
		public string Account
		{
			get { return DataRow[_ACCOUNT].ToString(); }
			set { setProperty(_ACCOUNT,value); }
		}
		/// <summary>
		/// 密码
		/// [default:string.Empty]
		/// </summary>
		public string Password
		{
			get { return DataRow[_PASSWORD].ToString(); }
			set { setProperty(_PASSWORD,value); }
		}
		/// <summary>
		/// 企业邮箱类型
		/// [default:0]
		/// </summary>
		public int MailType
		{
			get { return Convert.ToInt32(DataRow[_MAIL_TYPE]); }
			set { setProperty(_MAIL_TYPE,value); }
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
		/// 状态:0启用，1删除
		/// [default:0]
		/// </summary>
		public int Status
		{
			get { return Convert.ToInt32(DataRow[_STATUS]); }
			set { setProperty(_STATUS,value); }
		}
		/// <summary>
		/// 时间
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
		/// 0,为非默认，1为默认,
		/// [default:0]
		/// </summary>
		public int Isdefault
		{
			get { return Convert.ToInt32(DataRow[_ISDEFAULT]); }
			set { setProperty(_ISDEFAULT,value); }
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
			dt.Columns.Add(_AID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_ACCOUNT, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_PASSWORD, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_MAIL_TYPE, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_USERID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_ISDEFAULT, typeof(int)).DefaultValue = 0;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_ACCOUNT WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int aid)
        {
            string condition = "AID=:AID";
            AddParameter(_AID, aid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "AID=:AID";
            AddParameter(_AID, Aid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			Aid=base.GetSequence("SELECT SEQ_TNSMTP_ACCOUNT.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_ACCOUNT(
  AID,
  ACCOUNT,
  PASSWORD,
  MAIL_TYPE,
  USERID,
  STATUS,
  REMARKS,
  ISDEFAULT)
VALUES(
  :AID,
  :ACCOUNT,
  :PASSWORD,
  :MAIL_TYPE,
  :USERID,
  :STATUS,
  :REMARKS,
  :ISDEFAULT)";
			AddParameter(_AID,DataRow[_AID]);
			AddParameter(_ACCOUNT,DataRow[_ACCOUNT]);
			AddParameter(_PASSWORD,DataRow[_PASSWORD]);
			AddParameter(_MAIL_TYPE,DataRow[_MAIL_TYPE]);
			AddParameter(_USERID,DataRow[_USERID]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_ISDEFAULT,DataRow[_ISDEFAULT]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_AID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_ACCOUNT SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE AID=:AID");
            AddParameter(_AID, DataRow[_AID]);
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
  AID,
  ACCOUNT,
  PASSWORD,
  MAIL_TYPE,
  USERID,
  STATUS,
  CREATETIME,
  REMARKS,
  ISDEFAULT
FROM TNSMTP_ACCOUNT
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int aid)
        {
            string condition = "AID=:AID";
            AddParameter(_AID, aid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Account
    /// </summary>
    public partial class Tnsmtp_AccountCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_AccountCollection() { }

        public Tnsmtp_AccountCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Account(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Account().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Account._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  AID,
  ACCOUNT,
  PASSWORD,
  MAIL_TYPE,
  USERID,
  STATUS,
  CREATETIME,
  REMARKS,
  ISDEFAULT
FROM TNSMTP_ACCOUNT
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByAid(int aid)
        {
            string condition = "AID=:AID";
            AddParameter(Tnsmtp_Account._AID, aid);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_ACCOUNT WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Account this[int index]
        {
            get
            {
                return new Tnsmtp_Account(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Account Find(Predicate<Tnsmtp_Account> match)
        {
            foreach (Tnsmtp_Account item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_AccountCollection FindAll(Predicate<Tnsmtp_Account> match)
        {
            Tnsmtp_AccountCollection list = new Tnsmtp_AccountCollection();
            foreach (Tnsmtp_Account item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Account> match)
        {
            foreach (Tnsmtp_Account item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Account> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Account item in this)
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