/**  版本信息模板在安装目录下，可自行修改。
* commodity.cs
*
* 功 能： N/A
* 类 名： commodity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/03/01 13:53:31   N/A    初版
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
	/// 数据访问类:commodity
	/// </summary>
	public partial class commodity
	{
		public commodity()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "commodity"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from commodity");
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
		public bool Add(MultiColorPen.Model.commodity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into commodity(");
			strSql.Append("name,number,count,price,type,mark,unit,is_del,special_supply)");
			strSql.Append(" values (");
			strSql.Append("?name,?number,?count,?price,?type,?mark,?unit,?is_del,?special_supply)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?name", MySqlDbType.VarChar,100),
					new MySqlParameter("?number", MySqlDbType.VarChar,30),
					new MySqlParameter("?count", MySqlDbType.Int32,11),
					new MySqlParameter("?price", MySqlDbType.Decimal,10),
					new MySqlParameter("?type", MySqlDbType.VarChar,10),
					new MySqlParameter("?mark", MySqlDbType.VarChar,150),
					new MySqlParameter("?unit", MySqlDbType.VarChar,10),
					new MySqlParameter("?is_del", MySqlDbType.VarChar,2),
					new MySqlParameter("?special_supply", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.number;
			parameters[2].Value = model.count;
			parameters[3].Value = model.price;
			parameters[4].Value = model.type;
			parameters[5].Value = model.mark;
			parameters[6].Value = model.unit;
			parameters[7].Value = model.is_del;
			parameters[8].Value = model.special_supply;

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
		public bool Update(MultiColorPen.Model.commodity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update commodity set ");
			strSql.Append("name=?name,");
			strSql.Append("number=?number,");
			strSql.Append("count=?count,");
			strSql.Append("price=?price,");
			strSql.Append("type=?type,");
			strSql.Append("mark=?mark,");
			strSql.Append("unit=?unit,");
			strSql.Append("is_del=?is_del,");
			strSql.Append("special_supply=?special_supply");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?name", MySqlDbType.VarChar,100),
					new MySqlParameter("?number", MySqlDbType.VarChar,30),
					new MySqlParameter("?count", MySqlDbType.Int32,11),
					new MySqlParameter("?price", MySqlDbType.Decimal,10),
					new MySqlParameter("?type", MySqlDbType.VarChar,10),
					new MySqlParameter("?mark", MySqlDbType.VarChar,150),
					new MySqlParameter("?unit", MySqlDbType.VarChar,10),
					new MySqlParameter("?is_del", MySqlDbType.VarChar,2),
					new MySqlParameter("?special_supply", MySqlDbType.VarChar,50),
					new MySqlParameter("?id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.number;
			parameters[2].Value = model.count;
			parameters[3].Value = model.price;
			parameters[4].Value = model.type;
			parameters[5].Value = model.mark;
			parameters[6].Value = model.unit;
			parameters[7].Value = model.is_del;
			parameters[8].Value = model.special_supply;
			parameters[9].Value = model.id;

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
			strSql.Append("delete from commodity ");
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
			strSql.Append("delete from commodity ");
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
		public MultiColorPen.Model.commodity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,name,number,count,price,type,mark,unit,is_del,special_supply from commodity ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			MultiColorPen.Model.commodity model=new MultiColorPen.Model.commodity();
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
		public MultiColorPen.Model.commodity DataRowToModel(DataRow row)
		{
			MultiColorPen.Model.commodity model=new MultiColorPen.Model.commodity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["number"]!=null)
				{
					model.number=row["number"].ToString();
				}
				if(row["count"]!=null && row["count"].ToString()!="")
				{
					model.count=int.Parse(row["count"].ToString());
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["mark"]!=null)
				{
					model.mark=row["mark"].ToString();
				}
				if(row["unit"]!=null)
				{
					model.unit=row["unit"].ToString();
				}
				if(row["is_del"]!=null)
				{
					model.is_del=row["is_del"].ToString();
				}
				if(row["special_supply"]!=null)
				{
					model.special_supply=row["special_supply"].ToString();
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
			strSql.Append("select id,name,number,count,price,type,mark,unit,is_del,special_supply,concat(name,special_supply) as special_ame ");
			strSql.Append(" FROM commodity ");
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
			strSql.Append("select count(1) FROM commodity ");
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
		//public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		//{
		//	StringBuilder strSql=new StringBuilder();
		//	strSql.Append("SELECT * FROM ( ");
		//	strSql.Append(" SELECT ROW_NUMBER() OVER (");
		//	if (!string.IsNullOrEmpty(orderby.Trim()))
		//	{
		//		strSql.Append("order by T." + orderby );
		//	}
		//	else
		//	{
		//		strSql.Append("order by T.id desc");
		//	}
		//	strSql.Append(")AS Row, T.*  from commodity T ");
		//	if (!string.IsNullOrEmpty(strWhere.Trim()))
		//	{
		//		strSql.Append(" WHERE " + strWhere);
		//	}
		//	strSql.Append(" ) TT");
		//	strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
		//	return DbHelperMySQL.Query(strSql.ToString());
		//}
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT* from(SELECT @rowno:= @rowno + 1 AS Row, a.*FROM(select * from commodity");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (orderby != "")
            {
                strSql.Append("  ORDER BY " + orderby);
            }
            else
                strSql.Append("  ORDER BY CREATEtime");
            strSql.Append(") a ,(SELECT @rowno:= 0) b)bb where Row BETWEEN " + startIndex + " and " + endIndex);

            return DbHelperMySQL.Query(strSql.ToString());
        }
        public DataSet GetTypeList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT DISTINCT(type) from commodity where is_del=0 ");
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
			parameters[0].Value = "commodity";
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

