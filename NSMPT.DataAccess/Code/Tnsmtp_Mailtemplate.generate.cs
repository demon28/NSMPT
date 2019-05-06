/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Mailtemplate.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-06 11:33:59  
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
    /// Data Access Layer Object Of Tnsmtp_Mailtemplate
    /// </summary>
    public partial class Tnsmtp_Mailtemplate : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Mailtemplate() : base() { }

        public Tnsmtp_Mailtemplate(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _MT_ID="MT_ID";
		public const string _TEMP_NAME="TEMP_NAME";
		public const string _TEMP_CONTENT="TEMP_CONTENT";
		public const string _REPLACE_ID="REPLACE_ID";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARKS="REMARKS";
		public const string _USERID="USERID";

    
        public const string _TABLENAME="Tnsmtp_Mailtemplate";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// id
		/// [default:0]
		/// </summary>
		public int MtId
		{
			get { return Convert.ToInt32(DataRow[_MT_ID]); }
			set { setProperty(_MT_ID,value); }
		}
		/// <summary>
		/// 模板名称
		/// [default:string.Empty]
		/// </summary>
		public string TempName
		{
			get { return DataRow[_TEMP_NAME].ToString(); }
			set { setProperty(_TEMP_NAME,value); }
		}
		/// <summary>
		/// 模板内容
		/// [default:string.Empty]
		/// </summary>
		public string TempContent
		{
			get { return DataRow[_TEMP_CONTENT].ToString(); }
			set { setProperty(_TEMP_CONTENT,value); }
		}
		/// <summary>
		/// 模板识别表情
		/// [default:DBNull.Value]
		/// </summary>
		public int? ReplaceId
		{
			get { return Helper.ToInt32(DataRow[_REPLACE_ID]); }
			set { setProperty(_REPLACE_ID,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 模板状态
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
			dt.Columns.Add(_MT_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_TEMP_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_TEMP_CONTENT, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_REPLACE_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_USERID, typeof(int)).DefaultValue = DBNull.Value;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_MAILTEMPLATE WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int mtId)
        {
            string condition = "MT_ID=:MT_ID";
            AddParameter(_MT_ID, mtId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "MT_ID=:MT_ID";
            AddParameter(_MT_ID, MtId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			MtId=base.GetSequence("SELECT SEQ_TNSMTP_MAILTEMPLATE.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_MAILTEMPLATE(
  MT_ID,
  TEMP_NAME,
  TEMP_CONTENT,
  REPLACE_ID,
  STATUS,
  REMARKS,
  USERID)
VALUES(
  :MT_ID,
  :TEMP_NAME,
  :TEMP_CONTENT,
  :REPLACE_ID,
  :STATUS,
  :REMARKS,
  :USERID)";
			AddParameter(_MT_ID,DataRow[_MT_ID]);
			AddParameter(_TEMP_NAME,DataRow[_TEMP_NAME]);
			AddParameter(_TEMP_CONTENT,DataRow[_TEMP_CONTENT]);
			AddParameter(_REPLACE_ID,DataRow[_REPLACE_ID]);
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
            ChangePropertys.Remove(_MT_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_MAILTEMPLATE SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE MT_ID=:MT_ID");
            AddParameter(_MT_ID, DataRow[_MT_ID]);
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
  MT_ID,
  TEMP_NAME,
  TEMP_CONTENT,
  REPLACE_ID,
  STATUS,
  CREATETIME,
  REMARKS,
  USERID
FROM TNSMTP_MAILTEMPLATE
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int mtId)
        {
            string condition = "MT_ID=:MT_ID";
            AddParameter(_MT_ID, mtId);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Mailtemplate
    /// </summary>
    public partial class Tnsmtp_MailtemplateCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_MailtemplateCollection() { }

        public Tnsmtp_MailtemplateCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Mailtemplate(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Mailtemplate().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Mailtemplate._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  MT_ID,
  TEMP_NAME,
  TEMP_CONTENT,
  REPLACE_ID,
  STATUS,
  CREATETIME,
  REMARKS,
  USERID
FROM TNSMTP_MAILTEMPLATE
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByMtId(int mtId)
        {
            string condition = "MT_ID=:MT_ID";
            AddParameter(Tnsmtp_Mailtemplate._MT_ID, mtId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_MAILTEMPLATE WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Mailtemplate this[int index]
        {
            get
            {
                return new Tnsmtp_Mailtemplate(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Mailtemplate Find(Predicate<Tnsmtp_Mailtemplate> match)
        {
            foreach (Tnsmtp_Mailtemplate item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_MailtemplateCollection FindAll(Predicate<Tnsmtp_Mailtemplate> match)
        {
            Tnsmtp_MailtemplateCollection list = new Tnsmtp_MailtemplateCollection();
            foreach (Tnsmtp_Mailtemplate item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Mailtemplate> match)
        {
            foreach (Tnsmtp_Mailtemplate item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Mailtemplate> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Mailtemplate item in this)
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