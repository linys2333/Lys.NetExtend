using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace AnyExtend
{
    /// <summary>
    /// 字符串常见操作扩展
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// 左截取
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="length">截取长度
        /// <para>若>0，则按“截取length个字符”处理</para>
        /// <para>若&lt;0，则按“截取到倒数第|length|个字符前”处理</para>
        /// <para>若=0或超长，则按“截取全部字符”处理</para>
        /// </param>
        /// <returns></returns>
        public static string Left(this string str, int length)
        {
            length = str.Length < Math.Abs(length) ? 0 : length;
            length = length <= 0 ? str.Length + length : length;
            return str.Substring(0, length);
        }

        /// <summary>
        /// 右截取
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="length">截取长度
        /// <para>若>0，则按“截取倒数length个字符”处理</para>
        /// <para>若&lt;0，则按“截取到正数第|length|个字符后”处理</para>
        /// <para>若=0或超长，则按“截取全部字符”处理</para>
        /// </param>
        /// <returns></returns>
        public static string Right(this string str, int length)
        {
            length = str.Length < Math.Abs(length) ? 0 : length;
            length = length <= 0 ? str.Length + length : length;
            return str.Substring(str.Length - length, length);
        }

        /// <summary>
        /// 是否包含某个字符串
        /// <para>str.Contains("a,b") 等价于 str.Contains("a") || str.Contains("b")</para>
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="value">待检测的字符串序列</param>
        /// <param name="split">分割符，用于分割待检测的字符串</param>
        /// <returns></returns>
        public static bool Contains(this string str, string value, string split)
        {
            string[] arr = value.Split(split);
            return arr.Any(str.Contains);
        }

        /// <summary>
        /// 是否等于某个字符串
        /// <para>str.In("a,b") 等价于 str == "a" || str == "b"</para>
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="value">待检测的字符串序列</param>
        /// <param name="split">分割符，用于分割待检测的字符串</param>
        /// <returns></returns>
        public static bool In(this string str, string value, string split = ",")
        {
            string[] arr = value.Split(split);
            return arr.Any(aimStr => str == aimStr);
        }
        
        /// <summary>
        /// 复制字符串（将str复制count份）
        /// </summary>
        /// <param name="str">要复制的字符串</param>
        /// <param name="count">复制次数（非正数则不复制）</param>
        /// <returns></returns>
        public static string Repeat(this string str, int count = 1)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += str;
            }
            return result;
        }

        /// <summary>
        /// 忽略大小写的字符串比较
        /// </summary>
        /// <param name="aimStr">目标字符串</param>
        /// <param name="comparaStr">对比字符串</param>
        /// <returns></returns>
        public static bool EqualsNoCase(this string aimStr, string comparaStr)
        {
            return aimStr.Equals(comparaStr, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 是否为空
        /// <para>isValidSpace=true，等价IsNullOrEmpty</para>
        /// <para>isValidSpace=false，等价IsNullOrWhiteSpace</para>
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="isValidSpace">空白字符是否有效</param>
        /// <returns></returns>
        public static bool IsEmpty(this string str, bool isValidSpace = false)
        {
            return isValidSpace ? string.IsNullOrEmpty(str) : string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 分割字符串（返回值包括含有空字符串的数组元素）
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="split">分割字符串</param>
        /// <returns></returns>
        public static string[] Split(this string str, string split)
        {
            return str.Split(new[] { split }, StringSplitOptions.None);
        }

        /// <summary>
        /// 分割字符串（返回值不包括含有空字符串的数组元素）
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="split">分割字符串</param>
        /// <returns></returns>
        public static string[] SplitNoEmpty(this string str, string split)
        {
            return str.Split(new[] { split }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 右侧补全字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="padStr">补全的字符串</param>
        /// <param name="count">补全次数（非正数则不补全）</param>
        /// <returns></returns>
        public static string PadRight(this string str, string padStr, int count = 1)
        {
            return str + padStr.Repeat(count);
        }

        /// <summary>
        /// 按mod位数补全右侧
        /// <para>例如，按4位补全，则补全后字符串长度是4的倍数</para>
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="padStr">补全的字符串</param>
        /// <param name="mod"></param>
        /// <param name="isAdd">字符串本身长度已是mod的倍数时，是否再补mod位</param>
        /// <returns></returns>
        public static string PadRight(this string str, string padStr, int mod, bool isAdd)
        {
            int num = str.Length % mod;
            return str.PadRight(padStr, !isAdd && num == 0 ? 0 : mod - num);
        }

        /// <summary>
        /// 左侧补全字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="padStr">补全的字符串</param>
        /// <param name="count">补全次数（非正数则不补全）</param>
        /// <returns></returns>
        public static string PadLeft(this string str, string padStr, int count = 1)
        {
            return padStr.Repeat(count) + str;
        }
    }
}
