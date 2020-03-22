using MultiColorPen.COMMON;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGame.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerManage()
        {
            return View();
        }

        public string GetAllCustomer()
        {
            ResultInfo<List<object>> data = new ResultInfo<List<object>>();
            var dt = new MultiColorPen.BLL.customer().GetList("  is_del='0'  ").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                data.IsSucceed = true;
                data.Message = "Get Data！";
                data.TotalCount = dt.Rows.Count;
            }
            else
            {
                data.IsSucceed = false;
                data.Message = "没有可展示的数据！";
                data.TotalCount = 0;
            }
            data.Entity = JsonHelper.DataTableToList(dt);
            return JsonConvert.SerializeObject(data);
        }

        public string SaveCustomer(string json)
        {
            ResultInfo result = new ResultInfo(false);
            JObject jo = JObject.Parse(json);
            LoginInfo userInfo = SessionHelper.ReadSession<LoginInfo>(SessionKeys.LoginInfoKey);
            var bll = new MultiColorPen.BLL.customer();
            //新增
            if (jo["id"].ToString() == "-1")
            {
                var model = new MultiColorPen.Model.customer
                {
                    name = jo["name"].ToString(),
                    address = jo["address"].ToString(),
                    tel = jo["tel"].ToString(),
                    person = jo["person"].ToString(),
                    is_del = "0",
                    mark = jo["mark"].ToString()
                };
                if (bll.Add(model))
                {
                    result.IsSucceed = true;
                    result.Message = "操作成功!";
                    PublicClass.AddLog("Operating", "新增商家" + model.name + "！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "新增失败！";
                }
            }
            //修改
            else
            {
                int id = int.Parse(jo["id"].ToString());
                var umodel = bll.GetModel(id);
                umodel.name = jo["name"].ToString();
                umodel.address = jo["address"].ToString();
                umodel.tel = jo["tel"].ToString();
                umodel.person = jo["person"].ToString();
                umodel.mark = jo["mark"].ToString();
                List<string> btncode = new List<string>();
                if (bll.Update(umodel))
                {
                    result.IsSucceed = true;
                    result.Message = "操作成功!";
                    PublicClass.AddLog("Operating", "编辑商家信息" + umodel.name + "！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "修改失败！";
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        public string DeleteCustomer(int id)
        {
            ResultInfo result = new ResultInfo(false);
            var bll = new MultiColorPen.BLL.customer();
            var umodel = bll.GetModel(id);
            umodel.is_del = "1";
            if (bll.Update(umodel))
            {
                result.IsSucceed = true;
                result.Message = "操作成功!";
                PublicClass.AddLog("Operating", "删除商家信息" + umodel.name + "！");
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "删除失败！";
            }
            return JsonConvert.SerializeObject(result);
        }
    }
}
