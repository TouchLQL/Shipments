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
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderManage()
        {
            return View();
        }

        //public string GetAllOrder()
        //{
        //    ResultInfo<List<object>> data = new ResultInfo<List<object>>();
        //    var dt = new MultiColorPen.BLL.order_info().GetList(" is_del='0' ").Tables[0];
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        data.IsSucceed = true;
        //        data.Message = "Get Data！";
        //        data.TotalCount = dt.Rows.Count;
        //    }
        //    else
        //    {
        //        data.IsSucceed = false;
        //        data.Message = "没有可展示的数据！";
        //        data.TotalCount = 0;
        //    }
        //    data.Entity = JsonHelper.DataTableToList(dt);
        //    return JsonConvert.SerializeObject(data);
        //}


        public string GetAllOrder()
        {
            ResultInfo<List<object>> data = new ResultInfo<List<object>>();
            int pageSize = int.Parse(Request.Params["pagesize"]);
            int pageNo = int.Parse(Request.Params["pageno"]);
            string order = Request.Params["order"];
            string customerId = Request.Params["customerId"];
            string datest = Request.Params["datest"];
            string dateed = Request.Params["dateed"];
            //查询条件组织
            string where = string.Empty;
            where += " is_del=0 and ";
            if (!string.IsNullOrEmpty(customerId))
                where += " customer_id=" + customerId + " and ";
            if (!string.IsNullOrEmpty(datest))
                where += " delivery_time>='" + DateTime.Parse(datest).ToString("yyyy-MM-dd") + "' and ";
            if (!string.IsNullOrEmpty(dateed))
                where += " delivery_time<='" + DateTime.Parse(dateed).ToString("yyyy-MM-dd") + "' and ";

            if (!string.IsNullOrEmpty(where))
                where = where.Substring(0, where.Length - 4);
            int startIndex = pageSize * (pageNo - 1) + 1;
            int endIndex = pageSize * pageNo;
            var dt = new MultiColorPen.BLL.order_info().GetListByPage(where, order, startIndex, endIndex).Tables[0];
            data.IsSucceed = true;
            data.TotalCount = new MultiColorPen.BLL.order_info().GetRecordCount(where);
            data.Entity = JsonHelper.DataTableToList(dt);
            return JsonConvert.SerializeObject(data);
        }

        public string SaveOrder(string json,string orderInfo)
        {
            //json = json.Replace("[","").Replace("]","");
            orderInfo = orderInfo.Replace("[", "").Replace("]", "");
            var bllOrder = new MultiColorPen.BLL.order_info();
            var bllDetail = new MultiColorPen.BLL.order_detail();
            var bllCommo = new MultiColorPen.BLL.commodity();
            var bllCustomer = new MultiColorPen.BLL.customer();
            bool isSuccess =true;
            string orderNumber = "";//订单编号
            JArray jArray = JArray.Parse(json);
            var oldOrderInfo = new MultiColorPen.Model.order_info();
            ResultInfo result = new ResultInfo(false);
            JObject jo = JObject.Parse(orderInfo);//解析order信息
            if (jo["orderId"].ToString() == "-1") //新增订单
            {
                orderNumber = "ORDER" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            else
            {
                oldOrderInfo = bllOrder.GetModel((int)jo["orderId"]); //获取旧的订单信息
                orderNumber = oldOrderInfo.number; //编辑时使用旧的订单编号
                oldOrderInfo.is_del = "1";
                if (!bllOrder.Update(oldOrderInfo)) //删除旧的订单信息
                {
                    isSuccess = false;
                }
                if (!bllDetail.DeleteByWhere(" order_number='" + orderNumber + "'")) //删除详细商品的对应数据
                {
                    isSuccess = false;
                }
            }

            foreach (var jj in jArray)
            {
                JObject jdata = (JObject)jj;
                var commodityModel = bllCommo.GetModel((int)jdata["name"]);
                var orderDetailModel = new MultiColorPen.Model.order_detail();
                orderDetailModel.commodity_count = (int)jdata["count"];
                orderDetailModel.commodity_id = (int)jdata["name"];
                orderDetailModel.commodity_price = commodityModel.price;
                orderDetailModel.commodity_unit = commodityModel.unit;
                orderDetailModel.order_number = orderNumber;
                orderDetailModel.commodity_name = commodityModel.name;
                orderDetailModel.mark = jdata["mark"].ToString();
                orderDetailModel.is_del = "0";
                if (!bllDetail.Add(orderDetailModel)) //插入商品详情
                {
                    isSuccess = false;
                }
            }
            var customerModel = bllCustomer.GetModel((int)jo["customerId"]);
            var orderModel = new MultiColorPen.Model.order_info();
            orderModel.create_time = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            orderModel.customer_id = (int)jo["customerId"] ;
            orderModel.customer_address = customerModel.address;
            orderModel.customer_name = customerModel.name;
            orderModel.customer_person = customerModel.person;
            orderModel.customer_tel = customerModel.tel;
            orderModel.delivery_time = jo["deliverTime"].ToString();
            orderModel.is_del = "0";
            orderModel.status = "已下单";
            orderModel.number = orderNumber;
            orderModel.mark = jo["orderMark"].ToString();
            if(!bllOrder.Add(orderModel)) //插入订单信息
            {
                isSuccess = false;
            }
            if (isSuccess)
            {
                result.IsSucceed = true;
                result.Message = "操作成功!";
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "修改失败！";
            }          
            return JsonConvert.SerializeObject(result);
        }
        //public string DeleteCommodity(int id)
        //{
        //    ResultInfo result = new ResultInfo(false);
        //    var bll = new MultiColorPen.BLL.commodity();
        //    var umodel = bll.GetModel(id);
        //    umodel.is_del = "1";
        //    if (bll.Update(umodel))
        //    {
        //        result.IsSucceed = true;
        //        result.Message = "操作成功!";
        //        PublicClass.AddLog("Operating", "删除商品信息" + umodel.name + "！");
        //    }
        //    else
        //    {
        //        result.IsSucceed = false;
        //        result.Message = "删除失败！";
        //    }
        //    return JsonConvert.SerializeObject(result);
        //}

        public string DeleteOrder(int id)
        {
            ResultInfo result = new ResultInfo(false);
            var bll = new MultiColorPen.BLL.order_info();
            var umodel = bll.GetModel(id);
            umodel.is_del = "1";
            if (bll.Update(umodel))
            {
                result.IsSucceed = true;
                result.Message = "操作成功!";
                PublicClass.AddLog("Operating", "删除订单" + umodel.id + "！");
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "删除失败！";
            }
            return JsonConvert.SerializeObject(result);
        }

        public string GetOrderDetailByWhere(string where)
        {
            var bll = new MultiColorPen.BLL.order_detail();
            var umodel = bll.GetList(where);
            return JsonConvert.SerializeObject(umodel);
        }

        public string GetOrderBaoBiaoByWhere()
        {
            ResultInfo<List<object>> data = new ResultInfo<List<object>>();
            string customerId = Request.Params["customerId"];
            string datest = Request.Params["datest"];
            string dateed = Request.Params["dateed"];
            //查询条件组织
            string where = string.Empty;
            where += " is_del=0 and ";
            if (!string.IsNullOrEmpty(customerId))
                where += " customer_id=" + customerId + " and ";
            if (!string.IsNullOrEmpty(datest))
                where += " delivery_time>='" + DateTime.Parse(datest).ToString("yyyy-MM-dd") + "' and ";
            if (!string.IsNullOrEmpty(dateed))
                where += " delivery_time<='" + DateTime.Parse(dateed).ToString("yyyy-MM-dd") + "' and ";
            if (!string.IsNullOrEmpty(where))
                where = where.Substring(0, where.Length - 4);
            var dt = new MultiColorPen.BLL.order_info().GetBaoBiaoList(where).Tables[0];
            data.IsSucceed = true;
            data.Entity = JsonHelper.DataTableToList(dt);
            return JsonConvert.SerializeObject(data);
        }
    }
}
