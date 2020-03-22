using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MultiColorPen.DAL
{
    /// <summary>
    /// 数据访问类:sys_menuinfo
    /// </summary>
    public partial class sys_menuinfo
    {
        public sys_menuinfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string menucode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_menuinfo");
            strSql.Append(" where menucode=?menucode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?menucode", MySqlDbType.VarChar,10)         };
            parameters[0].Value = menucode;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MultiColorPen.Model.sys_menuinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_menuinfo(");
            strSql.Append("id,pmenucode,menucode,menuname,linkaddress,menuicon,menusort,isenable,createtime,createman,updatetime,updateman)");
            strSql.Append(" values (");
            strSql.Append("?id,?pmenucode,?menucode,?menuname,?linkaddress,?menuicon,?menusort,?isenable,?createtime,?createman,?updatetime,?updateman)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?pmenucode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?menucode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?menuname", MySqlDbType.VarChar,20),
                    new MySqlParameter("?linkaddress", MySqlDbType.VarChar,50),
                    new MySqlParameter("?menuicon", MySqlDbType.VarChar,20),
                    new MySqlParameter("?menusort", MySqlDbType.Int32,11),
                    new MySqlParameter("?isenable", MySqlDbType.Int32,11),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?updatetime", MySqlDbType.DateTime),
                    new MySqlParameter("?updateman", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.pmenucode;
            parameters[2].Value = model.menucode;
            parameters[3].Value = model.menuname;
            parameters[4].Value = model.linkaddress;
            parameters[5].Value = model.menuicon;
            parameters[6].Value = model.menusort;
            parameters[7].Value = model.isenable;
            parameters[8].Value = model.createtime;
            parameters[9].Value = model.createman;
            parameters[10].Value = model.updatetime;
            parameters[11].Value = model.updateman;

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
        public bool Update(MultiColorPen.Model.sys_menuinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_menuinfo set ");
            strSql.Append("id=?id,");
            strSql.Append("pmenucode=?pmenucode,");
            strSql.Append("menuname=?menuname,");
            strSql.Append("linkaddress=?linkaddress,");
            strSql.Append("menuicon=?menuicon,");
            strSql.Append("menusort=?menusort,");
            strSql.Append("isenable=?isenable,");
            strSql.Append("createtime=?createtime,");
            strSql.Append("createman=?createman,");
            strSql.Append("updatetime=?updatetime,");
            strSql.Append("updateman=?updateman");
            strSql.Append(" where menucode=?menucode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?pmenucode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?menuname", MySqlDbType.VarChar,20),
                    new MySqlParameter("?linkaddress", MySqlDbType.VarChar,50),
                    new MySqlParameter("?menuicon", MySqlDbType.VarChar,20),
                    new MySqlParameter("?menusort", MySqlDbType.Int32,11),
                    new MySqlParameter("?isenable", MySqlDbType.Int32,11),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?updatetime", MySqlDbType.DateTime),
                    new MySqlParameter("?updateman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?menucode", MySqlDbType.VarChar,10)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.pmenucode;
            parameters[2].Value = model.menuname;
            parameters[3].Value = model.linkaddress;
            parameters[4].Value = model.menuicon;
            parameters[5].Value = model.menusort;
            parameters[6].Value = model.isenable;
            parameters[7].Value = model.createtime;
            parameters[8].Value = model.createman;
            parameters[9].Value = model.updatetime;
            parameters[10].Value = model.updateman;
            parameters[11].Value = model.menucode;

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
        public bool Delete(string menucode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_menuinfo ");
            strSql.Append(" where menucode=?menucode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?menucode", MySqlDbType.VarChar,10)         };
            parameters[0].Value = menucode;

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
        public bool DeleteList(string menucodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_menuinfo ");
            strSql.Append(" where menucode in (" + menucodelist + ")  ");
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
        public MultiColorPen.Model.sys_menuinfo GetModel(string menucode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pmenucode,menucode,menuname,linkaddress,menuicon,menusort,isenable,createtime,createman,updatetime,updateman from sys_menuinfo ");
            strSql.Append(" where menucode=?menucode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?menucode", MySqlDbType.VarChar,10)         };
            parameters[0].Value = menucode;

            MultiColorPen.Model.sys_menuinfo model = new MultiColorPen.Model.sys_menuinfo();
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
        public MultiColorPen.Model.sys_menuinfo DataRowToModel(DataRow row)
        {
            MultiColorPen.Model.sys_menuinfo model = new MultiColorPen.Model.sys_menuinfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["pmenucode"] != null)
                {
                    model.pmenucode = row["pmenucode"].ToString();
                }
                if (row["menucode"] != null)
                {
                    model.menucode = row["menucode"].ToString();
                }
                if (row["menuname"] != null)
                {
                    model.menuname = row["menuname"].ToString();
                }
                if (row["linkaddress"] != null)
                {
                    model.linkaddress = row["linkaddress"].ToString();
                }
                if (row["menuicon"] != null)
                {
                    model.menuicon = row["menuicon"].ToString();
                }
                if (row["menusort"] != null && row["menusort"].ToString() != "")
                {
                    model.menusort = int.Parse(row["menusort"].ToString());
                }
                if (row["isenable"] != null && row["isenable"].ToString() != "")
                {
                    model.isenable = int.Parse(row["isenable"].ToString());
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
            strSql.Append("select id,pmenucode,menucode,menuname,linkaddress,menuicon,menusort,isenable,createtime,createman,updatetime,updateman ");
            strSql.Append(" FROM sys_menuinfo ");
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
            strSql.Append("select count(1) FROM sys_menuinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM sys_menuinfo T ");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.menucode desc");
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
			parameters[0].Value = "sys_menuinfo";
			parameters[1].Value = "menucode";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public string GetMaxNo()
        {
            var dt = DbHelperMySQL.GetMaxID("menucode", "sys_menuinfo");
            return dt.ToString();
        }
        /// <summary> 
        /// 将一个object对象序列化，返回一个byte[]         
        /// </summary> 
        /// <param name="obj">能序列化的对象</param>         
        /// <returns></returns> 
        public static byte[] ObjectToBytes(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter(); formatter.Serialize(ms, obj); return ms.GetBuffer();
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MultiColorPen.Model.sys_menuinfo model, List<string> btncode)
        {
            List<CommandInfo> cmd_list = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_menuinfo set ");
            strSql.Append("pmenucode='{0}',");
            strSql.Append("menuname='{1}',");
            strSql.Append("linkaddress='{2}',");
            strSql.Append("menuicon='{3}',");
            strSql.Append("menusort='{4}',");
            strSql.Append("isenable='{5}',");
            strSql.Append("createtime='{6}',");
            strSql.Append("createman='{7}',");
            strSql.Append("updatetime='{8}',");
            strSql.Append("updateman='{9}'");
            strSql.Append(" where id='{10}'");

            string sql = string.Format(strSql.ToString(), model.pmenucode, model.menuname, model.linkaddress, model.menuicon, model.menusort, model.isenable, model.createtime, model.createman, model.updatetime, model.updateman, model.id);
            cmd_list.Add(new CommandInfo(sql, null));
            cmd_list.Add(new CommandInfo(string.Format("delete from sys_menubutton where menucode='{0}'", model.menucode), null));

            for (int i = 0; i < btncode.Count; i++)
            {
                cmd_list.Add(new CommandInfo(string.Format("insert into sys_menubutton(menucode,btncode) values('{0}','{1}')", model.menucode, btncode[i]), null));
            }
            int rows = DbHelperMySQL.ExecuteSqlTran(cmd_list);
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
        /// 根据菜单编号获取所属按钮
        /// </summary>
        /// <param name="menucode"></param>
        /// <returns></returns>
        public DataTable GetMenyButton(string menucode)
        {
            string t_sql = @"select a.btncode,btnicon,btnname from sys_menubutton a left join sys_buttoninfo b 
            on b.btncode=a.btncode where isenable=1 and a.menucode='" + menucode + "' order by btnsort asc";
            return DbHelperMySQL.Query(t_sql).Tables[0];
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MultiColorPen.Model.sys_menuinfo model, List<string> btncode)
        {
            List<CommandInfo> cmd_list = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_menuinfo(");
            strSql.Append("pmenucode,menucode,menuname,linkaddress,menuicon,menusort,isenable,createtime,createman,updatetime,updateman)");
            strSql.Append(" values (");
            strSql.Append("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')");
            strSql.Append(";");
            string sql = "";
            if (model.updatetime != null)
            {
                sql = string.Format(strSql.ToString(), model.pmenucode, model.menucode, model.menuname, model.linkaddress, model.menuicon, model.menusort, model.isenable, model.createtime, model.createman, model.updatetime, model.updateman);
            }
            else
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("insert into sys_menuinfo(");
                strSql1.Append("pmenucode,menucode,menuname,linkaddress,menuicon,menusort,isenable,createtime,createman)");
                strSql1.Append(" values (");
                strSql1.Append("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')");
                strSql1.Append(";");
                sql = string.Format(strSql1.ToString(), model.pmenucode, model.menucode, model.menuname, model.linkaddress, model.menuicon, model.menusort, model.isenable, model.createtime, model.createman);
            }
            cmd_list.Add(new CommandInfo(sql, null));
            for (int i = 0; i < btncode.Count; i++)
            {
                cmd_list.Add(new CommandInfo("insert into sys_menubutton(menucode,btncode) values('" + model.menucode + "','" + btncode[i].ToString() + "')", null));
            }
            return DbHelperMySQL.ExecuteSqlTran(cmd_list);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MultiColorPen.Model.sys_menuinfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pmenucode,menucode,menuname,linkaddress,menuicon,menusort,isenable,createtime,createman,updatetime,updateman from sys_menuinfo ");
            strSql.Append(" where id=" + id);

            MultiColorPen.Model.sys_menuinfo model = new MultiColorPen.Model.sys_menuinfo();
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_menuinfo ");
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

