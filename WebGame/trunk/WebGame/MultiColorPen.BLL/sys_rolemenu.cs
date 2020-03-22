using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using MultiColorPen.Model;
namespace MultiColorPen.BLL
{
    //sys_rolemenu
    public partial class sys_rolemenu
    {
        private MultiColorPen.DAL.sys_rolemenu dal = new MultiColorPen.DAL.sys_rolemenu();
        public sys_rolemenu(string connStr = "")
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
        public int Add(MultiColorPen.Model.sys_rolemenu model)
        {
            return dal.Add(model)?1:0;
        }

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="rolecode">角色编号</param>
        /// <param name="r_str">菜单按钮编号字符串</param>
        /// <returns></returns>
        public int SaveRoleMenu(string rolecode, string r_str)
        {
            return dal.SaveRoleMenu(rolecode, r_str);
        }

        /// <summary>
        /// 获取用户角色权限按钮
        /// </summary>
        public string GetRoleMenuButton(string rolecode, string menucode)
        {
            return dal.GetRoleMenuButton(rolecode, menucode);
        }

        /// <summary>
        /// 获取用户角色权限按钮
        /// </summary>
        public DataTable GetRoleMenuButtonInfo(string rolecode, string menucode)
        {
            return dal.GetRoleMenuButtonInfo(rolecode, menucode);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(MultiColorPen.Model.sys_rolemenu model)
        {
            return dal.Update(model)?1:0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
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
        public MultiColorPen.Model.sys_rolemenu GetModel(int id)
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
        public List<MultiColorPen.Model.sys_rolemenu> GetModelList(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere).Tables[0]);
        }

        /// <summary>
        /// 根据DataTable转换成List对象数组
        /// </summary>
        public List<MultiColorPen.Model.sys_rolemenu> DataTableToList(DataTable dt)
        {
            List<MultiColorPen.Model.sys_rolemenu> modelList = new List<MultiColorPen.Model.sys_rolemenu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MultiColorPen.Model.sys_rolemenu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new MultiColorPen.Model.sys_rolemenu();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.rolecode = dt.Rows[n]["rolecode"].ToString();
                    model.menucode = dt.Rows[n]["menucode"].ToString();
                    model.btncode = dt.Rows[n]["btncode"].ToString();
                    if (dt.Rows[n]["createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(dt.Rows[n]["createtime"].ToString());
                    }
                    model.createman = dt.Rows[n]["createman"].ToString();


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