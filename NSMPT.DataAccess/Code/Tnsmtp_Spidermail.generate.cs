/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Spidermail.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-23 20:34:47  
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
    /// Data Access Layer Object Of Tnsmtp_Spidermail
    /// </summary>
    public partial class Tnsmtp_Spidermail : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Spidermail() : base() { }

        public Tnsmtp_Spidermail(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _SPID="SPID";
		public const string _FIRSTNAME="FIRSTNAME";
		public const string _LASTNAME="LASTNAME";
		public const string _EMAIL="EMAIL";
		public const string _ADDRESS="ADDRESS";
		public const string _CITY="CITY";
		public const string _STATE="STATE";
		public const string _ZIP="ZIP";
		public const string _HOMEPHONE="HOMEPHONE";
		public const string _SOURCE="SOURCE";
		public const string _IPADDRESS="IPADDRESS";
		public const string _REGDATE="REGDATE";
		public const string _CLASS="CLASS";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";

    
        public const string _TABLENAME="Tnsmtp_Spidermail";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Spid
		{
			get { return Convert.ToInt32(DataRow[_SPID]); }
			set { setProperty(_SPID,value); }
		}
		/// <summary>
		/// 姓
		/// [default:string.Empty]
		/// </summary>
		public string Firstname
		{
			get { return DataRow[_FIRSTNAME].ToString(); }
			set { setProperty(_FIRSTNAME,value); }
		}
		/// <summary>
		/// 名
		/// [default:string.Empty]
		/// </summary>
		public string Lastname
		{
			get { return DataRow[_LASTNAME].ToString(); }
			set { setProperty(_LASTNAME,value); }
		}
		/// <summary>
		/// 邮箱
		/// [default:string.Empty]
		/// </summary>
		public string Email
		{
			get { return DataRow[_EMAIL].ToString(); }
			set { setProperty(_EMAIL,value); }
		}
		/// <summary>
		/// 地址
		/// [default:string.Empty]
		/// </summary>
		public string Address
		{
			get { return DataRow[_ADDRESS].ToString(); }
			set { setProperty(_ADDRESS,value); }
		}
		/// <summary>
		/// 城市
		/// [default:string.Empty]
		/// </summary>
		public string City
		{
			get { return DataRow[_CITY].ToString(); }
			set { setProperty(_CITY,value); }
		}
		/// <summary>
		/// 州
		/// [default:string.Empty]
		/// </summary>
		public string State
		{
			get { return DataRow[_STATE].ToString(); }
			set { setProperty(_STATE,value); }
		}
		/// <summary>
		/// 邮编
		/// [default:string.Empty]
		/// </summary>
		public string Zip
		{
			get { return DataRow[_ZIP].ToString(); }
			set { setProperty(_ZIP,value); }
		}
		/// <summary>
		/// 家庭电话
		/// [default:string.Empty]
		/// </summary>
		public string Homephone
		{
			get { return DataRow[_HOMEPHONE].ToString(); }
			set { setProperty(_HOMEPHONE,value); }
		}
		/// <summary>
		/// 来源
		/// [default:string.Empty]
		/// </summary>
		public string Source
		{
			get { return DataRow[_SOURCE].ToString(); }
			set { setProperty(_SOURCE,value); }
		}
		/// <summary>
		/// ip地址
		/// [default:string.Empty]
		/// </summary>
		public string Ipaddress
		{
			get { return DataRow[_IPADDRESS].ToString(); }
			set { setProperty(_IPADDRESS,value); }
		}
		/// <summary>
		/// 抓取时间
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Regdate
		{
			get { return Helper.ToDateTime(DataRow[_REGDATE]); }
			set { setProperty(_REGDATE,Helper.FromDateTime(value)); }
		}
		/// <summary>
		/// 邮件分类
		/// [default:0]
		/// </summary>
		public int Class
		{
			get { return Convert.ToInt32(DataRow[_CLASS]); }
			set { setProperty(_CLASS,value); }
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
		/// 入库时间
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

        #endregion 公开属性
        
        #region 私有成员
        
        protected override string TableName
        {
            get { return _TABLENAME; }
        }

        protected override DataRow BuildRow()
        {
            DataTable dt = new DataTable(_TABLENAME);
			dt.Columns.Add(_SPID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_FIRSTNAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_LASTNAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_EMAIL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_ADDRESS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CITY, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_STATE, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_ZIP, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_HOMEPHONE, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_SOURCE, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_IPADDRESS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_REGDATE, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_CLASS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_SPIDERMAIL WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int spid)
        {
            string condition = "SPID=:SPID";
            AddParameter(_SPID, spid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "SPID=:SPID";
            AddParameter(_SPID, Spid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			Spid=base.GetSequence("SELECT SEQ_TNSMTP_SPIDERMAIL.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_SPIDERMAIL(
  SPID,
  FIRSTNAME,
  LASTNAME,
  EMAIL,
  ADDRESS,
  CITY,
  STATE,
  ZIP,
  HOMEPHONE,
  SOURCE,
  IPADDRESS,
  REGDATE,
  CLASS,
  STATUS,
  REMARKS)
VALUES(
  :SPID,
  :FIRSTNAME,
  :LASTNAME,
  :EMAIL,
  :ADDRESS,
  :CITY,
  :STATE,
  :ZIP,
  :HOMEPHONE,
  :SOURCE,
  :IPADDRESS,
  :REGDATE,
  :CLASS,
  :STATUS,
  :REMARKS)";
			AddParameter(_SPID,DataRow[_SPID]);
			AddParameter(_FIRSTNAME,DataRow[_FIRSTNAME]);
			AddParameter(_LASTNAME,DataRow[_LASTNAME]);
			AddParameter(_EMAIL,DataRow[_EMAIL]);
			AddParameter(_ADDRESS,DataRow[_ADDRESS]);
			AddParameter(_CITY,DataRow[_CITY]);
			AddParameter(_STATE,DataRow[_STATE]);
			AddParameter(_ZIP,DataRow[_ZIP]);
			AddParameter(_HOMEPHONE,DataRow[_HOMEPHONE]);
			AddParameter(_SOURCE,DataRow[_SOURCE]);
			AddParameter(_IPADDRESS,DataRow[_IPADDRESS]);
			AddParameter(_REGDATE,DataRow[_REGDATE]);
			AddParameter(_CLASS,DataRow[_CLASS]);
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
            ChangePropertys.Remove(_SPID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_SPIDERMAIL SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE SPID=:SPID");
            AddParameter(_SPID, DataRow[_SPID]);
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
  SPID,
  FIRSTNAME,
  LASTNAME,
  EMAIL,
  ADDRESS,
  CITY,
  STATE,
  ZIP,
  HOMEPHONE,
  SOURCE,
  IPADDRESS,
  REGDATE,
  CLASS,
  STATUS,
  CREATETIME,
  REMARKS
FROM TNSMTP_SPIDERMAIL
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int spid)
        {
            string condition = "SPID=:SPID";
            AddParameter(_SPID, spid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Spidermail
    /// </summary>
    public partial class Tnsmtp_SpidermailCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_SpidermailCollection() { }

        public Tnsmtp_SpidermailCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Spidermail(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Spidermail().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Spidermail._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  SPID,
  FIRSTNAME,
  LASTNAME,
  EMAIL,
  ADDRESS,
  CITY,
  STATE,
  ZIP,
  HOMEPHONE,
  SOURCE,
  IPADDRESS,
  REGDATE,
  CLASS,
  STATUS,
  CREATETIME,
  REMARKS
FROM TNSMTP_SPIDERMAIL
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListBySpid(int spid)
        {
            string condition = "SPID=:SPID";
            AddParameter(Tnsmtp_Spidermail._SPID, spid);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_SPIDERMAIL WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Spidermail this[int index]
        {
            get
            {
                return new Tnsmtp_Spidermail(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Spidermail Find(Predicate<Tnsmtp_Spidermail> match)
        {
            foreach (Tnsmtp_Spidermail item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_SpidermailCollection FindAll(Predicate<Tnsmtp_Spidermail> match)
        {
            Tnsmtp_SpidermailCollection list = new Tnsmtp_SpidermailCollection();
            foreach (Tnsmtp_Spidermail item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Spidermail> match)
        {
            foreach (Tnsmtp_Spidermail item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Spidermail> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Spidermail item in this)
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