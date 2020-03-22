using MultiColorPen.COMMON;
using MultiColorPen.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGame.Controllers
{
    public class CommodityController : Controller
    {
        //
        // GET: /Commodity/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CommodityManage()
        {
            return View();
        }

        public string GetCommodityList()
        {
            ResultInfo<List<object>> data = new ResultInfo<List<object>>();
            var dt = new MultiColorPen.BLL.commodity().GetList(" is_del='0' ").Tables[0];
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

        public string GetAllCommodity()
        {
            ResultInfo<List<object>> data = new ResultInfo<List<object>>();
            int pageSize = int.Parse(Request.Params["pagesize"]);
            int pageNo = int.Parse(Request.Params["pageno"]);
            string order = Request.Params["order"];
            string type = Request.Params["commodityType"];
            string commodity_name = Request.Params["commodity_name"];
            //查询条件组织
            string where = string.Empty;
            where += " is_del=0 and ";
            if (!string.IsNullOrEmpty(type))
                where += " type='" + type + "' and ";
            if (!string.IsNullOrEmpty(commodity_name))
                where += " name like '%" + commodity_name + "%' and ";

            if (!string.IsNullOrEmpty(where))
                where = where.Substring(0, where.Length - 4);
            int startIndex = pageSize * (pageNo - 1) + 1;
            int endIndex = pageSize * pageNo;
            var dt = new MultiColorPen.BLL.commodity().GetListByPage(where, order, startIndex, endIndex).Tables[0];
            data.IsSucceed = true;
            data.TotalCount = new MultiColorPen.BLL.commodity().GetRecordCount(where);
            data.Entity = JsonHelper.DataTableToList(dt);
            return JsonConvert.SerializeObject(data);
        }

        public string SaveCommodity(string json)
        {
            ResultInfo result = new ResultInfo(false);
            JObject jo = JObject.Parse(json);
            LoginInfo userInfo = SessionHelper.ReadSession<LoginInfo>(SessionKeys.LoginInfoKey);
            var bll = new MultiColorPen.BLL.commodity();
            //新增
            if (jo["id"].ToString() == "-1")
            {
                var model = new MultiColorPen.Model.commodity
                {
                    name = jo["name"].ToString(),
                    number = "NUM" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":",""),
                    count = (int)jo["count"],
                    price = (decimal)jo["price"],
                    type = jo["type"].ToString(),
                    unit = jo["unit"].ToString(),
                    is_del = "0",
                    special_supply = jo["special_supply"].ToString(),
                    mark = jo["mark"].ToString()
                };
                if (bll.Add(model))
                {
                    result.IsSucceed = true;
                    result.Message = "操作成功!";
                    PublicClass.AddLog("Operating", "新增商品" + model.name + "！");
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
                umodel.count = (int)jo["count"];
                umodel.price = (decimal)jo["price"];
                umodel.type = jo["type"].ToString();
                umodel.unit = jo["unit"].ToString();
                umodel.special_supply = jo["special_supply"].ToString();
                umodel.mark = jo["mark"].ToString();
                List<string> btncode = new List<string>();
                if (bll.Update(umodel))
                {
                    result.IsSucceed = true;
                    result.Message = "操作成功!";
                    PublicClass.AddLog("Operating", "编辑商品信息" + umodel.name + "！");
                }
                else
                {
                    result.IsSucceed = false;
                    result.Message = "修改失败！";
                }
            }
            return JsonConvert.SerializeObject(result);
        }
        public string DeleteCommodity(int id)
        {
            ResultInfo result = new ResultInfo(false);
            var bll = new MultiColorPen.BLL.commodity();
            var umodel = bll.GetModel(id);
            umodel.is_del = "1";
            if (bll.Update(umodel))
            {
                result.IsSucceed = true;
                result.Message = "操作成功!";
                PublicClass.AddLog("Operating", "删除商品信息" + umodel.name + "！");
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "删除失败！";
            }
            return JsonConvert.SerializeObject(result);
        }

        public string SingleCommodity(int id)
        {
            var dt = new MultiColorPen.BLL.commodity().GetModel(id);
            return JsonConvert.SerializeObject(dt);
        }
    }
}
