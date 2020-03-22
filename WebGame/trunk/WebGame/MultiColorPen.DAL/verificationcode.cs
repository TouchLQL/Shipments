using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MultiColorPen.DAL
{
    /// <summary>
    /// 数据访问类:verificationcode
    /// </summary>
    public partial class verificationcode
    {
        public verificationcode()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "verificationcode");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from verificationcode");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11)         };
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MultiColorPen.Model.verificationcode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into verificationcode(");
            strSql.Append("mobile,code,gettime,outtime)");
            strSql.Append(" values (");
            strSql.Append("?mobile,?code,?gettime,?outtime)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?mobile", MySqlDbType.VarChar,25),
                    new MySqlParameter("?code", MySqlDbType.VarChar,10),
                    new MySqlParameter("?gettime", MySqlDbType.DateTime),
                    new MySqlParameter("?outtime", MySqlDbType.DateTime)};
            parameters[0].Value = model.mobile;
            parameters[1].Value = model.code;
            parameters[2].Value = model.gettime;
            parameters[3].Value = model.outtime;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(MultiColorPen.Model.verificationcode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update verificationcode set ");
            strSql.Append("mobile=?mobile,");
            strSql.Append("code=?code,");
            strSql.Append("gettime=?gettime,");
            strSql.Append("outtime=?outtime");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?mobile", MySqlDbType.VarChar,25),
                    new MySqlParameter("?code", MySqlDbType.VarChar,10),
                    new MySqlParameter("?gettime", MySqlDbType.DateTime),
                    new MySqlParameter("?outtime", MySqlDbType.DateTime),
                    new MySqlParameter("?id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.mobile;
            parameters[1].Value = model.code;
            parameters[2].Value = model.gettime;
            parameters[3].Value = model.outtime;
            parameters[4].Value = model.id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from verificationcode ");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11)         };
            parameters[0].Value = id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from verificationcode ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public MultiColorPen.Model.verificationcode GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mobile,code,gettime,outtime from verificationcode ");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11)         };
            parameters[0].Value = id;

            MultiColorPen.Model.verificationcode model = new MultiColorPen.Model.verificationcode();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public MultiColorPen.Model.verificationcode DataRowToModel(DataRow row)
        {
            MultiColorPen.Model.verificationcode model = new MultiColorPen.Model.verificationcode();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["mobile"] != null)
                {
                    model.mobile = row["mobile"].ToString();
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["gettime"] != null && row["gettime"].ToString() != "")
                {
                    model.gettime = DateTime.Parse(row["gettime"].ToString());
                }
                if (row["outtime"] != null && row["outtime"].ToString() != "")
                {
                    model.outtime = DateTime.Parse(row["outtime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mobile,code,gettime,outtime ");
            strSql.Append(" FROM verificationcode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM verificationcode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT* from(SELECT @rowno:= @rowno + 1 AS Row, a.*FROM(select * from verificationcode");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (orderby != "")
            {
                strSql.Append("  ORDER BY " + orderby);
            }
            else
                strSql.Append("  ORDER BY id desc");
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
			parameters[0].Value = "verificationcode";
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

