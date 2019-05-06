/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Dynamictable.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-06 11:33:27  
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
    /// Data Access Layer Object Of Tnsmtp_Dynamictable
    /// </summary>
    public partial class Tnsmtp_Dynamictable : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Dynamictable() : base() { }

        public Tnsmtp_Dynamictable(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _DT_ID="DT_ID";
		public const string _DT_NAME="DT_NAME";
		public const string _DT_CODE="DT_CODE";
		public const string _DT_TYPE="DT_TYPE";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";

    
        public const string _TABLENAME="Tnsmtp_Dynamictable";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int DtId
		{
			get { return Convert.ToInt32(DataRow[_DT_ID]); }
			set { setProperty(_DT_ID,value); }
		}
		/// <summary>
		/// 表名
		/// [default:string.Empty]
		/// </summary>
		public string DtName
		{
			get { return DataRow[_DT_NAME].ToString(); }
			set { setProperty(_DT_NAME,value); }
		}
		/// <summary>
		/// 表代码
		/// [default:string.Empty]
		/// </summary>
		public string DtCode
		{
			get { return DataRow[_DT_CODE].ToString(); }
			set { setProperty(_DT_CODE,value); }
		}
		/// <summary>
		/// 表类型，0公共表，1私有表
		/// [default:DBNull.Value]
		/// </summary>
		public int? DtType
		{
			get { return Helper.ToInt32(DataRow[_DT_TYPE]); }
			set { setProperty(_DT_TYPE,Helper.FromInt32(value)); }
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

        #endregion 公开属性
        
        #region 私有成员
        
        protected override string TableName
        {
            get { return _TABLENAME; }
        }

        protected override DataRow BuildRow()
        {
            DataTable dt = new DataTable(_TABLENAME);
			dt.Columns.Add(_DT_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_DT_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_DT_CODE, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_DT_TYPE, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_DYNAMICTABLE WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int dtId)
        {
            string condition = "DT_ID=:DT_ID";
            AddParameter(_DT_ID, dtId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "DT_ID=:DT_ID";
            AddParameter(_DT_ID, DtId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			DtId=base.GetSequence("SELECT SEQ_TNSMTP_DYNAMICTABLE.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_DYNAMICTABLE(
  DT_ID,
  DT_NAME,
  DT_CODE,
  DT_TYPE,
  STATUS,
  REMARKS)
VALUES(
  :DT_ID,
  :DT_NAME,
  :DT_CODE,
  :DT_TYPE,
  :STATUS,
  :REMARKS)";
			AddParameter(_DT_ID,DataRow[_DT_ID]);
			AddParameter(_DT_NAME,DataRow[_DT_NAME]);
			AddParameter(_DT_CODE,DataRow[_DT_CODE]);
			AddParameter(_DT_TYPE,DataRow[_DT_TYPE]);
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
            ChangePropertys.Remove(_DT_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_DYNAMICTABLE SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE DT_ID=:DT_ID");
            AddParameter(_DT_ID, DataRow[_DT_ID]);
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
  DT_ID,
  DT_NAME,
  DT_CODE,
  DT_TYPE,
  STATUS,
  CREATETIME,
  REMARKS
FROM TNSMTP_DYNAMICTABLE
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int dtId)
        {
            string condition = "DT_ID=:DT_ID";
            AddParameter(_DT_ID, dtId);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Dynamictable
    /// </summary>
    public partial class Tnsmtp_DynamictableCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_DynamictableCollection() { }

        public Tnsmtp_DynamictableCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Dynamictable(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Dynamictable().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Dynamictable._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  DT_ID,
  DT_NAME,
  DT_CODE,
  DT_TYPE,
  STATUS,
  CREATETIME,
  REMARKS
FROM TNSMTP_DYNAMICTABLE
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByDtId(int dtId)
        {
            string condition = "DT_ID=:DT_ID";
            AddParameter(Tnsmtp_Dynamictable._DT_ID, dtId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_DYNAMICTABLE WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Dynamictable this[int index]
        {
            get
            {
                return new Tnsmtp_Dynamictable(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Dynamictable Find(Predicate<Tnsmtp_Dynamictable> match)
        {
            foreach (Tnsmtp_Dynamictable item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_DynamictableCollection FindAll(Predicate<Tnsmtp_Dynamictable> match)
        {
            Tnsmtp_DynamictableCollection list = new Tnsmtp_DynamictableCollection();
            foreach (Tnsmtp_Dynamictable item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Dynamictable> match)
        {
            foreach (Tnsmtp_Dynamictable item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Dynamictable> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Dynamictable item in this)
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