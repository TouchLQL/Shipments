using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MultiColorPen.DAL
{
	/// <summary>
	/// 数据访问类:b_msgattachment
	/// </summary>
	public partial class b_msgattachment
	{
		public b_msgattachment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "b_msgattachment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from b_msgattachment");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11)			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MultiColorPen.Model.b_msgattachment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into b_msgattachment(");
			strSql.Append("id,msgcode,name,filename,downtimes,isenable,sort,createtime,createman,isdelete,deletetime,deleteman)");
			strSql.Append(" values (");
			strSql.Append("?id,?msgcode,?name,?filename,?downtimes,?isenable,?sort,?createtime,?createman,?isdelete,?deletetime,?deleteman)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?msgcode", MySqlDbType.VarChar,10),
					new MySqlParameter("?name", MySqlDbType.VarChar,100),
					new MySqlParameter("?filename", MySqlDbType.VarChar,100),
					new MySqlParameter("?downtimes", MySqlDbType.Int32,11),
					new MySqlParameter("?isenable", MySqlDbType.Int32,11),
					new MySqlParameter("?sort", MySqlDbType.Int32,11),
					new MySqlParameter("?createtime", MySqlDbType.DateTime),
					new MySqlParameter("?createman", MySqlDbType.VarChar,36),
					new MySqlParameter("?isdelete", MySqlDbType.Int32,11),
					new MySqlParameter("?deletetime", MySqlDbType.DateTime),
					new MySqlParameter("?deleteman", MySqlDbType.VarChar,36)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.msgcode;
			parameters[2].Value = model.name;
			parameters[3].Value = model.filename;
			parameters[4].Value = model.downtimes;
			parameters[5].Value = model.isenable;
			parameters[6].Value = model.sort;
			parameters[7].Value = model.createtime;
			parameters[8].Value = model.createman;
			parameters[9].Value = model.isdelete;
			parameters[10].Value = model.deletetime;
			parameters[11].Value = model.deleteman;

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
		public bool Update(MultiColorPen.Model.b_msgattachment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update b_msgattachment set ");
			strSql.Append("msgcode=?msgcode,");
			strSql.Append("name=?name,");
			strSql.Append("filename=?filename,");
			strSql.Append("downtimes=?downtimes,");
			strSql.Append("isenable=?isenable,");
			strSql.Append("sort=?sort,");
			strSql.Append("createtime=?createtime,");
			strSql.Append("createman=?createman,");
			strSql.Append("isdelete=?isdelete,");
			strSql.Append("deletetime=?deletetime,");
			strSql.Append("deleteman=?deleteman");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?msgcode", MySqlDbType.VarChar,10),
					new MySqlParameter("?name", MySqlDbType.VarChar,100),
					new MySqlParameter("?filename", MySqlDbType.VarChar,100),
					new MySqlParameter("?downtimes", MySqlDbType.Int32,11),
					new MySqlParameter("?isenable", MySqlDbType.Int32,11),
					new MySqlParameter("?sort", MySqlDbType.Int32,11),
					new MySqlParameter("?createtime", MySqlDbType.DateTime),
					new MySqlParameter("?createman", MySqlDbType.VarChar,36),
					new MySqlParameter("?isdelete", MySqlDbType.Int32,11),
					new MySqlParameter("?deletetime", MySqlDbType.DateTime),
					new MySqlParameter("?deleteman", MySqlDbType.VarChar,36),
					new MySqlParameter("?id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.msgcode;
			parameters[1].Value = model.name;
			parameters[2].Value = model.filename;
			parameters[3].Value = model.downtimes;
			parameters[4].Value = model.isenable;
			parameters[5].Value = model.sort;
			parameters[6].Value = model.createtime;
			parameters[7].Value = model.createman;
			parameters[8].Value = model.isdelete;
			parameters[9].Value = model.deletetime;
			parameters[10].Value = model.deleteman;
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
			strSql.Append("delete from b_msgattachment ");
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
			strSql.Append("delete from b_msgattachment ");
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
		public MultiColorPen.Model.b_msgattachment GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,msgcode,name,filename,downtimes,isenable,sort,createtime,createman,isdelete,deletetime,deleteman from b_msgattachment ");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11)			};
			parameters[0].Value = id;

			MultiColorPen.Model.b_msgattachment model=new MultiColorPen.Model.b_msgattachment();
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
		public MultiColorPen.Model.b_msgattachment DataRowToModel(DataRow row)
		{
			MultiColorPen.Model.b_msgattachment model=new MultiColorPen.Model.b_msgattachment();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["msgcode"]!=null)
				{
					model.msgcode=row["msgcode"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["filename"]!=null)
				{
					model.filename=row["filename"].ToString();
				}
				if(row["downtimes"]!=null && row["downtimes"].ToString()!="")
				{
					model.downtimes=int.Parse(row["downtimes"].ToString());
				}
				if(row["isenable"]!=null && row["isenable"].ToString()!="")
				{
					model.isenable=int.Parse(row["isenable"].ToString());
				}
				if(row["sort"]!=null && row["sort"].ToString()!="")
				{
					model.sort=int.Parse(row["sort"].ToString());
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["createman"]!=null)
				{
					model.createman=row["createman"].ToString();
				}
				if(row["isdelete"]!=null && row["isdelete"].ToString()!="")
				{
					model.isdelete=int.Parse(row["isdelete"].ToString());
				}
				if(row["deletetime"]!=null && row["deletetime"].ToString()!="")
				{
					model.deletetime=DateTime.Parse(row["deletetime"].ToString());
				}
				if(row["deleteman"]!=null)
				{
					model.deleteman=row["deleteman"].ToString();
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
			strSql.Append("select id,msgcode,name,filename,downtimes,isenable,sort,createtime,createman,isdelete,deletetime,deleteman ");
			strSql.Append(" FROM b_msgattachment ");
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
			strSql.Append("select count(1) FROM b_msgattachment ");
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
			strSql.Append("SELECT * FROM b_msgattachment ");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by " + orderby );
			}
			else
			{
				strSql.Append("order by id desc");
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.AppendFormat("  limit {0} , {1}", startIndex, endIndex-startIndex);
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
			parameters[0].Value = "b_msgattachment";
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
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" * ");
            strSql.Append(" FROM b_msgattachment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            strSql.Append(" limit " + Top);
            return DbHelperMySQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion  ExtensionMethod
    }
}

