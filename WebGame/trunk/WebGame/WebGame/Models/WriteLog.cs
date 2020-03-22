using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebGame.Models
{
    public class WriteLog
    {
        public static string FilePath = AppDomain.CurrentDomain.BaseDirectory;
        public static void Write(string content, string type)
        {
            string file = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string filePath = string.Format("{0}LogFiles", FilePath);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            try
            {
                if (!File.Exists(filePath + "/" + file))
                {
                    FileStream fs = new FileStream(filePath + "/" + file, FileMode.Append);
                    //获得字节数组
                    byte[] data = Encoding.UTF8.GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + " " + type + content + "\r\n");
                    //开始写入
                    fs.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流
                    fs.Flush();
                    fs.Close();
                }
                else
                {
                    StreamWriter sw = new StreamWriter(filePath + "/" + file, true);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + " " + type + content + "\r\n");
                    sw.Close();
                }
            }
            catch (IOException e)
            {
                StreamWriter sw = new StreamWriter(filePath + "/" + file, true);
                sw.WriteLine(DateTime.Now.ToString(e.ToString()));
                sw.Close();
            }
        }
    }
}