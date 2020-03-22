using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiColorPen.COMMON;

namespace MultiColorPen.SSIA.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        [MultiColorPen.SSIA.FilterConfig.LoginCheckFilter(IsCheck = false)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [MultiColorPen.SSIA.FilterConfig.LoginCheckFilter(IsCheck = false)]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pwd"></param>
        /// <param name="vcode"></param>
        /// <returns></returns>
        [MultiColorPen.SSIA.FilterConfig.LoginCheckFilter(IsCheck = false)]
        [HttpPost]
        public string LogOn(string username, string pwd, string vcode)
        {
            string s_vcode = SessionHelper.ReadSession<string>(SessionKeys.CheckCodeKey);
            if (string.IsNullOrEmpty(s_vcode) || (!s_vcode.ToLower().Equals(vcode.ToLower())))
                return "vcode";
            DataTable u_dt = new BLL.base_userinfo().GetList("username='" + username + "'");
            if (u_dt != null && u_dt.Rows.Count > 0)
            {
                pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
                if (u_dt.Rows[0]["password"].ToString() == pwd)
                {
                    if (u_dt.Rows[0]["isenable"].ToString() == "0")
                        return "enable";
                    else
                    {
                        LoginInfo model = new LoginInfo
                        {
                            UserName = username,
                            PName = u_dt.Rows[0]["pname"].ToString(),
                            RoleCode = u_dt.Rows[0]["rolecode"].ToString(),
                            Phone = u_dt.Rows[0]["phone"].ToString(),
                        };
                        string token = Guid.NewGuid().ToString();
                        new BLL.base_userinfo().UpdateToken(username, token);
                        SessionHelper.WriteSession(SessionKeys.LoginStateCode, token);
                        SessionHelper.WriteSession(SessionKeys.LoginInfoKey, model);
                        PublicClass.AddLog("Login", "User " + model.PName + " Loin in System！");
                        return "success";
                    }
                }
                else
                    return "pwd";
            }
            else
                return "acc";
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        [MultiColorPen.SSIA.FilterConfig.LoginCheckFilter(IsCheck = false)]
        public ActionResult Logout()
        {
            SessionHelper.RemoveSession(SessionKeys.LoginInfoKey);
            SessionHelper.RemoveSession(SessionKeys.LoginStateCode);
            return View("Login");
        }


    }
}
