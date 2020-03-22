using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiColorPen.COMMON
{
    /// <summary>
    /// Session的Key值
    /// </summary>
    public class SessionKeys
    {
        public SessionKeys() { }

        /// <summary>
        /// [只读]登录信息保存到Session中的Key值
        /// </summary>
        public const string LoginInfoKey = "MultiColorPen-LOGIN-INFO";

        /// <summary>
        /// [只读]登陆验证码保存到Session中key值
        /// </summary>
        public const string CheckCodeKey = "MultiColorPen-LOGIN-VERIFYCODE";

        /// <summary>
        /// [只读]登录验证信息ID值
        /// </summary>
        public const string LoginStateCode = "MultiColorPen-LOGIN-STATECODE";
    }

    /// <summary>
    /// 登录用户信息
    /// </summary>
    [Serializable]
    public class LoginInfo
    {
        #region 参数
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string PName { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        ///// <summary>
        ///// 父名字
        ///// </summary>
        //public string ParentName { get; set; }
        #endregion

        public LoginInfo() { }

        /// <summary>
        /// 登录Session参数
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="pname">用户名称</param>
        /// <param name="rolecode">用户角色</param>
        ///// <param name="parentid">父ID</param>
        ///// <param name="parentname">父名字</param> 
        public LoginInfo(string username, string pname, string rolecode, string phone)//, string parentid, string parentname
        {
            UserName = username;
            PName = pname;
            RoleCode = rolecode;
            Phone = phone;
            //ParentId = parentid;
            //ParentName = parentname;
        }
    }

    public class SessionHelper
    {
        /// <summary>
        /// 写入信息到Session
        /// </summary>
        /// <param name="sessionkey">Session的Key值</param>
        /// <param name="obj">存入对象</param>
        public static void WriteSession(string sessionkey, object obj)
        {
            System.Web.HttpContext.Current.Session[sessionkey] = obj;
            System.Web.HttpContext.Current.Session.Timeout = 120;
        }
        /// <summary>
        /// 从Session中读取信息
        /// </summary>
        /// <param name="sessionkey">Session的Key值</param>
        /// <returns></returns>
        public static T ReadSession<T>(string sessionkey)
        {
            object obj = System.Web.HttpContext.Current.Session[sessionkey];
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        /// <summary>
        /// 从Session中读取登录信息
        /// </summary>
        /// <param name="sessionkey">Session的Key值</param>
        /// <returns></returns>
        public static LoginInfo ReadSession(string sessionkey)
        {
            object login = System.Web.HttpContext.Current.Session[sessionkey];
            if (login != null)
                return login as LoginInfo;
            else
                return null;
        }

        /// <summary>
        /// 移除Session中的登录信息
        /// </summary>
        /// <param name="sessionkey">Session的Key值</param>
        public static void RemoveSession(string sessionkey)
        {
            object login = System.Web.HttpContext.Current.Session[SessionKeys.LoginInfoKey];
            if (login != null)
                System.Web.HttpContext.Current.Session.Remove(SessionKeys.LoginInfoKey);
        }
    }
}
