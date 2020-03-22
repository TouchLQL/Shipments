using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using MultiColorPen.Model;
namespace MultiColorPen.BLL
{
    //b_caragentseries
    public partial class b_caragentseries
    {
        private MultiColorPen.DAL.b_caragentseries dal = new MultiColorPen.DAL.b_caragentseries();
        public b_caragentseries(string connStr = "")
        {
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MultiColorPen.Model.b_caragentseries model)
        {
            return dal.Add(model)?1:0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(MultiColorPen.Model.b_caragentseries model)
        {
            return dal.Update(model) ? 1 : 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MultiColorPen.Model.b_caragentseries GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据条件获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere).Tables[0];
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得对象数组
        /// </summary>
        public List<MultiColorPen.Model.b_caragentseries> GetModelList(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere).Tables[0]);
        }

        /// <summary>
        /// 根据DataTable转换成List对象数组
        /// </summary>
        public List<MultiColorPen.Model.b_caragentseries> DataTableToList(DataTable dt)
        {
            List<MultiColorPen.Model.b_caragentseries> modelList = new List<MultiColorPen.Model.b_caragentseries>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MultiColorPen.Model.b_caragentseries model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new MultiColorPen.Model.b_caragentseries();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.caragentcode = dt.Rows[n]["caragentcode"].ToString();
                    model.seriescode = dt.Rows[n]["seriescode"].ToString();
                    model.brandcode = dt.Rows[n]["brandcode"].ToString();
                    model.brandname = dt.Rows[n]["brandname"].ToString();
                    if (dt.Rows[n]["isenable"].ToString() != "")
                    {
                        model.isenable = int.Parse(dt.Rows[n]["isenable"].ToString());
                    }
                    if (dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    model.remark = dt.Rows[n]["remark"].ToString();
                    if (dt.Rows[n]["createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(dt.Rows[n]["createtime"].ToString());
                    }
                    model.createman = dt.Rows[n]["createman"].ToString();
                    if (dt.Rows[n]["isdelete"].ToString() != "")
                    {
                        model.isdelete = int.Parse(dt.Rows[n]["isdelete"].ToString());
                    }
                    if (dt.Rows[n]["deletetime"].ToString() != "")
                    {
                        model.deletetime = DateTime.Parse(dt.Rows[n]["deletetime"].ToString());
                    }
                    model.deleteman = dt.Rows[n]["deleteman"].ToString();


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0];
        }
        #endregion
    }
}