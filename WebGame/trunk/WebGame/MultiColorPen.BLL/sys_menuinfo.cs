/*
* sys_menuinfo.cs
* 2015-05-17
* 功 能： 菜单管理
* 类 名： sys_menuinfo
*/
using System;
using System.Data;
using System.Collections.Generic;
using MultiColorPen.Model;
namespace MultiColorPen.BLL
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public partial class sys_menuinfo
    {
        private readonly MultiColorPen.DAL.sys_menuinfo dal = new MultiColorPen.DAL.sys_menuinfo();
        public sys_menuinfo()
        { }

        /// <summary>
        /// 获取菜单编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxNo()
        {
            return dal.GetMaxNo();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MultiColorPen.Model.sys_menuinfo MODEL, List<string> btncode)
        {
            return dal.Add(MODEL, btncode);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MultiColorPen.Model.sys_menuinfo MODEL, List<string> btncode)
        {
            return dal.Update(MODEL, btncode) ;
        }

        /// <summary>
        /// 根据菜单编号获取所属按钮
        /// </summary>
        /// <param name="menucode"></param>
        /// <returns></returns>
        public DataTable GetMenyButton(string menucode)
        {
            return dal.GetMenyButton(menucode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string menucode)
        {

            return dal.Delete(menucode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MultiColorPen.Model.sys_menuinfo GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public MultiColorPen.Model.sys_menuinfo GetModelByCache(int id)
        //{
        //    return dal.GetModel(id);
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dal.GetList(Top, strWhere, filedOrder);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MultiColorPen.Model.sys_menuinfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MultiColorPen.Model.sys_menuinfo> DataTableToList(DataTable dt)
        {
            List<MultiColorPen.Model.sys_menuinfo> modelList = new List<MultiColorPen.Model.sys_menuinfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MultiColorPen.Model.sys_menuinfo MODEL;
                for (int n = 0; n < rowsCount; n++)
                {
                    MODEL = dal.DataRowToModel(dt.Rows[n]);
                    if (MODEL != null)
                    {
                        modelList.Add(MODEL);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}

