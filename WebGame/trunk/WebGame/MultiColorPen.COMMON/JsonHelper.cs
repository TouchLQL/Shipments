using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace MultiColorPen.COMMON
{
    public class JsonHelper
    {
        /// <summary>
        /// 对象转换成JSON字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string GetObjectToJSON(object obj)
        {
            string r_str = string.Empty;
            try
            {
                r_str = new JavaScriptSerializer().Serialize(obj);
            }
            catch
            {
            }
            return r_str;
        }

        /// <summary>
        /// 字符串转换成Obj对象
        /// </summary>
        /// <typeparam name="T">对象泛型</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static Object GetJSONToObject<T>(string json)
        {
            Object r_obj = null;
            try
            {
                Object obj = Activator.CreateInstance<T>();
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(obj.GetType());
                using (var ms = new MemoryStream())
                {
                    var buffer = Encoding.UTF8.GetBytes(json);
                    ms.Write(buffer, 0, buffer.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    r_obj = jsonSerializer.ReadObject(ms);
                }
            }
            catch { }
            return r_obj;
        }

        /// <summary>
        /// DataTable集合转换成List
        /// List中存放字典，key对应列名，value对应列值
        /// </summary>
        /// <param name="query">数据集</param>
        /// <returns></returns>
        public static List<object> DataTableToList(DataTable query)
        {
            List<object> list_dic = new List<object>();
            if (query != null && query.Rows.Count > 0)
            {
                foreach (DataRow item in query.Rows)
                {
                    Dictionary<string, object> dic_row = new Dictionary<string, object>();
                    foreach (DataColumn col in query.Columns)
                    {
                        string c_val = item[col.ColumnName].ToString().Replace("\\", "\\\\").Replace("\'", "\\\'").Replace("\t", " ").Replace("\r", " ").Replace("\n", "<br/>").Replace("\"", "'");
                        dic_row.Add(col.ColumnName, c_val);
                        //dic_row.Add(col.ColumnName, item[col.ColumnName]);
                    }

                    list_dic.Add(dic_row);
                }
            }
            return list_dic;
        }

        /// <summary>
        /// 将DataRow转换成Dictionary
        /// </summary>
        /// <param name="query">数据集</param>
        /// <param name="rows">数据行</param>
        /// <returns></returns>
        public static Dictionary<string, object> DataRowToDictionary(DataTable query, DataRow currentrows)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (DataColumn col in query.Columns)
            {
                dic.Add(col.ColumnName, currentrows[col.ColumnName].ToString());
            }
            return dic;
        }
    }
}
