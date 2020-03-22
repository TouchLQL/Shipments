using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using MultiColorPen.DBUtility;
using MultiColorPen.Model;

namespace MultiColorPen.COMMON
{
    public class PublicClass
    {
        /// <summary>
        /// 填写日志
        /// </summary>
        /// <param name="logtype">日志类型</param>
        /// <param name="mess">日志信息</param>
        /// <param name="usercode"></param>
        /// <param name="username"></param>
        /// <param name="datatable"></param>
        /// <param name="dataid"></param>
        /// <param name="dataold"></param>
        /// <param name="datanew"></param>
        public static void AddLog(string logtype, string mess, string usercode = "", string username = "", string datatable = "", string dataid = "", string dataold = "", string datanew = "")
        {
            if (string.IsNullOrEmpty(usercode))
            {
                LoginInfo li = SessionHelper.ReadSession<LoginInfo>(SessionKeys.LoginInfoKey);
                usercode = li.UserName;
                username = li.PName;
            }
            sys_loginfo model = new sys_loginfo
            {
                logtype = logtype,
                createtime = DateTime.Now,
                usercode = usercode,
                username = username,
                ipaddress = GetUserIp(),
                logcontent = mess,
                dataold = dataold,
                datanew = datanew,
                dataid = dataid,
                datatable = datatable
            };
            MultiColorPen.BLL.sys_loginfo dal = new BLL.sys_loginfo();
            dal.Add(model);
        }

        /// <summary>
        /// 检查用户唯一码
        /// </summary>
        public static void CheckLoginCode()
        {
            LoginInfo li = SessionHelper.ReadSession<LoginInfo>(SessionKeys.LoginInfoKey);
            BLL.base_userinfo bll = new BLL.base_userinfo();
            if (bll.CheckLoginToken(li.UserName, SessionHelper.ReadSession<string>(SessionKeys.LoginStateCode)) == 0)
            {
                SessionHelper.RemoveSession(SessionKeys.LoginInfoKey);
                SessionHelper.RemoveSession(SessionKeys.LoginStateCode);
                SessionHelper.RemoveSession(SessionKeys.CheckCodeKey);
            }
        }

        /// <summary>
        /// 获取用户登录ip
        /// </summary>
        /// <returns></returns>
        public static string GetUserIp()
        {
            string realRemoteIp = "";
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                realRemoteIp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0];
            }
            if (string.IsNullOrEmpty(realRemoteIp))
            {
                realRemoteIp = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(realRemoteIp))
            {
                realRemoteIp = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return realRemoteIp;
        }

        /// <summary>
        /// 产生随机字符串
        /// </summary>
        /// <param name="num">随机出几个字符</param>
        /// <returns>随机出的字符串</returns>
        public static string GenCode(int num)
        {
            string str = "0123456789ABCDEFGHiJKLMNOPQRSTUVWXYZ";//图片上随机文字
            char[] chastr = str.ToCharArray();
            string code = "";
            Random rd = new Random();
            int i;
            for (i = 0; i < num; i++)
            {
                code += str.Substring(rd.Next(0, str.Length), 1);
            }
            return code;
        }
    }
}
