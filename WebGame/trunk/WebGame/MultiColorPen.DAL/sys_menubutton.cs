﻿using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MultiColorPen.DAL
{
	/// <summary>
	/// 数据访问类:sys_menubutton
	/// </summary>
	public partial class sys_menubutton
	{
		public sys_menubutton()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "sys_menubutton"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_menubutton");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11)			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MultiColorPen.Model.sys_menubutton model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_menubutton(");
			strSql.Append("id,menucode,btncode,createtime,createman)");
			strSql.Append(" values (");
			strSql.Append("?id,?menucode,?btncode,?createtime,?createman)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?menucode", MySqlDbType.VarChar,10),
					new MySqlParameter("?btncode", MySqlDbType.VarChar,10),
					new MySqlParameter("?createtime", MySqlDbType.DateTime),
					new MySqlParameter("?createman", MySqlDbType.VarChar,36)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.menucode;
			parameters[2].Value = model.btncode;
			parameters[3].Value = model.createtime;
			parameters[4].Value = model.createman;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MultiColorPen.Model.sys_menubutton model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_menubutton set ");
			strSql.Append("menucode=?menucode,");
			strSql.Append("btncode=?btncode,");
			strSql.Append("createtime=?createtime,");
			strSql.Append("createman=?createman");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?menucode", MySqlDbType.VarChar,10),
					new MySqlParameter("?btncode", MySqlDbType.VarChar,10),
					new MySqlParameter("?createtime", MySqlDbType.DateTime),
					new MySqlParameter("?createman", MySqlDbType.VarChar,36),
					new MySqlParameter("?id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.menucode;
			parameters[1].Value = model.btncode;
			parameters[2].Value = model.createtime;
			parameters[3].Value = model.createman;
			parameters[4].Value = model.id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_menubutton ");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11)			};
			parameters[0].Value = id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_menubutton ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MultiColorPen.Model.sys_menubutton GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,menucode,btncode,createtime,createman from sys_menubutton ");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11)			};
			parameters[0].Value = id;

			MultiColorPen.Model.sys_menubutton model=new MultiColorPen.Model.sys_menubutton();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MultiColorPen.Model.sys_menubutton DataRowToModel(DataRow row)
		{
			MultiColorPen.Model.sys_menubutton model=new MultiColorPen.Model.sys_menubutton();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["menucode"]!=null)
				{
					model.menucode=row["menucode"].ToString();
				}
				if(row["btncode"]!=null)
				{
					model.btncode=row["btncode"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["createman"]!=null)
				{
					model.createman=row["createman"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,menucode,btncode,createtime,createman ");
			strSql.Append(" FROM sys_menubutton ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM sys_menubutton ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperMySQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM sys_menubutton T ");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.AppendFormat("  limit {0} , {1}", startIndex, endIndex- startIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("?tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("?fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("?PageSize", MySqlDbType.Int32),
					new MySqlParameter("?PageIndex", MySqlDbType.Int32),
					new MySqlParameter("?IsReCount", MySqlDbType.Bit),
					new MySqlParameter("?OrderType", MySqlDbType.Bit),
					new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "sys_menubutton";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

