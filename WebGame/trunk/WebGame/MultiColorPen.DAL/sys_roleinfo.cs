using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MultiColorPen.DAL
{
    /// <summary>
    /// 数据访问类:sys_roleinfo
    /// </summary>
    public partial class sys_roleinfo
    {
        public sys_roleinfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string rolecode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_roleinfo");
            strSql.Append(" where rolecode=?rolecode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?rolecode", MySqlDbType.VarChar,10)         };
            parameters[0].Value = rolecode;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MultiColorPen.Model.sys_roleinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_roleinfo(");
            strSql.Append("id,rolecode,rolename,roletype,isenable,rolesort,remark,createtime,createman,updatetime,updateman)");
            strSql.Append(" values (");
            strSql.Append("?id,?rolecode,?rolename,?roletype,?isenable,?rolesort,?remark,?createtime,?createman,?updatetime,?updateman)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?rolecode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?rolename", MySqlDbType.VarChar,10),
                    new MySqlParameter("?roletype", MySqlDbType.VarChar,10),
                    new MySqlParameter("?isenable", MySqlDbType.Int32,11),
                    new MySqlParameter("?rolesort", MySqlDbType.Int32,11),
                    new MySqlParameter("?remark", MySqlDbType.VarChar,200),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?updatetime", MySqlDbType.DateTime),
                    new MySqlParameter("?updateman", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.rolecode;
            parameters[2].Value = model.rolename;
            parameters[3].Value = model.roletype;
            parameters[4].Value = model.isenable;
            parameters[5].Value = model.rolesort;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.createtime;
            parameters[8].Value = model.createman;
            parameters[9].Value = model.updatetime;
            parameters[10].Value = model.updateman;

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
        public bool Update(MultiColorPen.Model.sys_roleinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_roleinfo set ");
            strSql.Append("id=?id,");
            strSql.Append("rolename=?rolename,");
            strSql.Append("roletype=?roletype,");
            strSql.Append("isenable=?isenable,");
            strSql.Append("rolesort=?rolesort,");
            strSql.Append("remark=?remark,");
            strSql.Append("createtime=?createtime,");
            strSql.Append("createman=?createman,");
            strSql.Append("updatetime=?updatetime,");
            strSql.Append("updateman=?updateman");
            strSql.Append(" where rolecode=?rolecode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?rolename", MySqlDbType.VarChar,10),
                    new MySqlParameter("?roletype", MySqlDbType.VarChar,10),
                    new MySqlParameter("?isenable", MySqlDbType.Int32,11),
                    new MySqlParameter("?rolesort", MySqlDbType.Int32,11),
                    new MySqlParameter("?remark", MySqlDbType.VarChar,200),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?updatetime", MySqlDbType.DateTime),
                    new MySqlParameter("?updateman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?rolecode", MySqlDbType.VarChar,10)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.rolename;
            parameters[2].Value = model.roletype;
            parameters[3].Value = model.isenable;
            parameters[4].Value = model.rolesort;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.createtime;
            parameters[7].Value = model.createman;
            parameters[8].Value = model.updatetime;
            parameters[9].Value = model.updateman;
            parameters[10].Value = model.rolecode;

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
        public bool Delete(string rolecode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_roleinfo ");
            strSql.Append(" where rolecode=?rolecode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?rolecode", MySqlDbType.VarChar,10)         };
            parameters[0].Value = rolecode;

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
        public bool DeleteList(string rolecodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_roleinfo ");
            strSql.Append(" where rolecode in (" + rolecodelist + ")  ");
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
        public MultiColorPen.Model.sys_roleinfo GetModel(string rolecode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,rolecode,rolename,roletype,isenable,rolesort,remark,createtime,createman,updatetime,updateman from sys_roleinfo ");
            strSql.Append(" where rolecode=?rolecode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?rolecode", MySqlDbType.VarChar,10)         };
            parameters[0].Value = rolecode;

            MultiColorPen.Model.sys_roleinfo model = new MultiColorPen.Model.sys_roleinfo();
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
        public MultiColorPen.Model.sys_roleinfo DataRowToModel(DataRow row)
        {
            MultiColorPen.Model.sys_roleinfo model = new MultiColorPen.Model.sys_roleinfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["rolecode"] != null)
                {
                    model.rolecode = row["rolecode"].ToString();
                }
                if (row["rolename"] != null)
                {
                    model.rolename = row["rolename"].ToString();
                }
                if (row["roletype"] != null)
                {
                    model.roletype = row["roletype"].ToString();
                }
                if (row["isenable"] != null && row["isenable"].ToString() != "")
                {
                    model.isenable = int.Parse(row["isenable"].ToString());
                }
                if (row["rolesort"] != null && row["rolesort"].ToString() != "")
                {
                    model.rolesort = int.Parse(row["rolesort"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["createman"] != null)
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["updatetime"] != null && row["updatetime"].ToString() != "")
                {
                    model.updatetime = DateTime.Parse(row["updatetime"].ToString());
                }
                if (row["updateman"] != null)
                {
                    model.updateman = row["updateman"].ToString();
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
            strSql.Append("select id,rolecode,rolename,roletype,isenable,rolesort,remark,createtime,createman,updatetime,updateman ");
            strSql.Append(" FROM sys_roleinfo ");
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
            strSql.Append("select count(1) FROM sys_roleinfo ");
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
            strSql.Append("SELECT * FROM sys_roleinfo T ");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.rolecode desc");
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.AppendFormat("  between {0} and {1}", startIndex, endIndex - startIndex);
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
			parameters[0].Value = "sys_roleinfo";
			parameters[1].Value = "rolecode";
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
        /// 获取编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxNo()
        {
            var dt = DbHelperMySQL.GetMaxID("rolecode", "sys_roleinfo");
            return dt.ToString();
        }
        /// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_roleinfo ");
            strSql.Append(" where id=" + id);

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

