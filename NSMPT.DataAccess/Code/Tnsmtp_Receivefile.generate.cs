/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnsmtp_Receivefile.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2019-05-16 18:16:47  
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
    /// Data Access Layer Object Of Tnsmtp_Receivefile
    /// </summary>
    public partial class Tnsmtp_Receivefile : DataAccessBase
    {
        #region 默认构造

        public Tnsmtp_Receivefile() : base() { }

        public Tnsmtp_Receivefile(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _RECFILE_ID="RECFILE_ID";
		public const string _REC_MAILID="REC_MAILID";
		public const string _FILENAME="FILENAME";
		public const string _DOWNLOADURL="DOWNLOADURL";
		public const string _ACCOUNTID="ACCOUNTID";
		public const string _USERID="USERID";
		public const string _STATUS="STATUS";
		public const string _CREATETIME="CREATETIME";
		public const string _REMARK="REMARK";
		public const string _FILEURL="FILEURL";
		public const string _FILESIZE="FILESIZE";

    
        public const string _TABLENAME="Tnsmtp_Receivefile";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// 主键
		/// [default:0]
		/// </summary>
		public int RecfileId
		{
			get { return Convert.ToInt32(DataRow[_RECFILE_ID]); }
			set { setProperty(_RECFILE_ID,value); }
		}
		/// <summary>
		/// 归属邮件id
		/// [default:0]
		/// </summary>
		public int RecMailid
		{
			get { return Convert.ToInt32(DataRow[_REC_MAILID]); }
			set { setProperty(_REC_MAILID,value); }
		}
		/// <summary>
		/// 文件名
		/// [default:string.Empty]
		/// </summary>
		public string Filename
		{
			get { return DataRow[_FILENAME].ToString(); }
			set { setProperty(_FILENAME,value); }
		}
		/// <summary>
		/// 文件下载地址
		/// [default:string.Empty]
		/// </summary>
		public string Downloadurl
		{
			get { return DataRow[_DOWNLOADURL].ToString(); }
			set { setProperty(_DOWNLOADURL,value); }
		}
		/// <summary>
		/// 账户id
		/// [default:0]
		/// </summary>
		public int Accountid
		{
			get { return Convert.ToInt32(DataRow[_ACCOUNTID]); }
			set { setProperty(_ACCOUNTID,value); }
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
		public string Remark
		{
			get { return DataRow[_REMARK].ToString(); }
			set { setProperty(_REMARK,value); }
		}
		/// <summary>
		/// 文件本地路径
		/// [default:string.Empty]
		/// </summary>
		public string Fileurl
		{
			get { return DataRow[_FILEURL].ToString(); }
			set { setProperty(_FILEURL,value); }
		}
		/// <summary>
		/// 文件大小
		/// [default:DBNull.Value]
		/// </summary>
		public int? Filesize
		{
			get { return Helper.ToInt32(DataRow[_FILESIZE]); }
			set { setProperty(_FILESIZE,Helper.FromInt32(value)); }
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
			dt.Columns.Add(_RECFILE_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_REC_MAILID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_FILENAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_DOWNLOADURL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_ACCOUNTID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_USERID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_REMARK, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_FILEURL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_FILESIZE, typeof(int)).DefaultValue = DBNull.Value;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNSMTP_RECEIVEFILE WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int recfileId)
        {
            string condition = "RECFILE_ID=:RECFILE_ID";
            AddParameter(_RECFILE_ID, recfileId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "RECFILE_ID=:RECFILE_ID";
            AddParameter(_RECFILE_ID, RecfileId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			RecfileId=base.GetSequence("SELECT SEQ_TNSMTP_RECEIVEFILE.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNSMTP_RECEIVEFILE(
  RECFILE_ID,
  REC_MAILID,
  FILENAME,
  DOWNLOADURL,
  ACCOUNTID,
  USERID,
  STATUS,
  REMARK,
  FILEURL,
  FILESIZE)
VALUES(
  :RECFILE_ID,
  :REC_MAILID,
  :FILENAME,
  :DOWNLOADURL,
  :ACCOUNTID,
  :USERID,
  :STATUS,
  :REMARK,
  :FILEURL,
  :FILESIZE)";
			AddParameter(_RECFILE_ID,DataRow[_RECFILE_ID]);
			AddParameter(_REC_MAILID,DataRow[_REC_MAILID]);
			AddParameter(_FILENAME,DataRow[_FILENAME]);
			AddParameter(_DOWNLOADURL,DataRow[_DOWNLOADURL]);
			AddParameter(_ACCOUNTID,DataRow[_ACCOUNTID]);
			AddParameter(_USERID,DataRow[_USERID]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARK,DataRow[_REMARK]);
			AddParameter(_FILEURL,DataRow[_FILEURL]);
			AddParameter(_FILESIZE,DataRow[_FILESIZE]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_RECFILE_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNSMTP_RECEIVEFILE SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE RECFILE_ID=:RECFILE_ID");
            AddParameter(_RECFILE_ID, DataRow[_RECFILE_ID]);
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
  RECFILE_ID,
  REC_MAILID,
  FILENAME,
  DOWNLOADURL,
  ACCOUNTID,
  USERID,
  STATUS,
  CREATETIME,
  REMARK,
  FILEURL,
  FILESIZE
FROM TNSMTP_RECEIVEFILE
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int recfileId)
        {
            string condition = "RECFILE_ID=:RECFILE_ID";
            AddParameter(_RECFILE_ID, recfileId);
            return SelectByCondition(condition);
        }
		public Tnsmtp_Recmail Get_Tnsmtp_Recmail_ByRecMailid()
		{
			Tnsmtp_Recmail da=new Tnsmtp_Recmail();
			da.SelectByPK(RecMailid);
			return da;
		}



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnsmtp_Receivefile
    /// </summary>
    public partial class Tnsmtp_ReceivefileCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnsmtp_ReceivefileCollection() { }

        public Tnsmtp_ReceivefileCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnsmtp_Receivefile(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnsmtp_Receivefile().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnsmtp_Receivefile._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  RECFILE_ID,
  REC_MAILID,
  FILENAME,
  DOWNLOADURL,
  ACCOUNTID,
  USERID,
  STATUS,
  CREATETIME,
  REMARK,
  FILEURL,
  FILESIZE
FROM TNSMTP_RECEIVEFILE
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByRecfileId(int recfileId)
        {
            string condition = "RECFILE_ID=:RECFILE_ID";
            AddParameter(Tnsmtp_Receivefile._RECFILE_ID, recfileId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNSMTP_RECEIVEFILE WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnsmtp_Receivefile this[int index]
        {
            get
            {
                return new Tnsmtp_Receivefile(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnsmtp_Receivefile Find(Predicate<Tnsmtp_Receivefile> match)
        {
            foreach (Tnsmtp_Receivefile item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnsmtp_ReceivefileCollection FindAll(Predicate<Tnsmtp_Receivefile> match)
        {
            Tnsmtp_ReceivefileCollection list = new Tnsmtp_ReceivefileCollection();
            foreach (Tnsmtp_Receivefile item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnsmtp_Receivefile> match)
        {
            foreach (Tnsmtp_Receivefile item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnsmtp_Receivefile> match)
        {
            BeginTransaction();
            foreach (Tnsmtp_Receivefile item in this)
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