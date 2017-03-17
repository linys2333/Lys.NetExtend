using System;
using System.Text;

namespace AnyExtend
{
    public enum EncodeType
    {
        Encode,
        Hex,
        Base64
    }

    /// <summary>
    /// 提供编码扩展方法
    /// </summary>
    public static class EncodingExt
    {
        /// <summary>
        /// 默认编码类型
        /// </summary>
        public static Encoding DefaultEncoding = Encoding.UTF8;

        /// <summary>
        /// 编码类型为null时设置为默认编码
        /// </summary>
        /// <param name="encoding">待处理编码类型</param>
        public static void SetEncoding(ref Encoding encoding)
        {
            encoding = encoding ?? DefaultEncoding;
        }

        /// <summary>
        /// 将指定字符串编码成字节形式
        /// </summary>
        /// <param name="str">待编码字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static byte[] GetBytes(this string str, Encoding encoding = null)
        {
            SetEncoding(ref encoding);
            return encoding.GetBytes(str);
        }

        /// <summary>
        /// 将指定字节解码成字符串
        /// </summary>
        /// <param name="arr">待解码字节数组</param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static string GetString(this byte[] arr, Encoding encoding = null)
        {
            SetEncoding(ref encoding);
            return encoding.GetString(arr);
        }

        /// <summary>
        /// 将字节按指定类型解码成字符串
        /// </summary>
        /// <param name="arr">待解码字节数组</param>
        /// <param name="type">编码类型</param>
        /// <returns></returns>
        public static string GetString(this byte[] arr, EncodeType type)
        {
            string result = "";

            switch (type)
            {
                case EncodeType.Encode:
                    result = GetString(arr);
                    break;
                case EncodeType.Hex:
                    var sBuilder = new StringBuilder();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        // 16进制
                        sBuilder.Append(arr[i].ToString("x2"));
                    }
                    result = sBuilder.ToString();
                    break;
                case EncodeType.Base64:
                    result = Convert.ToBase64String(arr);
                    break;
            }

            return result;
        }

        /// <summary>
        /// 将指定字节编码成适于Url传输的Base64字符串
        /// </summary>
        /// <param name="inArray">待编码字节数组</param>
        /// <returns></returns>
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

        /// <summary>
        /// 将指定字符串编码成适于Url传输的Base64字符串
        /// </summary>
        /// <param name="str">待编码字符串</param>
        /// <param name="encoding">编码类型，用于编码字符串为字节数组</param>
        /// <returns></returns>
        public static string ToBase64Url(string str, Encoding encoding = null)
        {
            byte[] inArray = GetBytes(str, encoding);
            return ToBase64Url(inArray);
        }

        /// <summary>
        /// 将适于Url传输的Base64字符串解码
        /// </summary>
        /// <param name="str64">待解码字符串</param>
        /// <returns></returns>
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

        /// <summary>
        /// 将适于Url传输的Base64字符串解码
        /// </summary>
        /// <param name="str64">待解码字符串</param>
        /// <param name="encoding">编码类型，null则按默认编码UTF-8处理</param>
        /// <returns></returns>
        public static string FromBase64Url(string str64, Encoding encoding)
        {
            byte[] inArray = FromBase64Url(str64);
            return GetString(inArray, encoding);
        }
    }
}
