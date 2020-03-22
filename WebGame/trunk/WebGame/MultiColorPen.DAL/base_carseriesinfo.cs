using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MultiColorPen.DAL
{
	/// <summary>
	/// 数据访问类:base_carseriesinfo
	/// </summary>
	public partial class base_carseriesinfo
	{
		public base_carseriesinfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string seriescode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from base_carseriesinfo");
			strSql.Append(" where seriescode=?seriescode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?seriescode", MySqlDbType.VarChar,10)			};
			parameters[0].Value = seriescode;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MultiColorPen.Model.base_carseriesinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into base_carseriesinfo(");
			strSql.Append("id,brandcode,brandname,seriescode,seriesname,isenable,sort,remark,createtime,createman,updatetime,updateman)");
			strSql.Append(" values (");
			strSql.Append("?id,?brandcode,?brandname,?seriescode,?seriesname,?isenable,?sort,?remark,?createtime,?createman,?updatetime,?updateman)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?brandcode", MySqlDbType.VarChar,10),
					new MySqlParameter("?brandname", MySqlDbType.VarChar,30),
					new MySqlParameter("?seriescode", MySqlDbType.VarChar,10),
					new MySqlParameter("?seriesname", MySqlDbType.VarChar,30),
					new MySqlParameter("?isenable", MySqlDbType.Int32,11),
					new MySqlParameter("?sort", MySqlDbType.Int32,11),
					new MySqlParameter("?remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?createtime", MySqlDbType.DateTime),
					new MySqlParameter("?createman", MySqlDbType.VarChar,36),
					new MySqlParameter("?updatetime", MySqlDbType.DateTime),
					new MySqlParameter("?updateman", MySqlDbType.VarChar,36)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.brandcode;
			parameters[2].Value = model.brandname;
			parameters[3].Value = model.seriescode;
			parameters[4].Value = model.seriesname;
			parameters[5].Value = model.isenable;
			parameters[6].Value = model.sort;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.createtime;
			parameters[9].Value = model.createman;
			parameters[10].Value = model.updatetime;
			parameters[11].Value = model.updateman;

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
		public bool Update(MultiColorPen.Model.base_carseriesinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update base_carseriesinfo set ");
			strSql.Append("id=?id,");
			strSql.Append("brandcode=?brandcode,");
			strSql.Append("brandname=?brandname,");
			strSql.Append("seriesname=?seriesname,");
			strSql.Append("isenable=?isenable,");
			strSql.Append("sort=?sort,");
			strSql.Append("remark=?remark,");
			strSql.Append("createtime=?createtime,");
			strSql.Append("createman=?createman,");
			strSql.Append("updatetime=?updatetime,");
			strSql.Append("updateman=?updateman");
			strSql.Append(" where seriescode=?seriescode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?brandcode", MySqlDbType.VarChar,10),
					new MySqlParameter("?brandname", MySqlDbType.VarChar,30),
					new MySqlParameter("?seriesname", MySqlDbType.VarChar,30),
					new MySqlParameter("?isenable", MySqlDbType.Int32,11),
					new MySqlParameter("?sort", MySqlDbType.Int32,11),
					new MySqlParameter("?remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?createtime", MySqlDbType.DateTime),
					new MySqlParameter("?createman", MySqlDbType.VarChar,36),
					new MySqlParameter("?updatetime", MySqlDbType.DateTime),
					new MySqlParameter("?updateman", MySqlDbType.VarChar,36),
					new MySqlParameter("?seriescode", MySqlDbType.VarChar,10)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.brandcode;
			parameters[2].Value = model.brandname;
			parameters[3].Value = model.seriesname;
			parameters[4].Value = model.isenable;
			parameters[5].Value = model.sort;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.createtime;
			parameters[8].Value = model.createman;
			parameters[9].Value = model.updatetime;
			parameters[10].Value = model.updateman;
			parameters[11].Value = model.seriescode;

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
		public bool Delete(string seriescode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from base_carseriesinfo ");
			strSql.Append(" where seriescode=?seriescode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?seriescode", MySqlDbType.VarChar,10)			};
			parameters[0].Value = seriescode;

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
		public bool DeleteList(string seriescodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from base_carseriesinfo ");
			strSql.Append(" where seriescode in ("+seriescodelist + ")  ");
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
		public MultiColorPen.Model.base_carseriesinfo GetModel(string seriescode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,brandcode,brandname,seriescode,seriesname,isenable,sort,remark,createtime,createman,updatetime,updateman from base_carseriesinfo ");
			strSql.Append(" where seriescode=?seriescode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?seriescode", MySqlDbType.VarChar,10)			};
			parameters[0].Value = seriescode;

			MultiColorPen.Model.base_carseriesinfo model=new MultiColorPen.Model.base_carseriesinfo();
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
		public MultiColorPen.Model.base_carseriesinfo DataRowToModel(DataRow row)
		{
			MultiColorPen.Model.base_carseriesinfo model=new MultiColorPen.Model.base_carseriesinfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["brandcode"]!=null)
				{
					model.brandcode=row["brandcode"].ToString();
				}
				if(row["brandname"]!=null)
				{
					model.brandname=row["brandname"].ToString();
				}
				if(row["seriescode"]!=null)
				{
					model.seriescode=row["seriescode"].ToString();
				}
				if(row["seriesname"]!=null)
				{
					model.seriesname=row["seriesname"].ToString();
				}
				if(row["isenable"]!=null && row["isenable"].ToString()!="")
				{
					model.isenable=int.Parse(row["isenable"].ToString());
				}
				if(row["sort"]!=null && row["sort"].ToString()!="")
				{
					model.sort=int.Parse(row["sort"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["createman"]!=null)
				{
					model.createman=row["createman"].ToString();
				}
				if(row["updatetime"]!=null && row["updatetime"].ToString()!="")
				{
					model.updatetime=DateTime.Parse(row["updatetime"].ToString());
				}
				if(row["updateman"]!=null)
				{
					model.updateman=row["updateman"].ToString();
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
			strSql.Append("select id,brandcode,brandname,seriescode,seriesname,isenable,sort,remark,createtime,createman,updatetime,updateman ");
			strSql.Append(" FROM base_carseriesinfo ");
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
			strSql.Append("select count(1) FROM base_carseriesinfo ");
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
			strSql.Append("SELECT * FROM base_carseriesinfo T ");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.seriescode desc");
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
			parameters[0].Value = "base_carseriesinfo";
			parameters[1].Value = "seriescode";
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
        /// 得到一个对象实体
        /// </summary>
        public MultiColorPen.Model.base_carseriesinfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, brandcode, brandname, seriescode, seriesname, isenable, sort, remark, createtime, createman, updatetime, updateman  ");
            strSql.Append("  from base_carseriesinfo ");
            strSql.Append(" where id="+id);


            MultiColorPen.Model.base_carseriesinfo model = new MultiColorPen.Model.base_carseriesinfo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.brandcode = ds.Tables[0].Rows[0]["brandcode"].ToString();
                model.brandname = ds.Tables[0].Rows[0]["brandname"].ToString();
                model.seriescode = ds.Tables[0].Rows[0]["seriescode"].ToString();
                model.seriesname = ds.Tables[0].Rows[0]["seriesname"].ToString();
                if (ds.Tables[0].Rows[0]["isenable"].ToString() != "")
                {
                    model.isenable = int.Parse(ds.Tables[0].Rows[0]["isenable"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(ds.Tables[0].Rows[0]["createtime"].ToString());
                }
                model.createman = ds.Tables[0].Rows[0]["createman"].ToString();
                if (ds.Tables[0].Rows[0]["updatetime"].ToString() != "")
                {
                    model.updatetime = DateTime.Parse(ds.Tables[0].Rows[0]["updatetime"].ToString());
                }
                model.updateman = ds.Tables[0].Rows[0]["updateman"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from base_carseriesinfo ");
            strSql.Append(" where id="+id);


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
        #endregion  ExtensionMethod
    }
}

