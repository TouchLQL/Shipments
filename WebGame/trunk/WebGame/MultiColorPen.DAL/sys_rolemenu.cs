using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;

namespace MultiColorPen.DAL
{
    /// <summary>
    /// 数据访问类:sys_rolemenu
    /// </summary>
    public partial class sys_rolemenu
    {
        public sys_rolemenu()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "sys_rolemenu");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_rolemenu");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11)         };
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MultiColorPen.Model.sys_rolemenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_rolemenu(");
            strSql.Append("id,rolecode,menucode,btncode,createtime,createman)");
            strSql.Append(" values (");
            strSql.Append("?id,?rolecode,?menucode,?btncode,?createtime,?createman)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?rolecode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?menucode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?btncode", MySqlDbType.Text),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.rolecode;
            parameters[2].Value = model.menucode;
            parameters[3].Value = model.btncode;
            parameters[4].Value = model.createtime;
            parameters[5].Value = model.createman;

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
        public bool Update(MultiColorPen.Model.sys_rolemenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_rolemenu set ");
            strSql.Append("rolecode=?rolecode,");
            strSql.Append("menucode=?menucode,");
            strSql.Append("btncode=?btncode,");
            strSql.Append("createtime=?createtime,");
            strSql.Append("createman=?createman");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?rolecode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?menucode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?btncode", MySqlDbType.Text),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.rolecode;
            parameters[1].Value = model.menucode;
            parameters[2].Value = model.btncode;
            parameters[3].Value = model.createtime;
            parameters[4].Value = model.createman;
            parameters[5].Value = model.id;

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
        public bool Delete(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_menuinfo ");
            strSql.Append(" where menucode= '" + id + "'");

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_rolemenu ");
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
        public MultiColorPen.Model.sys_rolemenu GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,rolecode,menucode,btncode,createtime,createman from sys_rolemenu ");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11)         };
            parameters[0].Value = id;

            MultiColorPen.Model.sys_rolemenu model = new MultiColorPen.Model.sys_rolemenu();
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
        public MultiColorPen.Model.sys_rolemenu DataRowToModel(DataRow row)
        {
            MultiColorPen.Model.sys_rolemenu model = new MultiColorPen.Model.sys_rolemenu();
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
                if (row["menucode"] != null)
                {
                    model.menucode = row["menucode"].ToString();
                }
                if (row["btncode"] != null)
                {
                    model.btncode = row["btncode"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["createman"] != null)
                {
                    model.createman = row["createman"].ToString();
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
            strSql.Append("select id,rolecode,menucode,btncode,createtime,createman ");
            strSql.Append(" FROM sys_rolemenu ");
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
            strSql.Append("select count(1) FROM sys_rolemenu ");
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
            strSql.Append("SELECT * FROM sys_rolemenu T ");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.AppendFormat("  limit {0} , {1}", startIndex, endIndex - startIndex);
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
			parameters[0].Value = "sys_rolemenu";
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
        /// 添加角色权限
        /// </summary>
        /// <param name="rolecode">角色编号</param>
        /// <param name="r_str">菜单按钮编号字符串</param>
        /// <returns></returns>
        public int SaveRoleMenu(string rolecode, string r_str)
        {
            List<CommandInfo> cmd_list = new List<CommandInfo>();
            string[] mb_list = r_str.Split('|');
            cmd_list.Add(new CommandInfo("delete from sys_rolemenu where rolecode='" + rolecode + "'", null));
            string t_sql = "insert into sys_rolemenu(rolecode,menucode,btncode) values('{0}','{1}','{2}')";
            foreach (string mb in mb_list)
            {
                string menucode = mb.Split('@')[0].ToString();
                string btncodelist = mb.Split('@')[1].ToString();
                string sql = string.Format(t_sql, rolecode, menucode, btncodelist);
                cmd_list.Add(new CommandInfo(sql, null));
            }
            return DbHelperMySQL.ExecuteSqlTran(cmd_list);
        }

        /// <summary>
        /// 获取用户角色权限按钮
        /// </summary>
        /// <param name="rolecode"></param>
        /// <param name="menucode"></param>
        /// <returns></returns>
        public string GetRoleMenuButton(string rolecode, string menucode)
        {
            string t_sql = "select btncode from sys_rolemenu where rolecode='" + rolecode + "' and menucode='" + menucode + "'";
            DataTable dt = DbHelperMySQL.Query(t_sql).Tables[0];
            if (dt != null && dt.Rows.Count == 1)
            {
                string btn_code_list = string.Empty;
                foreach (string btncode in dt.Rows[0]["btncode"].ToString().Trim().Split(','))
                {
                    btn_code_list += "'" + btncode.Trim() + "',";
                }
                t_sql = "select btnmethod from sys_buttoninfo where isenable=1 and btncode in(" + btn_code_list.Substring(0, btn_code_list.Length - 1) + ") order by btnsort asc";
                DataTable b_dt = DbHelperMySQL.Query(t_sql).Tables[0];
                if (b_dt != null && b_dt.Rows.Count > 0)
                {
                    string btn_method = "";
                    for (int i = 0; i < b_dt.Rows.Count; i++)
                    {
                        if (i > 0)
                            btn_method += ",";
                        btn_method += b_dt.Rows[i]["btnmethod"].ToString();
                    }
                    return btn_method;
                }
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 获取用户角色权限按钮
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoleMenuButtonInfo(string rolecode, string menucode)
        {
            string t_sql = "select btncode from sys_rolemenu where rolecode='" + rolecode + "' and menucode='" + menucode + "'";
            DataTable dt = DbHelperMySQL.Query(t_sql).Tables[0];
            if (dt != null && dt.Rows.Count == 1)
            {
                string btn_code_list = string.Empty;
                foreach (string btncode in dt.Rows[0]["btncode"].ToString().Trim().Split(','))
                {
                    btn_code_list += "'" + btncode.Trim() + "',";
                }
                t_sql = "select btncode,btnname,btnclass,btnicon,btnmethod from sys_buttoninfo where isenable=1 and btncode in(" + btn_code_list.Substring(0, btn_code_list.Length - 1) + ") order by btnsort asc";
                return DbHelperMySQL.Query(t_sql).Tables[0];
            }
            else
                return null;
        }
        #endregion  ExtensionMethod
    }
}

