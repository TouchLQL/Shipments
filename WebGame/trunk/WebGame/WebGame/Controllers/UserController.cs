using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiColorPen.COMMON;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiColorPen.SSIA.Controllers
{
    public class UserController : Controller
    {

        public ActionResult AdminManage()
        {
            return View();
        }

        /// <summary>
        /// 获取所有Admin
        /// </summary>
        /// <returns></returns>
        public string GetAllAdmins()
        {
            ResultInfo<List<object>> data = new ResultInfo<List<object>>();
            var dt = new MultiColorPen.BLL.base_userinfo().GetList("");
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
        /// 保存Admin
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public string AdminManageSave(string json)
        {
            ResultInfo result = new ResultInfo(false);
            JObject jo = JObject.Parse(json);
            LoginInfo userInfo = SessionHelper.ReadSession<LoginInfo>(SessionKeys.LoginInfoKey);
            var bll = new MultiColorPen.BLL.base_userinfo();

            bool avatar = false;
            string folderName = Server.MapPath("~/Upload/Avatar");
            if (Directory.Exists(folderName) == false) Directory.CreateDirectory(folderName);
            string fileName = Guid.NewGuid().ToString("N");
            string filePath = folderName + "/" + fileName + ".jpg";
            if (jo["avatar"].ToString() == "-1" && jo["base64"].ToString() != "-1" && StringToFile(jo["base64"].ToString(), filePath))
            { avatar = true; }
            try
            {
                //新增
                if (jo["id"].ToString() == "-1")
                {
                    var list = bll.GetModelList("username='" + jo["username"].ToString() + "' and A.isenable=1");
                    if (list.Count > 0)
                    {
                        result.IsSucceed = false;
                        result.Message = "Duplicate login name！";
                    }
                    else
                    {
                        var model = new MultiColorPen.Model.base_userinfo
                        {
                            usercode = bll.GetMaxNo(),
                            username = jo["username"].ToString(),
                            phone = jo["phone"].ToString(),
                            pname = jo["pname"].ToString(),
                            rolecode = jo["rolecode"].ToString(),
                            wechat = jo["wechat"].ToString(),
                            password = "21218CCA77804D2BA1922C33E0151105",
                            avatar = avatar ? fileName : jo["avatar"].ToString() == "-1" ? "" : jo["avatar"].ToString(),
                            isenable = 1,
                            createtime = DateTime.Now,
                            createman = userInfo.UserName
                        };
                        if (bll.Add(model) > 0)
                        {
                            result.IsSucceed = true;
                            result.Message = "Save success, the initial password is 888888！";
                            PublicClass.AddLog("Operating", "Add insiders " + model.username + "," + model.pname + "！");
                        }
                        else
                        {
                            result.IsSucceed = false;
                            result.Message = "Save failed！";
                        }
                    }
                }
                //修改
                else
                {
                    int id = int.Parse(jo["id"].ToString());
                    var list = bll.GetModelList("username='" + jo["username"].ToString() + "' and A.id!=" + id + " and A.isenable=1");
                    if (list.Count > 0)
                    {
                        result.IsSucceed = false;
                        result.Message = "Duplicate login name！";
                    }
                    else
                    {
                        var umodel = bll.GetModel(id);
                        string oldstr = JsonHelper.GetObjectToJSON(umodel);
                        umodel.phone = jo["phone"].ToString();
                        umodel.pname = jo["pname"].ToString();
                        umodel.wechat = jo["wechat"].ToString();
                        umodel.rolecode = jo["rolecode"].ToString();
                        umodel.avatar = avatar ? fileName : jo["avatar"].ToString() == "-1" ? "" : jo["avatar"].ToString();
                        umodel.updateman = userInfo.UserName;
                        umodel.updatetime = DateTime.Now;
                        string newstr = JsonHelper.GetObjectToJSON(umodel);

                        if (bll.Update(umodel) > 0)
                        {
                            result.IsSucceed = true;
                            result.Message = "Saved successfully！";
                            PublicClass.AddLog("Operating", "Modify internal staff " + umodel.username + "！", "", "", "base_userinfo", umodel.id.ToString(), oldstr, newstr);
                        }
                        else
                        {
                            result.IsSucceed = false;
                            result.Message = "Save failed！";
                        }
                    }
                }
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                result.IsSucceed = false;
                result.Message = ex.Message;
                return JsonConvert.SerializeObject(result);
            }
        }

        /// <summary> 
        /// 把经过base64编码的字符串保存为文件 
        /// </summary> 
        /// <param name="base64String">经base64加码后的字符串 </param> 
        /// <param name="fileName">保存文件的路径和文件名 </param> 
        /// <returns>保存文件是否成功 </returns> 
        public static bool StringToFile(string base64String, string fileName)
        {
            bool bl = false;
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            try
            {
                if (!string.IsNullOrEmpty(base64String) && System.IO.File.Exists(fileName))
                {
                    //base64String = base64String.Replace("data:image/png;base64,", "");
                    base64String = base64String.Split(',')[1];
                    bw.Write(Convert.FromBase64String(base64String));
                    bw.Dispose();
                    fs.Dispose();
                    bw.Close();
                    fs.Close();
                }
                bl = true;
            }
            catch (Exception ex)
            {
                PublicClass.AddLog("Save the picture", "StringToFile", fileName + "---" + ex.ToString());
            }
            finally
            {
                bw.Dispose();
                fs.Dispose();
                bw.Close();
                fs.Close();
                GC.Collect();
            }
            return bl;
        }

        /// <summary>
        /// Admin启用或禁用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ised"></param>
        /// <returns></returns>
        public string AdminEnableOrDisabled(int id, string ised)
        {
            ResultInfo<string> result = new ResultInfo<string>();
            var bll = new MultiColorPen.BLL.base_userinfo();
            var model = bll.GetModel(id);
            model.isenable = int.Parse(ised);
            if (bll.Update(model) > 0)
            {
                result.IsSucceed = true;
                result.Message = "operation Successful！";
                PublicClass.AddLog("Operating", (model.isenable == 1 ? "Enable insiders：" : "Disable insider：") + model.username + "," + model.pname + "!");
            }
            else
            {
                result.IsSucceed = false;
                result.Message = "operation Failed！";
            }
            return JsonConvert.SerializeObject(result);
        }


        public ActionResult UserManage()
        {
            return View();
        }

    }
}
