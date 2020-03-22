using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiColorPen.COMMON;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiColorPen.SSIA.Controllers
{
    public class SystemController : Controller
    {
        /// <summary>
        /// 系统功能
        /// </summary>
        /// <returns></returns>
        public ActionResult FunctionManage()
        {
            return View();
        }

        /// <summary>
        /// 菜单添加/修改保存
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public string FunctionSave(string json)
        {
            ResultInfo result = new ResultInfo(false);
            JObject jo = JObject.Parse(json);
            LoginInfo userInfo = SessionHelper.ReadSession<LoginInfo>(SessionKeys.LoginInfoKey);
            var bll = new MultiColorPen.BLL.sys_menuinfo();
            //新增
            if (jo["did"].ToString() == "-1")
            {
                string code = bll.GetMaxNo();
                var model = new MultiColorPen.Model.sys_menuinfo
                {
                    pmenucode = jo["pmenucode"].ToString(),
                    menucode = code,
                    menuname = jo["menuname"].ToString(),
                    menuicon = jo["menuicon"].ToString(),
                    linkaddress = jo["linkaddress"].ToString(),
                    isenable = 1,
                    createtime = DateTime.Now,
                    createman = userInfo.UserName
                };
                if (!string.IsNullOrEmpty(jo["menusort"].ToString()))
                    model.menusort = int.Parse(jo["menusort"].ToString());
                else
                    model.menusort = 99;
                var list = jo["btncode"];
                List<string> btncode = new List<string>();
                if (list != null && list.Count() > 0)
                {
                    for (int i = 0; i < list.Count(); i++)
                    {
                        btncode.Add(list[i].ToString());
                    }
                }
                if (bll.Add(model, btncode) > 0)
                {
                    result.IsSucceed = true;
                    result.Message = "Operation Successful!";
                    PublicClass.AddLog("Operating", "Add System Function" + model.menuname + "！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "Save Failed！";
                }
            }
            //修改
            else
            {
                int id = int.Parse(jo["did"].ToString());
                var umodel = bll.GetModel(id);
                umodel.pmenucode = jo["pmenucode"].ToString();
                umodel.menuname = jo["menuname"].ToString();
                umodel.menuicon = jo["menuicon"].ToString();
                if (!string.IsNullOrEmpty(jo["menusort"].ToString()))
                    umodel.menusort = int.Parse(jo["menusort"].ToString());
                else
                    umodel.menusort = 99;
                umodel.linkaddress = jo["linkaddress"].ToString();
                umodel.updateman = userInfo.UserName;
                umodel.updatetime = DateTime.Now;
                var list = jo["btncode"];
                List<string> btncode = new List<string>();
                if (list != null && list.Count() > 0)
                {
                    for (int i = 0; i < list.Count(); i++)
                    {
                        btncode.Add(list[i].ToString());
                    }
                }
                if (bll.Update(umodel, btncode))
                {
                    result.IsSucceed = true;
                    result.Message = "Operating Successful!";
                    PublicClass.AddLog("Operating", "Edit System Function" + umodel.menuname + "！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "Save Failed！";
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取单个菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string OneFunction(string id)
        {
            ResultInfo<List<object>> result = new ResultInfo<List<object>>();
            var bll = new MultiColorPen.BLL.sys_menuinfo();
            var dt = bll.GetList("menucode='" + id + "'").Tables[0];
            result.IsSucceed = true;
            result.Message = "获取成功！";
            result.Entity = JsonHelper.DataTableToList(dt);
            DataTable mb_dt = bll.GetMenyButton(id);
            List<object> mb_list = new List<object>();
            for (int i = 0; i < mb_dt.Rows.Count; i++)
            {
                mb_list.Add(mb_dt.Rows[i]["btncode"].ToString());
            }
            result.Extend = mb_list;
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DelFunction(string id)
        {
            ResultInfo result = new ResultInfo();
            DataTable dt = new BLL.sys_rolemenu().GetList("menucode = '" + id + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                result.IsSucceed = false;
                result.Message = "The menu is already in use and can not be deleted！";
            }
            else
            {
                if (new BLL.sys_rolemenu().Delete(id))
                {
                    result.IsSucceed = true;
                    result.Message = "Delete Successful!";
                    PublicClass.AddLog("Operating", "Delete Function！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "Delete Failed!";
                }
            }
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 按钮管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ButtonManage()
        {
            return View();
        }

        /// <summary>
        /// 获取按钮列表数据
        /// </summary>
        /// <returns></returns>
        public string GetAllButtons()
        {
            ResultInfo<List<object>> data = new ResultInfo<List<object>>();
            var dt = new MultiColorPen.BLL.sys_buttoninfo().GetList("").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                data.IsSucceed = true;
                data.Message = "Get Data！";
                data.TotalCount = dt.Rows.Count;
            }
            else
            {
                data.IsSucceed = false;
                data.Message = "No operational data available！";
                data.TotalCount = 0;
            }
            data.Entity = JsonHelper.DataTableToList(dt);
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 按钮添加/修改保存
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public string BtnManageSave(string json)
        {
            ResultInfo result = new ResultInfo(false);
            JObject jo = JObject.Parse(json);
            LoginInfo userInfo = SessionHelper.ReadSession<LoginInfo>(SessionKeys.LoginInfoKey);
            var bll = new MultiColorPen.BLL.sys_buttoninfo();
            //新增
            if (jo["id"].ToString() == "-1")
            {
                var model = new MultiColorPen.Model.sys_buttoninfo
                {
                    btncode = bll.GetMaxNo(),
                    btnname = jo["btnname"].ToString(),
                    btnclass = jo["btnclass"].ToString(),
                    btnicon = jo["btnicon"].ToString(),
                    btnmethod = jo["btnmethod"].ToString(),
                    isenable = 1,
                    createtime = DateTime.Now,
                    createman = userInfo.UserName
                };
                if (!string.IsNullOrEmpty(jo["btnsort"].ToString()))
                    model.btnsort = int.Parse(jo["btnsort"].ToString());
                else
                    model.btnsort = 99;
                if (bll.Add(model) > 0)
                {
                    result.IsSucceed = true;
                    result.Message = "Save Successful!";
                    PublicClass.AddLog("Operating", "Add Button！" + model.btnname + "！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "Save Failed!";
                }
            }
            //修改
            else
            {
                int id = int.Parse(jo["id"].ToString());
                var umodel = bll.GetModel(id);
                umodel.btnname = jo["btnname"].ToString();
                umodel.btnclass = jo["btnclass"].ToString();
                umodel.btnicon = jo["btnicon"].ToString();
                umodel.btnmethod = jo["btnmethod"].ToString();
                if (!string.IsNullOrEmpty(jo["btnsort"].ToString()))
                    umodel.btnsort = int.Parse(jo["btnsort"].ToString());
                else
                    umodel.btnsort = 99;
                umodel.updateman = userInfo.UserName;
                umodel.updatetime = DateTime.Now;
                if (bll.Update(umodel))
                {
                    result.IsSucceed = true;
                    result.Message = "Save Successful!";
                    PublicClass.AddLog("Operating", "Edit Button！" + umodel.btnname + "！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "Save Failed!";
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string BtnManageDelete(int id)
        {
            ResultInfo<string> result = new ResultInfo<string>();
            if (new MultiColorPen.BLL.sys_buttoninfo().Delete(id))
            {
                result.IsSucceed = true;
                result.Message = "Save Successful!";
                PublicClass.AddLog("Operating", "Delete Button！");
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "Save Failed!";
            }
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 按钮启用或禁用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ised"></param>
        /// <returns></returns>
        public string BtnEnableOrDisabled(int id, string ised)
        {
            ResultInfo<string> result = new ResultInfo<string>();
            var bll = new MultiColorPen.BLL.sys_buttoninfo();
            var model = bll.GetModel(id);
            model.isenable = int.Parse(ised);
            if (bll.Update(model))
            {
                result.IsSucceed = true;

                result.Message = "Operation Successful！";
                PublicClass.AddLog("Operating", model.isenable == 1 ? "Enable button：" + model.btnname + " " : "Disable button：" + model.btnname + " ");
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "Operation Failed！";
            }
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleManage()
        {
            return View();
        }

        /// <summary>
        /// 新增、修改角色保存
        /// </summary>
        /// <returns></returns>
        public string RoleSave(string json)
        {
            ResultInfo result = new ResultInfo(false);
            JObject jo = JObject.Parse(json);
            LoginInfo userInfo = SessionHelper.ReadSession<LoginInfo>(SessionKeys.LoginInfoKey);
            BLL.sys_roleinfo bll = new BLL.sys_roleinfo();
            //新增
            if (jo["id"].ToString() == "-1")
            {
                MultiColorPen.Model.sys_roleinfo model = new MultiColorPen.Model.sys_roleinfo
                {
                    rolecode = bll.GetMaxNo(),
                    rolename = jo["rolename"].ToString(),
                    isenable = 1,
                    remark = jo["remark"].ToString(),
                    createtime = DateTime.Now,
                    createman = userInfo.UserName
                };
                if (!string.IsNullOrEmpty(jo["rolesort"].ToString()))
                    model.rolesort = int.Parse(jo["rolesort"].ToString());
                else
                    model.rolesort = 99;
                if (bll.Add(model) > 0)
                {
                    result.IsSucceed = true;
                    result.Message = "Save Successful!";
                    PublicClass.AddLog("Operating", "Add Role" + model.rolename + "！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "Save Failed!";
                }
            }
            else//修改
            {
                string id = jo["id"].ToString();
                var umodel = bll.GetModel(id);
                umodel.rolename = jo["rolename"].ToString();
                if (!string.IsNullOrEmpty(jo["rolesort"].ToString()))
                    umodel.rolesort = int.Parse(jo["rolesort"].ToString());
                else
                    umodel.rolesort = 99;
                umodel.remark = jo["remark"].ToString();
                umodel.updateman = userInfo.UserName;
                umodel.updatetime = DateTime.Now;
                if (bll.Update(umodel))
                {
                    result.IsSucceed = true;
                    result.Message = "Save Successful!";
                    PublicClass.AddLog("Operating", "Edit Role" + umodel.rolename + "！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "Save Failed!";
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetRoleInfo(string id)
        {
            ResultInfo<object> result = new ResultInfo<object>();
            DataTable dt = new BLL.sys_roleinfo().GetList("rolecode='" + id + "'").Tables[0];
            result.IsSucceed = true;
            result.Message = "GetData！";
            result.Entity = JsonHelper.DataTableToList(dt);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DelRoleManage(string id)
        {
            ResultInfo result = new ResultInfo();
            DataTable dt = new BLL.base_userinfo().GetList("rolecode like '%" + id + "%'");
            if (dt != null && dt.Rows.Count > 0)
            {
                result.IsSucceed = false;
                result.Message = "The role is already in use and can not be deleted！";
            }
            else
            {
                if (new BLL.sys_roleinfo().Delete(id))
                {
                    result.IsSucceed = true;
                    result.Message = "Delet Successful！";
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "Delete Failed！";
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取角色菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetRoleMenu(string id)
        {
            BLL.sys_menuinfo bll = new BLL.sys_menuinfo();
            DataTable dt = bll.GetList("isenable='1' order by menusort asc ").Tables[0];
            DataTable p_dt = dt.Select("pmenucode='-1'").CopyToDataTable();
            DataTable rm_dt = new BLL.sys_rolemenu().GetList("rolecode='" + id + "'");
            List<object> rlist = new List<object>();
            for (int i = 0; i < p_dt.Rows.Count; i++)
            {
                int mcount = 0;
                string menucode = p_dt.Rows[i]["menucode"].ToString();
                Dictionary<string, object> plist = new Dictionary<string, object>();
                plist.Add("id", menucode);
                plist.Add("name", p_dt.Rows[i]["menuname"].ToString());
                plist.Add("icon", p_dt.Rows[i]["menuicon"].ToString());
                List<object> clist = new List<object>();
                DataRow[] dr = dt.Select("pmenucode='" + menucode + "'");
                for (int j = 0; j < dr.Length; j++)
                {
                    menucode = dr[j]["menucode"].ToString();
                    Dictionary<string, object> pclist = new Dictionary<string, object>();
                    pclist.Add("id", menucode);
                    pclist.Add("name", dr[j]["menuname"].ToString());
                    pclist.Add("icon", dr[j]["menuicon"].ToString());
                    DataRow[] rm_dr = rm_dt.Select("menucode='" + menucode + "'");
                    if (rm_dr.Length == 1)
                    {
                        mcount += 1;
                        pclist.Add("check", "1");
                    }
                    else
                        pclist.Add("check", "0");
                    DataTable b_dt = bll.GetMenyButton(menucode);
                    List<object> blist = new List<object>();
                    for (int b = 0; b < b_dt.Rows.Count; b++)
                    {
                        string btncode = b_dt.Rows[b]["btncode"].ToString();
                        Dictionary<string, object> bpclist = new Dictionary<string, object>();
                        bpclist.Add("id", btncode);
                        bpclist.Add("name", b_dt.Rows[b]["btnname"].ToString());
                        bpclist.Add("icon", b_dt.Rows[b]["btnicon"].ToString());
                        if (rm_dr.Length > 0)
                        {
                            if (rm_dr[0]["btncode"].ToString().Contains(btncode))
                                bpclist.Add("check", "1");
                            else
                                bpclist.Add("check", "0");
                        }
                        else
                            bpclist.Add("check", "0");
                        blist.Add(bpclist);
                    }
                    pclist.Add("btndata", blist);
                    clist.Add(pclist);
                }
                if (mcount == dr.Length)
                    plist.Add("check", "1");
                else
                    plist.Add("check", "0");
                plist.Add("cmdata", clist);
                rlist.Add(plist);
            }
            ResultInfo<object> result = new ResultInfo<object>();
            if (rlist.Count > 0)
            {
                result.IsSucceed = true;
                result.Message = "The load menu is successful！";
            }
            else
            {
                result.IsSucceed = true;
                result.Message = "The load menu is Fail！";
            }
            result.Entity = rlist;
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="request_str"></param>
        /// <param name="rolecode"></param>
        /// <returns></returns>
        public string SaveRoleMenu(string request_str, string rolecode)
        {
            ResultInfo result = new ResultInfo();
            if (new BLL.sys_rolemenu().SaveRoleMenu(rolecode, request_str) > 0)
            {
                result.IsSucceed = true;
                result.Message = "Save Successful！";
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "Save Fail！";
            }
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取权限按钮
        /// </summary>
        /// <param name="menucode"></param>
        /// <returns></returns>
        public string GetRoleMenuButton(string menucode, string ctype)
        {
            ResultInfo<object> result = new ResultInfo<object>();
            LoginInfo li = SessionHelper.ReadSession(SessionKeys.LoginInfoKey);
            result.IsSucceed = true;
            if (ctype == "1")
                result.Entity = new BLL.sys_rolemenu().GetRoleMenuButton(li.RoleCode, menucode);
            else
                result.Entity = JsonHelper.DataTableToList(new BLL.sys_rolemenu().GetRoleMenuButtonInfo(li.RoleCode, menucode));
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 日志管理
        /// </summary>
        /// <returns></returns>
        public ActionResult LogManage()
        {
            return View();
        }

        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <returns></returns>
        public string GetLogList()
        {
            ResultInfo<List<object>> data = new ResultInfo<List<object>>();
            int pageSize = int.Parse(Request.Params["pagesize"]);
            int pageNo = int.Parse(Request.Params["pageno"]);
            string order = Request.Params["order"];
            string logtype = Request.Params["logtype"];
            string datest = Request.Params["datest"];
            string dateed = Request.Params["dateed"];
            //查询条件组织
            string where = string.Empty;
            if (!string.IsNullOrEmpty(logtype))
                where += "logtype='" + logtype + "' and ";
            if (!string.IsNullOrEmpty(datest))
                where += "createtime>='" + DateTime.Parse(datest).ToString("yyyy-MM-dd 00:00:00") + "' and ";
            if (!string.IsNullOrEmpty(dateed))
                where += "createtime<='" + DateTime.Parse(dateed).ToString("yyyy-MM-dd 23:59:59") + "' and ";

            if (!string.IsNullOrEmpty(where))
                where = where.Substring(0, where.Length - 4);
            int startIndex = pageSize * (pageNo - 1) + 1;
            int endIndex = pageSize * pageNo;
            var dt = new MultiColorPen.BLL.sys_loginfo().GetListByPage(where, order, startIndex, endIndex);
            data.IsSucceed = true;
            data.TotalCount = new BLL.sys_loginfo().GetRecordCount(where);
            data.Entity = JsonHelper.DataTableToList(dt);
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 日志删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string LogManageDelete(int id)
        {
            ResultInfo<string> result = new ResultInfo<string>();
            if (new MultiColorPen.BLL.sys_loginfo().Delete(id))
            {
                result.IsSucceed = true;
                result.Message = "Save Successful!";
                PublicClass.AddLog("Operating", "Delete Log！");
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "operation failed!";
            }
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <returns></returns>
        [MultiColorPen.SSIA.FilterConfig.LoginCheckFilter(IsCheck = false)]
        [MultiColorPen.SSIA.FilterConfig.MyHandleError(IsCheck = false)]
        public string UpdateUserPwd(string pwd)
        {
            pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
            LoginInfo li = SessionHelper.ReadSession<LoginInfo>(SessionKeys.LoginInfoKey);
            ResultInfo result = new ResultInfo(false);
            if (new MultiColorPen.BLL.base_userinfo().UpdatePwd(li.UserName, pwd))
            {
                result.IsSucceed = true;
                result.Message = "Operating successful！";
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "operation failed！";
            }
            return JsonConvert.SerializeObject(result);
        }

    }
}
