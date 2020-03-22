/**  版本信息模板在安装目录下，可自行修改。
* order_detail.cs
*
* 功 能： N/A
* 类 名： order_detail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/03/01 11:25:46   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MultiColorPen.DAL
{
	/// <summary>
	/// 数据访问类:order_detail
	/// </summary>
	public partial class order_detail
	{
		public order_detail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "order_detail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from order_detail");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MultiColorPen.Model.order_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into order_detail(");
			strSql.Append("commodity_id,commodity_name,commodity_price,commodity_unit,commodity_count,order_number,is_del,mark)");
			strSql.Append(" values (");
			strSql.Append("?commodity_id,?commodity_name,?commodity_price,?commodity_unit,?commodity_count,?order_number,?is_del,?mark)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?commodity_id", MySqlDbType.Int32,11),
					new MySqlParameter("?commodity_name", MySqlDbType.VarChar,50),
					new MySqlParameter("?commodity_price", MySqlDbType.Decimal,10),
					new MySqlParameter("?commodity_unit", MySqlDbType.VarChar,255),
					new MySqlParameter("?commodity_count", MySqlDbType.Int32,10),
					new MySqlParameter("?order_number", MySqlDbType.VarChar,30),
					new MySqlParameter("?is_del", MySqlDbType.VarChar,2),
					new MySqlParameter("?mark", MySqlDbType.VarChar,150)};
			parameters[0].Value = model.commodity_id;
			parameters[1].Value = model.commodity_name;
			parameters[2].Value = model.commodity_price;
			parameters[3].Value = model.commodity_unit;
			parameters[4].Value = model.commodity_count;
			parameters[5].Value = model.order_number;
			parameters[6].Value = model.is_del;
			parameters[7].Value = model.mark;

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
		public bool Update(MultiColorPen.Model.order_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update order_detail set ");
			strSql.Append("commodity_id=?commodity_id,");
			strSql.Append("commodity_name=?commodity_name,");
			strSql.Append("commodity_price=?commodity_price,");
			strSql.Append("commodity_unit=?commodity_unit,");
			strSql.Append("commodity_count=?commodity_count,");
			strSql.Append("order_number=?order_number,");
			strSql.Append("is_del=?is_del,");
			strSql.Append("mark=?mark");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?commodity_id", MySqlDbType.Int32,11),
					new MySqlParameter("?commodity_name", MySqlDbType.VarChar,50),
					new MySqlParameter("?commodity_price", MySqlDbType.Decimal,10),
					new MySqlParameter("?commodity_unit", MySqlDbType.VarChar,255),
					new MySqlParameter("?commodity_count", MySqlDbType.Int32,10),
					new MySqlParameter("?order_number", MySqlDbType.VarChar,30),
					new MySqlParameter("?is_del", MySqlDbType.VarChar,2),
					new MySqlParameter("?mark", MySqlDbType.VarChar,150),
					new MySqlParameter("?id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.commodity_id;
			parameters[1].Value = model.commodity_name;
			parameters[2].Value = model.commodity_price;
			parameters[3].Value = model.commodity_unit;
			parameters[4].Value = model.commodity_count;
			parameters[5].Value = model.order_number;
			parameters[6].Value = model.is_del;
			parameters[7].Value = model.mark;
			parameters[8].Value = model.id;

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
			strSql.Append("delete from order_detail ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
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
			strSql.Append("delete from order_detail ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteByWhere(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update order_detail set is_del=1 ");
            strSql.Append(" where " + where );
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public MultiColorPen.Model.order_detail GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,commodity_id,commodity_name,commodity_price,commodity_unit,commodity_count,order_number,is_del,mark from order_detail ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			MultiColorPen.Model.order_detail model=new MultiColorPen.Model.order_detail();
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
		public MultiColorPen.Model.order_detail DataRowToModel(DataRow row)
		{
			MultiColorPen.Model.order_detail model=new MultiColorPen.Model.order_detail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["commodity_id"]!=null && row["commodity_id"].ToString()!="")
				{
					model.commodity_id=int.Parse(row["commodity_id"].ToString());
				}
				if(row["commodity_name"]!=null)
				{
					model.commodity_name=row["commodity_name"].ToString();
				}
				if(row["commodity_price"]!=null && row["commodity_price"].ToString()!="")
				{
					model.commodity_price=decimal.Parse(row["commodity_price"].ToString());
				}
				if(row["commodity_unit"]!=null)
				{
					model.commodity_unit=row["commodity_unit"].ToString();
				}
				if(row["commodity_count"]!=null && row["commodity_count"].ToString()!="")
				{
					model.commodity_count=int.Parse(row["commodity_count"].ToString());
				}
				if(row["order_number"]!=null)
				{
					model.order_number=row["order_number"].ToString();
				}
				if(row["is_del"]!=null)
				{
					model.is_del=row["is_del"].ToString();
				}
				if(row["mark"]!=null)
				{
					model.mark=row["mark"].ToString();
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
			strSql.Append("select id,commodity_id,commodity_name,commodity_price,commodity_unit,commodity_count,order_number,is_del,mark ");
			strSql.Append(" FROM order_detail ");
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
			strSql.Append("select count(1) FROM order_detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from order_detail T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "order_detail";
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

