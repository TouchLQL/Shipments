using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MultiColorPen.DAL
{
    /// <summary>
    /// 数据访问类:sys_loginfo
    /// </summary>
    public partial class sys_loginfo
    {
        public sys_loginfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "sys_loginfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_loginfo");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11)         };
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MultiColorPen.Model.sys_loginfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_loginfo(");
            strSql.Append("id,logtype,createtime,usercode,username,ipaddress,logcontent,datatable,dataid,dataold,datanew)");
            strSql.Append(" values (");
            strSql.Append("?id,?logtype,?createtime,?usercode,?username,?ipaddress,?logcontent,?datatable,?dataid,?dataold,?datanew)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?logtype", MySqlDbType.VarChar,50),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?usercode", MySqlDbType.VarChar,50),
                    new MySqlParameter("?username", MySqlDbType.VarChar,50),
                    new MySqlParameter("?ipaddress", MySqlDbType.VarChar,50),
                    new MySqlParameter("?logcontent", MySqlDbType.LongText),
                    new MySqlParameter("?datatable", MySqlDbType.Text),
                    new MySqlParameter("?dataid", MySqlDbType.Text),
                    new MySqlParameter("?dataold", MySqlDbType.LongText),
                    new MySqlParameter("?datanew", MySqlDbType.LongText)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.logtype;
            parameters[2].Value = model.createtime;
            parameters[3].Value = model.usercode;
            parameters[4].Value = model.username;
            parameters[5].Value = model.ipaddress;
            parameters[6].Value = model.logcontent;
            parameters[7].Value = model.datatable;
            parameters[8].Value = model.dataid;
            parameters[9].Value = model.dataold;
            parameters[10].Value = model.datanew;

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
        public bool Update(MultiColorPen.Model.sys_loginfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_loginfo set ");
            strSql.Append("logtype=?logtype,");
            strSql.Append("createtime=?createtime,");
            strSql.Append("usercode=?usercode,");
            strSql.Append("username=?username,");
            strSql.Append("ipaddress=?ipaddress,");
            strSql.Append("logcontent=?logcontent,");
            strSql.Append("datatable=?datatable,");
            strSql.Append("dataid=?dataid,");
            strSql.Append("dataold=?dataold,");
            strSql.Append("datanew=?datanew");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?logtype", MySqlDbType.VarChar,50),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?usercode", MySqlDbType.VarChar,50),
                    new MySqlParameter("?username", MySqlDbType.VarChar,50),
                    new MySqlParameter("?ipaddress", MySqlDbType.VarChar,50),
                    new MySqlParameter("?logcontent", MySqlDbType.LongText),
                    new MySqlParameter("?datatable", MySqlDbType.Text),
                    new MySqlParameter("?dataid", MySqlDbType.Text),
                    new MySqlParameter("?dataold", MySqlDbType.LongText),
                    new MySqlParameter("?datanew", MySqlDbType.LongText),
                    new MySqlParameter("?id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.logtype;
            parameters[1].Value = model.createtime;
            parameters[2].Value = model.usercode;
            parameters[3].Value = model.username;
            parameters[4].Value = model.ipaddress;
            parameters[5].Value = model.logcontent;
            parameters[6].Value = model.datatable;
            parameters[7].Value = model.dataid;
            parameters[8].Value = model.dataold;
            parameters[9].Value = model.datanew;
            parameters[10].Value = model.id;

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
            strSql.Append("delete from sys_loginfo ");
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
            strSql.Append("delete from sys_loginfo ");
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
        public MultiColorPen.Model.sys_loginfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,logtype,createtime,usercode,username,ipaddress,logcontent,datatable,dataid,dataold,datanew from sys_loginfo ");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11)         };
            parameters[0].Value = id;

            MultiColorPen.Model.sys_loginfo model = new MultiColorPen.Model.sys_loginfo();
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
        public MultiColorPen.Model.sys_loginfo DataRowToModel(DataRow row)
        {
            MultiColorPen.Model.sys_loginfo model = new MultiColorPen.Model.sys_loginfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["logtype"] != null)
                {
                    model.logtype = row["logtype"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["usercode"] != null)
                {
                    model.usercode = row["usercode"].ToString();
                }
                if (row["username"] != null)
                {
                    model.username = row["username"].ToString();
                }
                if (row["ipaddress"] != null)
                {
                    model.ipaddress = row["ipaddress"].ToString();
                }
                if (row["logcontent"] != null)
                {
                    model.logcontent = row["logcontent"].ToString();
                }
                if (row["datatable"] != null)
                {
                    model.datatable = row["datatable"].ToString();
                }
                if (row["dataid"] != null)
                {
                    model.dataid = row["dataid"].ToString();
                }
                if (row["dataold"] != null)
                {
                    model.dataold = row["dataold"].ToString();
                }
                if (row["datanew"] != null)
                {
                    model.datanew = row["datanew"].ToString();
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
            strSql.Append("select id,logtype,createtime,usercode,username,ipaddress,logcontent,datatable,dataid,dataold,datanew ");
            strSql.Append(" FROM sys_loginfo ");
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
            strSql.Append("select count(1) FROM sys_loginfo ");
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
            strSql.Append(" SELECT* from(SELECT @rowno:= @rowno + 1 AS Row, a.*FROM(select * from sys_loginfo");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (orderby != "")
            {
                strSql.Append("  ORDER BY " + orderby);
            }
            else
                strSql.Append("  ORDER BY CREATEtime" );
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
			parameters[0].Value = "sys_loginfo";
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

