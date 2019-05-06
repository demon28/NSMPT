/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Dynamicvalue.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-06 11:33:43  
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
    /// Data Access Layer Object Of Tnsmtp_Dynamicvalue
    /// </summary>
    public partial class Tnsmtp_Dynamicvalue : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Dynamicvalue() : base() { }

        public Tnsmtp_Dynamicvalue(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _DV_ID="DV_ID";
		public const string _DT_ID="DT_ID";
		public const string _DV_KEY="DV_KEY";
		public const string _DV_VALUE="DV_VALUE";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";

    
        public const string _TABLENAME="Tnsmtp_Dynamicvalue";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int DvId
		{
			get { return Convert.ToInt32(DataRow[_DV_ID]); }
			set { setProperty(_DV_ID,value); }
		}
		/// <summary>
		/// 外键动态表id
		/// [default:DBNull.Value]
		/// </summary>
		public int? DtId
		{
			get { return Helper.ToInt32(DataRow[_DT_ID]); }
			set { setProperty(_DT_ID,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// key
		/// [default:string.Empty]
		/// </summary>
		public string DvKey
		{
			get { return DataRow[_DV_KEY].ToString(); }
			set { setProperty(_DV_KEY,value); }
		}
		/// <summary>
		/// value
		/// [default:string.Empty]
		/// </summary>
		public string DvValue
		{
			get { return DataRow[_DV_VALUE].ToString(); }
			set { setProperty(_DV_VALUE,value); }
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
		/// 时间
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

        #endregion 公开属性
        
        #region 私有成员
        
        protected override string TableName
        {
            get { return _TABLENAME; }
        }

        protected override DataRow BuildRow()
        {
            DataTable dt = new DataTable(_TABLENAME);
			dt.Columns.Add(_DV_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_DT_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_DV_KEY, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_DV_VALUE, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_DYNAMICVALUE WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int dvId)
        {
            string condition = "DV_ID=:DV_ID";
            AddParameter(_DV_ID, dvId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "DV_ID=:DV_ID";
            AddParameter(_DV_ID, DvId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			DvId=base.GetSequence("SELECT SEQ_TNSMTP_DYNAMICVALUE.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_DYNAMICVALUE(
  DV_ID,
  DT_ID,
  DV_KEY,
  DV_VALUE,
  STATUS,
  REMARKS)
VALUES(
  :DV_ID,
  :DT_ID,
  :DV_KEY,
  :DV_VALUE,
  :STATUS,
  :REMARKS)";
			AddParameter(_DV_ID,DataRow[_DV_ID]);
			AddParameter(_DT_ID,DataRow[_DT_ID]);
			AddParameter(_DV_KEY,DataRow[_DV_KEY]);
			AddParameter(_DV_VALUE,DataRow[_DV_VALUE]);
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
            ChangePropertys.Remove(_DV_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_DYNAMICVALUE SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE DV_ID=:DV_ID");
            AddParameter(_DV_ID, DataRow[_DV_ID]);
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
  DV_ID,
  DT_ID,
  DV_KEY,
  DV_VALUE,
  STATUS,
  CREATETIME,
  REMARKS
FROM TNSMTP_DYNAMICVALUE
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int dvId)
        {
            string condition = "DV_ID=:DV_ID";
            AddParameter(_DV_ID, dvId);
            return SelectByCondition(condition);
        }
		public Tnsmtp_Dynamictable Get_Tnsmtp_Dynamictable_ByDtId()
		{
			Tnsmtp_Dynamictable da=new Tnsmtp_Dynamictable();
			da.SelectByPK(DtId.Value);
			return da;
		}



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Dynamicvalue
    /// </summary>
    public partial class Tnsmtp_DynamicvalueCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_DynamicvalueCollection() { }

        public Tnsmtp_DynamicvalueCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Dynamicvalue(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Dynamicvalue().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Dynamicvalue._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  DV_ID,
  DT_ID,
  DV_KEY,
  DV_VALUE,
  STATUS,
  CREATETIME,
  REMARKS
FROM TNSMTP_DYNAMICVALUE
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByDvId(int dvId)
        {
            string condition = "DV_ID=:DV_ID";
            AddParameter(Tnsmtp_Dynamicvalue._DV_ID, dvId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_DYNAMICVALUE WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Dynamicvalue this[int index]
        {
            get
            {
                return new Tnsmtp_Dynamicvalue(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Dynamicvalue Find(Predicate<Tnsmtp_Dynamicvalue> match)
        {
            foreach (Tnsmtp_Dynamicvalue item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_DynamicvalueCollection FindAll(Predicate<Tnsmtp_Dynamicvalue> match)
        {
            Tnsmtp_DynamicvalueCollection list = new Tnsmtp_DynamicvalueCollection();
            foreach (Tnsmtp_Dynamicvalue item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Dynamicvalue> match)
        {
            foreach (Tnsmtp_Dynamicvalue item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Dynamicvalue> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Dynamicvalue item in this)
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