using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MultiColorPen.DAL
{
    /// <summary>
    /// 数据访问类:base_userinfo
    /// </summary>
    public partial class base_userinfo
    {
        public base_userinfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from base_userinfo");
            strSql.Append(" where username=?username ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?username", MySqlDbType.VarChar,20)         };
            parameters[0].Value = username;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MultiColorPen.Model.base_userinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into base_userinfo(");
            strSql.Append("id,pid,username,password,usercode,rolecode,isenable,pname,sex,age,birthday,phone,avatar,qq,wechat,email,token,remark,createtime,createman,updatetime,updateman)");
            strSql.Append(" values (");
            strSql.Append("?id,?pid,?username,?password,?usercode,?rolecode,?isenable,?pname,?sex,?age,?birthday,?phone,?avatar,?qq,?wechat,?email,?token,?remark,?createtime,?createman,?updatetime,?updateman)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?pid", MySqlDbType.Int32,11),
                    new MySqlParameter("?username", MySqlDbType.VarChar,20),
                    new MySqlParameter("?password", MySqlDbType.VarChar,50),
                    new MySqlParameter("?usercode", MySqlDbType.VarChar,36),
                    new MySqlParameter("?rolecode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?isenable", MySqlDbType.Int32,11),
                    new MySqlParameter("?pname", MySqlDbType.VarChar,10),
                    new MySqlParameter("?sex", MySqlDbType.VarChar,2),
                    new MySqlParameter("?age", MySqlDbType.VarChar,2),
                    new MySqlParameter("?birthday", MySqlDbType.DateTime),
                    new MySqlParameter("?phone", MySqlDbType.VarChar,20),
                    new MySqlParameter("?avatar", MySqlDbType.Text),
                    new MySqlParameter("?qq", MySqlDbType.VarChar,20),
                    new MySqlParameter("?wechat", MySqlDbType.VarChar,50),
                    new MySqlParameter("?email", MySqlDbType.VarChar,50),
                    new MySqlParameter("?token", MySqlDbType.VarChar,50),
                    new MySqlParameter("?remark", MySqlDbType.VarChar,200),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?updatetime", MySqlDbType.DateTime),
                    new MySqlParameter("?updateman", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.pid;
            parameters[2].Value = model.username;
            parameters[3].Value = model.password;
            parameters[4].Value = model.usercode;
            parameters[5].Value = model.rolecode;
            parameters[6].Value = model.isenable;
            parameters[7].Value = model.pname;
            parameters[8].Value = model.sex;
            parameters[9].Value = model.age;
            parameters[10].Value = model.birthday;
            parameters[11].Value = model.phone;
            parameters[12].Value = model.avatar;
            parameters[13].Value = model.qq;
            parameters[14].Value = model.wechat;
            parameters[15].Value = model.email;
            parameters[16].Value = model.token;
            parameters[17].Value = model.remark;
            parameters[18].Value = model.createtime;
            parameters[19].Value = model.createman;
            parameters[20].Value = model.updatetime;
            parameters[21].Value = model.updateman;

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
        public bool Update(MultiColorPen.Model.base_userinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update base_userinfo set ");
            strSql.Append("id=?id,");
            strSql.Append("pid=?pid,");
            strSql.Append("password=?password,");
            strSql.Append("usercode=?usercode,");
            strSql.Append("rolecode=?rolecode,");
            strSql.Append("isenable=?isenable,");
            strSql.Append("pname=?pname,");
            strSql.Append("sex=?sex,");
            strSql.Append("age=?age,");
            strSql.Append("birthday=?birthday,");
            strSql.Append("phone=?phone,");
            strSql.Append("avatar=?avatar,");
            strSql.Append("qq=?qq,");
            strSql.Append("wechat=?wechat,");
            strSql.Append("email=?email,");
            strSql.Append("token=?token,");
            strSql.Append("remark=?remark,");
            strSql.Append("createtime=?createtime,");
            strSql.Append("createman=?createman,");
            strSql.Append("updatetime=?updatetime,");
            strSql.Append("updateman=?updateman");
            strSql.Append(" where username=?username ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?pid", MySqlDbType.Int32,11),
                    new MySqlParameter("?password", MySqlDbType.VarChar,50),
                    new MySqlParameter("?usercode", MySqlDbType.VarChar,36),
                    new MySqlParameter("?rolecode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?isenable", MySqlDbType.Int32,11),
                    new MySqlParameter("?pname", MySqlDbType.VarChar,10),
                    new MySqlParameter("?sex", MySqlDbType.VarChar,2),
                    new MySqlParameter("?age", MySqlDbType.VarChar,2),
                    new MySqlParameter("?birthday", MySqlDbType.DateTime),
                    new MySqlParameter("?phone", MySqlDbType.VarChar,20),
                    new MySqlParameter("?avatar", MySqlDbType.Text),
                    new MySqlParameter("?qq", MySqlDbType.VarChar,20),
                    new MySqlParameter("?wechat", MySqlDbType.VarChar,50),
                    new MySqlParameter("?email", MySqlDbType.VarChar,50),
                    new MySqlParameter("?token", MySqlDbType.VarChar,50),
                    new MySqlParameter("?remark", MySqlDbType.VarChar,200),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?updatetime", MySqlDbType.DateTime),
                    new MySqlParameter("?updateman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?username", MySqlDbType.VarChar,20)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.pid;
            parameters[2].Value = model.password;
            parameters[3].Value = model.usercode;
            parameters[4].Value = model.rolecode;
            parameters[5].Value = model.isenable;
            parameters[6].Value = model.pname;
            parameters[7].Value = model.sex;
            parameters[8].Value = model.age;
            parameters[9].Value = model.birthday;
            parameters[10].Value = model.phone;
            parameters[11].Value = model.avatar;
            parameters[12].Value = model.qq;
            parameters[13].Value = model.wechat;
            parameters[14].Value = model.email;
            parameters[15].Value = model.token;
            parameters[16].Value = model.remark;
            parameters[17].Value = model.createtime;
            parameters[18].Value = model.createman;
            parameters[19].Value = model.updatetime;
            parameters[20].Value = model.updateman;
            parameters[21].Value = model.username;

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
        public bool Delete(string username)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from base_userinfo ");
            strSql.Append(" where username=?username ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?username", MySqlDbType.VarChar,20)         };
            parameters[0].Value = username;

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
        public bool DeleteList(string usernamelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from base_userinfo ");
            strSql.Append(" where username in (" + usernamelist + ")  ");
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
        public MultiColorPen.Model.base_userinfo GetModel(string username)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pid,username,password,usercode,rolecode,isenable,pname,sex,age,birthday,phone,avatar,qq,wechat,email,token,remark,createtime,createman,updatetime,updateman from base_userinfo ");
            strSql.Append(" where username=?username ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?username", MySqlDbType.VarChar,20)         };
            parameters[0].Value = username;

            MultiColorPen.Model.base_userinfo model = new MultiColorPen.Model.base_userinfo();
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
        public MultiColorPen.Model.base_userinfo DataRowToModel(DataRow row)
        {
            MultiColorPen.Model.base_userinfo model = new MultiColorPen.Model.base_userinfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["pid"] != null && row["pid"].ToString() != "")
                {
                    model.pid = int.Parse(row["pid"].ToString());
                }
                if (row["username"] != null)
                {
                    model.username = row["username"].ToString();
                }
                if (row["password"] != null)
                {
                    model.password = row["password"].ToString();
                }
                if (row["usercode"] != null)
                {
                    model.usercode = row["usercode"].ToString();
                }
                if (row["rolecode"] != null)
                {
                    model.rolecode = row["rolecode"].ToString();
                }
                if (row["isenable"] != null && row["isenable"].ToString() != "")
                {
                    model.isenable = int.Parse(row["isenable"].ToString());
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["age"] != null)
                {
                    model.age = row["age"].ToString();
                }
                if (row["birthday"] != null && row["birthday"].ToString() != "")
                {
                    model.birthday = DateTime.Parse(row["birthday"].ToString());
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["avatar"] != null)
                {
                    model.avatar = row["avatar"].ToString();
                }
                if (row["qq"] != null)
                {
                    model.qq = row["qq"].ToString();
                }
                if (row["wechat"] != null)
                {
                    model.wechat = row["wechat"].ToString();
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["token"] != null)
                {
                    model.token = row["token"].ToString();
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
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.*,B.rolename ");
            strSql.Append(" FROM base_userinfo A ");
            strSql.Append(" LEFT JOIN sys_roleinfo B on A.rolecode = B.rolecode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM base_userinfo ");
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
            strSql.Append("SELECT * FROM base_userinfo T ");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.username desc");
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.AppendFormat(" limit {0} , {1}", startIndex, endIndex- startIndex);
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
			parameters[0].Value = "base_userinfo";
			parameters[1].Value = "username";
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
        /// 获取最大
        /// </summary>
        /// <returns></returns>
        public string GetMaxNo()
        {
            var dt = DbHelperMySQL.GetMaxID("usercode", "base_userinfo");
            return dt.ToString();

        }

        /// <summary>
        /// 修改登录唯一值
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="token">guid值</param>
        /// <returns></returns>
        public int UpdateToken(string username, string token)
        {
            string t_sql = "update base_userinfo set token='" + token + "' where username='" + username + "'";
            return DbHelperMySQL.ExecuteSql(t_sql);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="usercode"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdatePwd(string username, string pwd)
        {
            string t_sql = "update base_userinfo set password='" + pwd + "' where username='" + username + "'";
            if (DbHelperMySQL.ExecuteSql(t_sql) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 验证登录唯一值
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="token">guid值</param>
        /// <returns></returns>
        public int CheckLoginToken(string username, string token)
        {
            //string t_sql = "select count(1) from base_userinfo where token='" + token + "' and username='" + username + "'";
            //return int.Parse(new SQLHelper().GetSingle(t_sql).ToString());
            return 1;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from base_userinfo ");
            strSql.Append(" where id=@" + id);


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
        public MultiColorPen.Model.base_userinfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, pid, username, password, usercode, rolecode, isenable, pname, sex, age, birthday, phone, avatar, qq, wechat, email, token, remark, createtime, createman, updatetime, updateman  ");
            strSql.Append("  from base_userinfo ");
            strSql.Append(" where id=" + id);


            MultiColorPen.Model.base_userinfo model = new MultiColorPen.Model.base_userinfo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());

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
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" * ");
            strSql.Append(" FROM base_userinfo ");
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

