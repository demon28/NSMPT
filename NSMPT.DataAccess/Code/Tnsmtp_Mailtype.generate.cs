/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Mailtype.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-15 19:18:19  
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
    /// Data Access Layer Object Of Tnsmtp_Mailtype
    /// </summary>
    public partial class Tnsmtp_Mailtype : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Mailtype() : base() { }

        public Tnsmtp_Mailtype(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _MTID="MTID";
		public const string _MAILNAME="MAILNAME";
		public const string _SMTP_URL="SMTP_URL";
		public const string _SMTP_PORT="SMTP_PORT";
		public const string _SMTP_SSL="SMTP_SSL";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";
		public const string _POP_URL="POP_URL";
		public const string _POP_PORT="POP_PORT";

    
        public const string _TABLENAME="Tnsmtp_Mailtype";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Mtid
		{
			get { return Convert.ToInt32(DataRow[_MTID]); }
			set { setProperty(_MTID,value); }
		}
		/// <summary>
		/// 企业邮箱名称，腾讯企业邮箱，163企业邮箱
		/// [default:string.Empty]
		/// </summary>
		public string Mailname
		{
			get { return DataRow[_MAILNAME].ToString(); }
			set { setProperty(_MAILNAME,value); }
		}
		/// <summary>
		/// 邮箱smtp地址: stmp.exmail.qq.com
		/// [default:string.Empty]
		/// </summary>
		public string SmtpUrl
		{
			get { return DataRow[_SMTP_URL].ToString(); }
			set { setProperty(_SMTP_URL,value); }
		}
		/// <summary>
		/// 邮箱端口:25
		/// [default:DBNull.Value]
		/// </summary>
		public int? SmtpPort
		{
			get { return Helper.ToInt32(DataRow[_SMTP_PORT]); }
			set { setProperty(_SMTP_PORT,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// SSL邮箱端口：465
		/// [default:DBNull.Value]
		/// </summary>
		public int? SmtpSsl
		{
			get { return Helper.ToInt32(DataRow[_SMTP_SSL]); }
			set { setProperty(_SMTP_SSL,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 状态：0启动，1不启用
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
		/// POP3收件地址
		/// [default:string.Empty]
		/// </summary>
		public string PopUrl
		{
			get { return DataRow[_POP_URL].ToString(); }
			set { setProperty(_POP_URL,value); }
		}
		/// <summary>
		/// POP3收件端口
		/// [default:string.Empty]
		/// </summary>
		public string PopPort
		{
			get { return DataRow[_POP_PORT].ToString(); }
			set { setProperty(_POP_PORT,value); }
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
			dt.Columns.Add(_MTID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_MAILNAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_SMTP_URL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_SMTP_PORT, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_SMTP_SSL, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_POP_URL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_POP_PORT, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_MAILTYPE WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int mtid)
        {
            string condition = "MTID=:MTID";
            AddParameter(_MTID, mtid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "MTID=:MTID";
            AddParameter(_MTID, Mtid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			Mtid=base.GetSequence("SELECT SEQ_TNSMTP_MAILTYPE.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_MAILTYPE(
  MTID,
  MAILNAME,
  SMTP_URL,
  SMTP_PORT,
  SMTP_SSL,
  STATUS,
  REMARKS,
  POP_URL,
  POP_PORT)
VALUES(
  :MTID,
  :MAILNAME,
  :SMTP_URL,
  :SMTP_PORT,
  :SMTP_SSL,
  :STATUS,
  :REMARKS,
  :POP_URL,
  :POP_PORT)";
			AddParameter(_MTID,DataRow[_MTID]);
			AddParameter(_MAILNAME,DataRow[_MAILNAME]);
			AddParameter(_SMTP_URL,DataRow[_SMTP_URL]);
			AddParameter(_SMTP_PORT,DataRow[_SMTP_PORT]);
			AddParameter(_SMTP_SSL,DataRow[_SMTP_SSL]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_POP_URL,DataRow[_POP_URL]);
			AddParameter(_POP_PORT,DataRow[_POP_PORT]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_MTID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_MAILTYPE SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE MTID=:MTID");
            AddParameter(_MTID, DataRow[_MTID]);
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
  MTID,
  MAILNAME,
  SMTP_URL,
  SMTP_PORT,
  SMTP_SSL,
  STATUS,
  CREATETIME,
  REMARKS,
  POP_URL,
  POP_PORT
FROM TNSMTP_MAILTYPE
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int mtid)
        {
            string condition = "MTID=:MTID";
            AddParameter(_MTID, mtid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Mailtype
    /// </summary>
    public partial class Tnsmtp_MailtypeCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_MailtypeCollection() { }

        public Tnsmtp_MailtypeCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Mailtype(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Mailtype().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Mailtype._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  MTID,
  MAILNAME,
  SMTP_URL,
  SMTP_PORT,
  SMTP_SSL,
  STATUS,
  CREATETIME,
  REMARKS,
  POP_URL,
  POP_PORT
FROM TNSMTP_MAILTYPE
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByMtid(int mtid)
        {
            string condition = "MTID=:MTID";
            AddParameter(Tnsmtp_Mailtype._MTID, mtid);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_MAILTYPE WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Mailtype this[int index]
        {
            get
            {
                return new Tnsmtp_Mailtype(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Mailtype Find(Predicate<Tnsmtp_Mailtype> match)
        {
            foreach (Tnsmtp_Mailtype item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_MailtypeCollection FindAll(Predicate<Tnsmtp_Mailtype> match)
        {
            Tnsmtp_MailtypeCollection list = new Tnsmtp_MailtypeCollection();
            foreach (Tnsmtp_Mailtype item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Mailtype> match)
        {
            foreach (Tnsmtp_Mailtype item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Mailtype> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Mailtype item in this)
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