namespace MultiColorPen.COMMON
{
    public class EncryptionData
    {
        ///   <summary>
        ///   给一个字符串进行MD5加密
        ///   </summary>
        ///   <param   name="strText">待加密字符串</param>
        ///   <returns>加密后的字符串</returns>
        public static string MD5Encrypt(string strText)
        {
           return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "MD5").ToString();
        }
    }
}
