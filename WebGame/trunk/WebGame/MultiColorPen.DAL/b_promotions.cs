using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MultiColorPen.DAL
{
    /// <summary>
    /// 数据访问类:b_promotions
    /// </summary>
    public partial class b_promotions
    {
        public b_promotions()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string promotioncode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from b_promotions");
            strSql.Append(" where promotioncode=?promotioncode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?promotioncode", MySqlDbType.VarChar,30)            };
            parameters[0].Value = promotioncode;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MultiColorPen.Model.b_promotions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into b_promotions(");
            strSql.Append("id,promotioncode,caragentcode,caragentname,brandcode,brandname,seriescode,seriesname,title,detail,url,keywords,begintime,endtime,isenable,sort,remark,createtime,createman,updatetime,updateman)");
            strSql.Append(" values (");
            strSql.Append("?id,?promotioncode,?caragentcode,?caragentname,?brandcode,?brandname,?seriescode,?seriesname,?title,?detail,?url,?keywords,?begintime,?endtime,?isenable,?sort,?remark,?createtime,?createman,?updatetime,?updateman)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?promotioncode", MySqlDbType.VarChar,30),
                    new MySqlParameter("?caragentcode", MySqlDbType.VarChar,30),
                    new MySqlParameter("?caragentname", MySqlDbType.VarChar,50),
                    new MySqlParameter("?brandcode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?brandname", MySqlDbType.VarChar,30),
                    new MySqlParameter("?seriescode", MySqlDbType.Text),
                    new MySqlParameter("?seriesname", MySqlDbType.Text),
                    new MySqlParameter("?title", MySqlDbType.VarChar,200),
                    new MySqlParameter("?detail", MySqlDbType.Text),
                    new MySqlParameter("?url", MySqlDbType.Text),
                    new MySqlParameter("?keywords", MySqlDbType.VarChar,200),
                    new MySqlParameter("?begintime", MySqlDbType.DateTime),
                    new MySqlParameter("?endtime", MySqlDbType.DateTime),
                    new MySqlParameter("?isenable", MySqlDbType.Int32,11),
                    new MySqlParameter("?sort", MySqlDbType.Int32,11),
                    new MySqlParameter("?remark", MySqlDbType.VarChar,200),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?updatetime", MySqlDbType.DateTime),
                    new MySqlParameter("?updateman", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.promotioncode;
            parameters[2].Value = model.caragentcode;
            parameters[3].Value = model.caragentname;
            parameters[4].Value = model.brandcode;
            parameters[5].Value = model.brandname;
            parameters[6].Value = model.seriescode;
            parameters[7].Value = model.seriesname;
            parameters[8].Value = model.title;
            parameters[9].Value = model.detail;
            parameters[10].Value = model.url;
            parameters[11].Value = model.keywords;
            parameters[12].Value = model.begintime;
            parameters[13].Value = model.endtime;
            parameters[14].Value = model.isenable;
            parameters[15].Value = model.sort;
            parameters[16].Value = model.remark;
            parameters[17].Value = model.createtime;
            parameters[18].Value = model.createman;
            parameters[19].Value = model.updatetime;
            parameters[20].Value = model.updateman;

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
        public bool Update(MultiColorPen.Model.b_promotions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update b_promotions set ");
            strSql.Append("id=?id,");
            strSql.Append("caragentcode=?caragentcode,");
            strSql.Append("caragentname=?caragentname,");
            strSql.Append("brandcode=?brandcode,");
            strSql.Append("brandname=?brandname,");
            strSql.Append("seriescode=?seriescode,");
            strSql.Append("seriesname=?seriesname,");
            strSql.Append("title=?title,");
            strSql.Append("detail=?detail,");
            strSql.Append("url=?url,");
            strSql.Append("keywords=?keywords,");
            strSql.Append("begintime=?begintime,");
            strSql.Append("endtime=?endtime,");
            strSql.Append("isenable=?isenable,");
            strSql.Append("sort=?sort,");
            strSql.Append("remark=?remark,");
            strSql.Append("createtime=?createtime,");
            strSql.Append("createman=?createman,");
            strSql.Append("updatetime=?updatetime,");
            strSql.Append("updateman=?updateman");
            strSql.Append(" where promotioncode=?promotioncode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,11),
                    new MySqlParameter("?caragentcode", MySqlDbType.VarChar,30),
                    new MySqlParameter("?caragentname", MySqlDbType.VarChar,50),
                    new MySqlParameter("?brandcode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?brandname", MySqlDbType.VarChar,30),
                    new MySqlParameter("?seriescode", MySqlDbType.Text),
                    new MySqlParameter("?seriesname", MySqlDbType.Text),
                    new MySqlParameter("?title", MySqlDbType.VarChar,200),
                    new MySqlParameter("?detail", MySqlDbType.Text),
                    new MySqlParameter("?url", MySqlDbType.Text),
                    new MySqlParameter("?keywords", MySqlDbType.VarChar,200),
                    new MySqlParameter("?begintime", MySqlDbType.DateTime),
                    new MySqlParameter("?endtime", MySqlDbType.DateTime),
                    new MySqlParameter("?isenable", MySqlDbType.Int32,11),
                    new MySqlParameter("?sort", MySqlDbType.Int32,11),
                    new MySqlParameter("?remark", MySqlDbType.VarChar,200),
                    new MySqlParameter("?createtime", MySqlDbType.DateTime),
                    new MySqlParameter("?createman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?updatetime", MySqlDbType.DateTime),
                    new MySqlParameter("?updateman", MySqlDbType.VarChar,36),
                    new MySqlParameter("?promotioncode", MySqlDbType.VarChar,30)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.caragentcode;
            parameters[2].Value = model.caragentname;
            parameters[3].Value = model.brandcode;
            parameters[4].Value = model.brandname;
            parameters[5].Value = model.seriescode;
            parameters[6].Value = model.seriesname;
            parameters[7].Value = model.title;
            parameters[8].Value = model.detail;
            parameters[9].Value = model.url;
            parameters[10].Value = model.keywords;
            parameters[11].Value = model.begintime;
            parameters[12].Value = model.endtime;
            parameters[13].Value = model.isenable;
            parameters[14].Value = model.sort;
            parameters[15].Value = model.remark;
            parameters[16].Value = model.createtime;
            parameters[17].Value = model.createman;
            parameters[18].Value = model.updatetime;
            parameters[19].Value = model.updateman;
            parameters[20].Value = model.promotioncode;

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
        public bool Delete(string promotioncode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from b_promotions ");
            strSql.Append(" where promotioncode=?promotioncode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?promotioncode", MySqlDbType.VarChar,30)            };
            parameters[0].Value = promotioncode;

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
        public bool DeleteList(string promotioncodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from b_promotions ");
            strSql.Append(" where promotioncode in (" + promotioncodelist + ")  ");
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
        public MultiColorPen.Model.b_promotions GetModel(string promotioncode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,promotioncode,caragentcode,caragentname,brandcode,brandname,seriescode,seriesname,title,detail,url,keywords,begintime,endtime,isenable,sort,remark,createtime,createman,updatetime,updateman from b_promotions ");
            strSql.Append(" where promotioncode=?promotioncode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?promotioncode", MySqlDbType.VarChar,30)            };
            parameters[0].Value = promotioncode;

            MultiColorPen.Model.b_promotions model = new MultiColorPen.Model.b_promotions();
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
        public MultiColorPen.Model.b_promotions DataRowToModel(DataRow row)
        {
            MultiColorPen.Model.b_promotions model = new MultiColorPen.Model.b_promotions();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["promotioncode"] != null)
                {
                    model.promotioncode = row["promotioncode"].ToString();
                }
                if (row["caragentcode"] != null)
                {
                    model.caragentcode = row["caragentcode"].ToString();
                }
                if (row["caragentname"] != null)
                {
                    model.caragentname = row["caragentname"].ToString();
                }
                if (row["brandcode"] != null)
                {
                    model.brandcode = row["brandcode"].ToString();
                }
                if (row["brandname"] != null)
                {
                    model.brandname = row["brandname"].ToString();
                }
                if (row["seriescode"] != null)
                {
                    model.seriescode = row["seriescode"].ToString();
                }
                if (row["seriesname"] != null)
                {
                    model.seriesname = row["seriesname"].ToString();
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["detail"] != null)
                {
                    model.detail = row["detail"].ToString();
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["keywords"] != null)
                {
                    model.keywords = row["keywords"].ToString();
                }
                if (row["begintime"] != null && row["begintime"].ToString() != "")
                {
                    model.begintime = DateTime.Parse(row["begintime"].ToString());
                }
                if (row["endtime"] != null && row["endtime"].ToString() != "")
                {
                    model.endtime = DateTime.Parse(row["endtime"].ToString());
                }
                if (row["isenable"] != null && row["isenable"].ToString() != "")
                {
                    model.isenable = int.Parse(row["isenable"].ToString());
                }
                if (row["sort"] != null && row["sort"].ToString() != "")
                {
                    model.sort = int.Parse(row["sort"].ToString());
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
            strSql.Append("select id,promotioncode,caragentcode,caragentname,brandcode,brandname,seriescode,seriesname,title,detail,url,keywords,begintime,endtime,isenable,sort,remark,createtime,createman,updatetime,updateman ");
            strSql.Append(" FROM b_promotions ");
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
            strSql.Append("select count(1) FROM b_promotions ");
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
            strSql.Append("SELECT * FROM b_promotions T ");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.promotioncode desc");
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
			parameters[0].Value = "b_promotions";
			parameters[1].Value = "promotioncode";
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from b_promotions ");
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MultiColorPen.Model.b_promotions GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, promotioncode, caragentcode, caragentname, brandcode, brandname, seriescode, seriesname, title, detail, url, keywords, begintime, endtime, isenable, sort, remark, createtime, createman, updatetime, updateman  ");
            strSql.Append("  from b_promotions ");
            strSql.Append(" where id=" + id);


            MultiColorPen.Model.b_promotions model = new MultiColorPen.Model.b_promotions();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.promotioncode = ds.Tables[0].Rows[0]["promotioncode"].ToString();
                model.caragentcode = ds.Tables[0].Rows[0]["caragentcode"].ToString();
                model.caragentname = ds.Tables[0].Rows[0]["caragentname"].ToString();
                model.brandcode = ds.Tables[0].Rows[0]["brandcode"].ToString();
                model.brandname = ds.Tables[0].Rows[0]["brandname"].ToString();
                model.seriescode = ds.Tables[0].Rows[0]["seriescode"].ToString();
                model.seriesname = ds.Tables[0].Rows[0]["seriesname"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.detail = ds.Tables[0].Rows[0]["detail"].ToString();
                model.url = ds.Tables[0].Rows[0]["url"].ToString();
                model.keywords = ds.Tables[0].Rows[0]["keywords"].ToString();
                if (ds.Tables[0].Rows[0]["begintime"].ToString() != "")
                {
                    model.begintime = DateTime.Parse(ds.Tables[0].Rows[0]["begintime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["endtime"].ToString() != "")
                {
                    model.endtime = DateTime.Parse(ds.Tables[0].Rows[0]["endtime"].ToString());
                }
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

        #endregion  ExtensionMethod
    }
}

