using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using MultiColorPen.Model;
namespace MultiColorPen.BLL
{
    //base_userinfo
    public partial class base_userinfo
    {
        private MultiColorPen.DAL.base_userinfo dal = new DAL.base_userinfo();       

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string username)
        {
            return dal.Exists(username);
        }

        /// <summary>
        /// 获取最大
        /// </summary>
        /// <returns></returns>
        public string GetMaxNo()
        {
            return dal.GetMaxNo();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MultiColorPen.Model.base_userinfo model)
        {
            return dal.Add(model)?1:0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(MultiColorPen.Model.base_userinfo model)
        {
            return dal.Update(model) ? 1 : 0;
        }

        /// <summary>
        /// 更新登录唯一值
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="token">Guid</param>
        /// <returns></returns>
        public int UpdateToken(string username, string token)
        {
            return dal.UpdateToken(username, token);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdatePwd(string username, string pwd)
        {
            return dal.UpdatePwd(username, pwd);
        }

        /// <summary>
        /// 验证登录唯一值
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="token">Guid</param>
        /// <returns></returns>
        public int CheckLoginToken(string username, string token)
        {
            return dal.CheckLoginToken(username, token);
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
        public MultiColorPen.Model.base_userinfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据条件获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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
        public List<MultiColorPen.Model.base_userinfo> GetModelList(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere));
        }

        /// <summary>
        /// 根据DataTable转换成List对象数组
        /// </summary>
        public List<MultiColorPen.Model.base_userinfo> DataTableToList(DataTable dt)
        {
            List<MultiColorPen.Model.base_userinfo> modelList = new List<MultiColorPen.Model.base_userinfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MultiColorPen.Model.base_userinfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new MultiColorPen.Model.base_userinfo();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["pid"].ToString() != "")
                    {
                        model.pid = int.Parse(dt.Rows[n]["pid"].ToString());
                    }
                    model.username = dt.Rows[n]["username"].ToString();
                    model.password = dt.Rows[n]["password"].ToString();
                    model.usercode = dt.Rows[n]["usercode"].ToString();
                    model.rolecode = dt.Rows[n]["rolecode"].ToString();
                    if (dt.Rows[n]["isenable"].ToString() != "")
                    {
                        model.isenable = int.Parse(dt.Rows[n]["isenable"].ToString());
                    }
                    model.pname = dt.Rows[n]["pname"].ToString();
                    model.sex = dt.Rows[n]["sex"].ToString();
                    model.age = dt.Rows[n]["age"].ToString();
                    if (dt.Rows[n]["birthday"].ToString() != "")
                    {
                        model.birthday = DateTime.Parse(dt.Rows[n]["birthday"].ToString());
                    }
                    model.phone = dt.Rows[n]["phone"].ToString();
                    model.avatar = dt.Rows[n]["avatar"].ToString();
                    model.qq = dt.Rows[n]["qq"].ToString();
                    model.wechat = dt.Rows[n]["wechat"].ToString();
                    model.email = dt.Rows[n]["email"].ToString();
                    model.token = dt.Rows[n]["token"].ToString();
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