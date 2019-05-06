/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Raplcemark.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-06 12:02:57  
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
    /// Data Access Layer Object Of Tnsmtp_Raplcemark
    /// </summary>
    public partial class Tnsmtp_Raplcemark : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Raplcemark() : base() { }

        public Tnsmtp_Raplcemark(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _RID="RID";
		public const string _MARK_NAME="MARK_NAME";
		public const string _MARK_VALUE="MARK_VALUE";
		public const string _MARK_TYPE="MARK_TYPE";
		public const string _TABLE_ID="TABLE_ID";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";
		public const string _USERID="USERID";

    
        public const string _TABLENAME="Tnsmtp_Raplcemark";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int Rid
		{
			get { return Convert.ToInt32(DataRow[_RID]); }
			set { setProperty(_RID,value); }
		}
		/// <summary>
		/// 标签名称
		/// [default:string.Empty]
		/// </summary>
		public string MarkName
		{
			get { return DataRow[_MARK_NAME].ToString(); }
			set { setProperty(_MARK_NAME,value); }
		}
		/// <summary>
		/// 标签值
		/// [default:string.Empty]
		/// </summary>
		public string MarkValue
		{
			get { return DataRow[_MARK_VALUE].ToString(); }
			set { setProperty(_MARK_VALUE,value); }
		}
		/// <summary>
		/// 标签类型0，公共标签，1私有标签
		/// [default:0]
		/// </summary>
		public int MarkType
		{
			get { return Convert.ToInt32(DataRow[_MARK_TYPE]); }
			set { setProperty(_MARK_TYPE,value); }
		}
		/// <summary>
		/// mark对应的动态表
		/// [default:DBNull.Value]
		/// </summary>
		public int? TableId
		{
			get { return Helper.ToInt32(DataRow[_TABLE_ID]); }
			set { setProperty(_TABLE_ID,Helper.FromInt32(value)); }
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
		/// <summary>
		/// 用户id
		/// [default:DBNull.Value]
		/// </summary>
		public int? Userid
		{
			get { return Helper.ToInt32(DataRow[_USERID]); }
			set { setProperty(_USERID,Helper.FromInt32(value)); }
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
			dt.Columns.Add(_RID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_MARK_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_MARK_VALUE, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_MARK_TYPE, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_TABLE_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_USERID, typeof(int)).DefaultValue = DBNull.Value;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_RAPLCEMARK WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int rid)
        {
            string condition = "RID=:RID";
            AddParameter(_RID, rid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "RID=:RID";
            AddParameter(_RID, Rid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			Rid=base.GetSequence("SELECT SEQ_TNSMTP_RAPLCEMARK.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_RAPLCEMARK(
  RID,
  MARK_NAME,
  MARK_VALUE,
  MARK_TYPE,
  TABLE_ID,
  STATUS,
  REMARKS,
  USERID)
VALUES(
  :RID,
  :MARK_NAME,
  :MARK_VALUE,
  :MARK_TYPE,
  :TABLE_ID,
  :STATUS,
  :REMARKS,
  :USERID)";
			AddParameter(_RID,DataRow[_RID]);
			AddParameter(_MARK_NAME,DataRow[_MARK_NAME]);
			AddParameter(_MARK_VALUE,DataRow[_MARK_VALUE]);
			AddParameter(_MARK_TYPE,DataRow[_MARK_TYPE]);
			AddParameter(_TABLE_ID,DataRow[_TABLE_ID]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_USERID,DataRow[_USERID]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_RID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_RAPLCEMARK SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE RID=:RID");
            AddParameter(_RID, DataRow[_RID]);
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
  RID,
  MARK_NAME,
  MARK_VALUE,
  MARK_TYPE,
  TABLE_ID,
  STATUS,
  CREATETIME,
  REMARKS,
  USERID
FROM TNSMTP_RAPLCEMARK
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int rid)
        {
            string condition = "RID=:RID";
            AddParameter(_RID, rid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Raplcemark
    /// </summary>
    public partial class Tnsmtp_RaplcemarkCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_RaplcemarkCollection() { }

        public Tnsmtp_RaplcemarkCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Raplcemark(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Raplcemark().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Raplcemark._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  RID,
  MARK_NAME,
  MARK_VALUE,
  MARK_TYPE,
  TABLE_ID,
  STATUS,
  CREATETIME,
  REMARKS,
  USERID
FROM TNSMTP_RAPLCEMARK
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByRid(int rid)
        {
            string condition = "RID=:RID";
            AddParameter(Tnsmtp_Raplcemark._RID, rid);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_RAPLCEMARK WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Raplcemark this[int index]
        {
            get
            {
                return new Tnsmtp_Raplcemark(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Raplcemark Find(Predicate<Tnsmtp_Raplcemark> match)
        {
            foreach (Tnsmtp_Raplcemark item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_RaplcemarkCollection FindAll(Predicate<Tnsmtp_Raplcemark> match)
        {
            Tnsmtp_RaplcemarkCollection list = new Tnsmtp_RaplcemarkCollection();
            foreach (Tnsmtp_Raplcemark item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Raplcemark> match)
        {
            foreach (Tnsmtp_Raplcemark item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Raplcemark> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Raplcemark item in this)
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