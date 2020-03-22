using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using MultiColorPen.Model;
namespace MultiColorPen.BLL
{
    //sys_loginfo
    public partial class sys_loginfo
    {
        private MultiColorPen.DAL.sys_loginfo dal = new MultiColorPen.DAL.sys_loginfo();
        public sys_loginfo(string connStr = "")
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
        public int Add(MultiColorPen.Model.sys_loginfo model)
        {
            return dal.Add(model) ? 1 : 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(MultiColorPen.Model.sys_loginfo model)
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
        public MultiColorPen.Model.sys_loginfo GetModel(int id)
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
        //public DataTable GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dal.GetList(Top, strWhere, filedOrder);
        //}

        /// <summary>
        /// 获得对象数组
        /// </summary>
        public List<MultiColorPen.Model.sys_loginfo> GetModelList(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere).Tables[0]);
        }

        /// <summary>
        /// 根据DataTable转换成List对象数组
        /// </summary>
        public List<MultiColorPen.Model.sys_loginfo> DataTableToList(DataTable dt)
        {
            List<MultiColorPen.Model.sys_loginfo> modelList = new List<MultiColorPen.Model.sys_loginfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MultiColorPen.Model.sys_loginfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new MultiColorPen.Model.sys_loginfo();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.logtype = dt.Rows[n]["logtype"].ToString();
                    if (dt.Rows[n]["createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(dt.Rows[n]["createtime"].ToString());
                    }
                    model.usercode = dt.Rows[n]["usercode"].ToString();
                    model.username = dt.Rows[n]["username"].ToString();
                    model.ipaddress = dt.Rows[n]["ipaddress"].ToString();
                    model.logcontent = dt.Rows[n]["logcontent"].ToString();
                    model.datatable = dt.Rows[n]["datatable"].ToString();
                    model.dataid = dt.Rows[n]["dataid"].ToString();
                    model.dataold = dt.Rows[n]["dataold"].ToString();
                    model.datanew = dt.Rows[n]["datanew"].ToString();


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