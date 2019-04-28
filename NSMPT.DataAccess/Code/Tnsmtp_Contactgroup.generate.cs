/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Contactgroup.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-04-28 17:12:41  
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
    /// Data Access Layer Object Of Tnsmtp_Contactgroup
    /// </summary>
    public partial class Tnsmtp_Contactgroup : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Contactgroup() : base() { }

        public Tnsmtp_Contactgroup(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _GID="GID";
		public const string _GROUPNAME="GROUPNAME";
		public const string _USERID="USERID";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";

    
        public const string _TABLENAME="Tnsmtp_Contactgroup";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// 联系人id
		/// [default:0]
		/// </summary>
		public int Gid
		{
			get { return Convert.ToInt32(DataRow[_GID]); }
			set { setProperty(_GID,value); }
		}
		/// <summary>
		/// 分组名称
		/// [default:string.Empty]
		/// </summary>
		public string Groupname
		{
			get { return DataRow[_GROUPNAME].ToString(); }
			set { setProperty(_GROUPNAME,value); }
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
			dt.Columns.Add(_GID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_GROUPNAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_USERID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_CONTACTGROUP WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int gid)
        {
            string condition = "GID=:GID";
            AddParameter(_GID, gid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "GID=:GID";
            AddParameter(_GID, Gid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			Gid=base.GetSequence("SELECT SEQ_TNSMTP_CONTACTGROUP.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_CONTACTGROUP(
  GID,
  GROUPNAME,
  USERID,
  STATUS,
  REMARKS)
VALUES(
  :GID,
  :GROUPNAME,
  :USERID,
  :STATUS,
  :REMARKS)";
			AddParameter(_GID,DataRow[_GID]);
			AddParameter(_GROUPNAME,DataRow[_GROUPNAME]);
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
            ChangePropertys.Remove(_GID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_CONTACTGROUP SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE GID=:GID");
            AddParameter(_GID, DataRow[_GID]);
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
  GID,
  GROUPNAME,
  USERID,
  STATUS,
  CREATETIME,
  REMARKS
FROM TNSMTP_CONTACTGROUP
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int gid)
        {
            string condition = "GID=:GID";
            AddParameter(_GID, gid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Contactgroup
    /// </summary>
    public partial class Tnsmtp_ContactgroupCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_ContactgroupCollection() { }

        public Tnsmtp_ContactgroupCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Contactgroup(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Contactgroup().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Contactgroup._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  GID,
  GROUPNAME,
  USERID,
  STATUS,
  CREATETIME,
  REMARKS
FROM TNSMTP_CONTACTGROUP
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByGid(int gid)
        {
            string condition = "GID=:GID";
            AddParameter(Tnsmtp_Contactgroup._GID, gid);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_CONTACTGROUP WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Contactgroup this[int index]
        {
            get
            {
                return new Tnsmtp_Contactgroup(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Contactgroup Find(Predicate<Tnsmtp_Contactgroup> match)
        {
            foreach (Tnsmtp_Contactgroup item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_ContactgroupCollection FindAll(Predicate<Tnsmtp_Contactgroup> match)
        {
            Tnsmtp_ContactgroupCollection list = new Tnsmtp_ContactgroupCollection();
            foreach (Tnsmtp_Contactgroup item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Contactgroup> match)
        {
            foreach (Tnsmtp_Contactgroup item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Contactgroup> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Contactgroup item in this)
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