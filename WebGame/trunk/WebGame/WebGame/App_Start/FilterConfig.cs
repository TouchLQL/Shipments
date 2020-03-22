using System.Web;
using System.Web.Mvc;
using MultiColorPen.COMMON;
using Newtonsoft.Json;

namespace MultiColorPen.SSIA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LoginCheckFilterAttribute() { IsCheck = true });
            filters.Add(new MyHandleErrorAttribute() { IsCheck = true });
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        public class MyHandleErrorAttribute : HandleErrorAttribute
        {
            public bool IsCheck { get; set; }
            public override void OnException(ExceptionContext filterContext)
            {
                if (IsCheck)
                {
                    string r_str = string.Empty;
                    if (filterContext.HttpContext.Session[SessionKeys.LoginInfoKey] == null)
                    {
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            ResultInfo<string> result = new ResultInfo<string>();
                            result.IsSucceed = false;
                            result.Message = "The certificate has expired. Please login again！";
                            result.Entity = "../../Home/Login";
                            r_str = JsonConvert.SerializeObject(result);
                        }
                        else
                        {
                            //跳转到登陆页
                            r_str = "<script>alert('The certificate has expired. Please login again！');window.parent.location.href='/Home/Login';</script>";
                        }
                    }
                    else
                    {
                        base.OnException(filterContext);
                        string mess = "Error message：" + filterContext.Exception.Message + "，Error controller：" + filterContext.Controller.ToString()
                            + ",Error method：" + filterContext.Exception.TargetSite.ToString()
                            + ",Error object：" + filterContext.Exception.Source + ",Error location：" + filterContext.Exception.StackTrace;
                        PublicClass.AddLog("error", mess);//写入报错日志
                        filterContext.ExceptionHandled = true;//设置异常已处理
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            ResultInfo<string> result = new ResultInfo<string>();
                            result.IsSucceed = false;
                            result.Message = "The system has an exception！";
                            result.Entity = "../../Content/html/Error.html";
                            r_str = JsonConvert.SerializeObject(result);
                        }
                        else
                        {
                            //跳转到登陆页
                            r_str = "<script>alert('系统出现异常！');window.parent.location.href='../../Content/html/Error.html';</script>";
                        }
                    }
                    filterContext.RequestContext.HttpContext.Response.Write(r_str);
                    filterContext.RequestContext.HttpContext.Response.End();
                }
            }
        }

        /// <summary>
        /// 验证用户是否登录
        /// </summary>
        public class LoginCheckFilterAttribute : ActionFilterAttribute
        {
            //表示是否检查登录
            public bool IsCheck { get; set; }

            /// <summary>
            /// Action方法执行之前执行此方法(控制器)
            /// </summary>
            /// <param name="filterContext"></param>
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (IsCheck)
                {
                    PublicClass.CheckLoginCode();
                    //校验用户是否已经登录
                    if (filterContext.HttpContext.Session[SessionKeys.LoginInfoKey] == null)
                    {
                        IsCheck = false;
                        string r_str = string.Empty;
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            ResultInfo<string> result = new ResultInfo<string>();
                            result.IsSucceed = false;
                            result.Message = "The certificate has expired. Please login again！";
                            result.Entity = "../../Home/Login";
                            r_str = JsonConvert.SerializeObject(result);
                        }
                        else
                        {
                            //跳转到登陆页
                            r_str = "<script>alert('The certificate has expired. Please login again！');window.parent.location.href='/Home/Login';</script>";
                        }
                        filterContext.RequestContext.HttpContext.Response.Write(r_str);
                        filterContext.RequestContext.HttpContext.Response.End();
                    }
                }
                base.OnActionExecuting(filterContext);
            }
        }
    }
}