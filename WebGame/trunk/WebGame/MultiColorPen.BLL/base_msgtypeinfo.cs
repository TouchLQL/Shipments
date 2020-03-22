using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using MultiColorPen.Model;
namespace MultiColorPen.BLL
{
    //base_msgtypeinfo
    public partial class base_msgtypeinfo
    {
        private MultiColorPen.DAL.base_msgtypeinfo dal = new MultiColorPen.DAL.base_msgtypeinfo();
        public base_msgtypeinfo(string connStr = "")
        {
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string msgtypecode)
        {
            return dal.Exists(msgtypecode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MultiColorPen.Model.base_msgtypeinfo model)
        {
            return dal.Add(model) ? 1 : 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(MultiColorPen.Model.base_msgtypeinfo model)
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
        public MultiColorPen.Model.base_msgtypeinfo GetModel(int id)
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
        //public DataTable GetList(int Top,string strWhere,string filedOrder)
        //{
        //	return dal.GetList(Top,strWhere,filedOrder);
        //}

        /// <summary>
        /// 获得对象数组
        /// </summary>
        public List<MultiColorPen.Model.base_msgtypeinfo> GetModelList(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere).Tables[0]);
        }

        /// <summary>
        /// 根据DataTable转换成List对象数组
        /// </summary>
        public List<MultiColorPen.Model.base_msgtypeinfo> DataTableToList(DataTable dt)
        {
            List<MultiColorPen.Model.base_msgtypeinfo> modelList = new List<MultiColorPen.Model.base_msgtypeinfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MultiColorPen.Model.base_msgtypeinfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new MultiColorPen.Model.base_msgtypeinfo();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.msgtypecode = dt.Rows[n]["msgtypecode"].ToString();
                    model.msgtypename = dt.Rows[n]["msgtypename"].ToString();
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
                    if (dt.Rows[n]["updatetime"].ToString() != "")
                    {
                        model.updatetime = DateTime.Parse(dt.Rows[n]["updatetime"].ToString());
                    }
                    model.updateman = dt.Rows[n]["updateman"].ToString();


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