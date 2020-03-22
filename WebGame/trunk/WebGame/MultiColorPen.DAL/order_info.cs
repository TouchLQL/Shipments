/**  版本信息模板在安装目录下，可自行修改。
* order_info.cs
*
* 功 能： N/A
* 类 名： order_info
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
	/// 数据访问类:order_info
	/// </summary>
	public partial class order_info
	{
		public order_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "order_info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from order_info");
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
		public bool Add(MultiColorPen.Model.order_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into order_info(");
			strSql.Append("number,customer_name,customer_address,customer_tel,customer_person,customer_id,create_time,delivery_time,status,is_del,mark)");
			strSql.Append(" values (");
			strSql.Append("?number,?customer_name,?customer_address,?customer_tel,?customer_person,?customer_id,?create_time,?delivery_time,?status,?is_del,?mark)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?number", MySqlDbType.VarChar,30),
					new MySqlParameter("?customer_name", MySqlDbType.VarChar,50),
					new MySqlParameter("?customer_address", MySqlDbType.VarChar,100),
					new MySqlParameter("?customer_tel", MySqlDbType.VarChar,20),
					new MySqlParameter("?customer_person", MySqlDbType.VarChar,20),
					new MySqlParameter("?customer_id", MySqlDbType.Int32,11),
					new MySqlParameter("?create_time", MySqlDbType.VarChar,11),
					new MySqlParameter("?delivery_time", MySqlDbType.VarChar,11),
					new MySqlParameter("?status", MySqlDbType.VarChar,10),
					new MySqlParameter("?is_del", MySqlDbType.VarChar,2),
					new MySqlParameter("?mark", MySqlDbType.VarChar,155)};
			parameters[0].Value = model.number;
			parameters[1].Value = model.customer_name;
			parameters[2].Value = model.customer_address;
			parameters[3].Value = model.customer_tel;
			parameters[4].Value = model.customer_person;
			parameters[5].Value = model.customer_id;
			parameters[6].Value = model.create_time;
			parameters[7].Value = model.delivery_time;
			parameters[8].Value = model.status;
			parameters[9].Value = model.is_del;
			parameters[10].Value = model.mark;

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
		public bool Update(MultiColorPen.Model.order_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update order_info set ");
			strSql.Append("number=?number,");
			strSql.Append("customer_name=?customer_name,");
			strSql.Append("customer_address=?customer_address,");
			strSql.Append("customer_tel=?customer_tel,");
			strSql.Append("customer_person=?customer_person,");
			strSql.Append("customer_id=?customer_id,");
			strSql.Append("create_time=?create_time,");
			strSql.Append("delivery_time=?delivery_time,");
			strSql.Append("status=?status,");
			strSql.Append("is_del=?is_del,");
			strSql.Append("mark=?mark");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?number", MySqlDbType.VarChar,30),
					new MySqlParameter("?customer_name", MySqlDbType.VarChar,50),
					new MySqlParameter("?customer_address", MySqlDbType.VarChar,100),
					new MySqlParameter("?customer_tel", MySqlDbType.VarChar,20),
					new MySqlParameter("?customer_person", MySqlDbType.VarChar,20),
					new MySqlParameter("?customer_id", MySqlDbType.Int32,11),
					new MySqlParameter("?create_time", MySqlDbType.VarChar,11),
					new MySqlParameter("?delivery_time", MySqlDbType.VarChar,11),
					new MySqlParameter("?status", MySqlDbType.VarChar,10),
					new MySqlParameter("?is_del", MySqlDbType.VarChar,2),
					new MySqlParameter("?mark", MySqlDbType.VarChar,155),
					new MySqlParameter("?id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.number;
			parameters[1].Value = model.customer_name;
			parameters[2].Value = model.customer_address;
			parameters[3].Value = model.customer_tel;
			parameters[4].Value = model.customer_person;
			parameters[5].Value = model.customer_id;
			parameters[6].Value = model.create_time;
			parameters[7].Value = model.delivery_time;
			parameters[8].Value = model.status;
			parameters[9].Value = model.is_del;
			parameters[10].Value = model.mark;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from order_info ");
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
			strSql.Append("delete from order_info ");
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
		public MultiColorPen.Model.order_info GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,number,customer_name,customer_address,customer_tel,customer_person,customer_id,create_time,delivery_time,status,is_del,mark from order_info ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			MultiColorPen.Model.order_info model=new MultiColorPen.Model.order_info();
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
		public MultiColorPen.Model.order_info DataRowToModel(DataRow row)
		{
			MultiColorPen.Model.order_info model=new MultiColorPen.Model.order_info();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["number"]!=null)
				{
					model.number=row["number"].ToString();
				}
				if(row["customer_name"]!=null)
				{
					model.customer_name=row["customer_name"].ToString();
				}
				if(row["customer_address"]!=null)
				{
					model.customer_address=row["customer_address"].ToString();
				}
				if(row["customer_tel"]!=null)
				{
					model.customer_tel=row["customer_tel"].ToString();
				}
				if(row["customer_person"]!=null)
				{
					model.customer_person=row["customer_person"].ToString();
				}
				if(row["customer_id"]!=null && row["customer_id"].ToString()!="")
				{
					model.customer_id=int.Parse(row["customer_id"].ToString());
				}
				if(row["create_time"]!=null)
				{
					model.create_time=row["create_time"].ToString();
				}
				if(row["delivery_time"]!=null)
				{
					model.delivery_time=row["delivery_time"].ToString();
				}
				if(row["status"]!=null)
				{
					model.status=row["status"].ToString();
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
			strSql.Append("select id,number,customer_name,customer_address,customer_tel,customer_person,customer_id,create_time,delivery_time,status,is_del,mark ");
			strSql.Append(" FROM order_info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetBaoBiaoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select T1.customer_name,T1.number,T.sumAmount,T1.delivery_time from ");
            strSql.Append(" (select customer_name, number, delivery_time from order_info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by customer_name,delivery_time)T1 ");
            strSql.Append("   left join ");
            strSql.Append("   (select order_number, sum(commodity_price) as sumAmount from order_detail ");
            strSql.Append("   where is_del = 0 ");
            strSql.Append("   GROUP BY  order_number)T ");
            strSql.Append("  on T.order_number = T1.number ");
            
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM order_info ");
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
		//	strSql.Append(")AS Row, T.*  from order_info T ");
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
            strSql.Append(" SELECT* from(SELECT @rowno:= @rowno + 1 AS Row, a.*FROM(select * from order_info");
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
			parameters[0].Value = "order_info";
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

