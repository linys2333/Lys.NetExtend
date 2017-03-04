using System;
using System.Security.Cryptography;
using System.Text;

namespace AnyExtend
{
    /// <summary>
    /// 提供编码扩展方法
    /// </summary>
    public static class EncodingExt
    {
        // 默认编码方式
        public static Encoding DefaultEncoding = Encoding.UTF8;

        public static void SetEncoding(ref Encoding encoding)
        {
            encoding = encoding ?? DefaultEncoding;
        }

        public static byte[] GetBytes(string str, Encoding encoding = null)
        {
            SetEncoding(ref encoding);
            return encoding.GetBytes(str);
        }

        public static string GetString(byte[] arr, Encoding encoding = null)
        {
            SetEncoding(ref encoding);
            return encoding.GetString(arr);
        }

        public static string ToBase64Url(byte[] inArray)
        {
            // Base64编码
            string str64 = Convert.ToBase64String(inArray);

            // 处理特殊字符，以便url传输
            str64 = str64.Replace("=", "")
                .Replace("+", "-")
                .Replace("/", "_");

            return str64;
        }

        public static string ToBase64Url(string str, Encoding encoding = null)
        {
            byte[] inArray = GetBytes(str, encoding);
            return ToBase64Url(inArray);
        }

        public static byte[] FromBase64Url(string str64)
        {
            // 处理url的特殊字符，还原为标准Base64字符串
            str64 = str64.Replace("-", "+")
                .Replace("_", "/")
                // =号最多2个
                .PadRight("=", 4, false);

            // Base64解码
            return Convert.FromBase64String(str64);
        }

        public static string FromBase64Url(string str64, Encoding encoding)
        {
            byte[] inArray = FromBase64Url(str64);
            return GetString(inArray, encoding);
        }

        public static byte[] ComputeHash<T>(string salt, string content) where T : HMAC, new()
        {
            T hmac = new T();
            hmac.Key = GetBytes(salt);
            return hmac.ComputeHash(GetBytes(content)); ;
        }
    }
}
