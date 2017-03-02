using System.Text.RegularExpressions;

namespace AnyExtend
{
    /// <summary>
    /// 提供常用正则表达式及扩展方法
    /// </summary>
    public static class RegexExt
    {
        #region 常用正则

        #region 文件及路径相关

        #region 预设常量

        /// <summary>
        /// 有效盘符
        /// </summary>
        public static readonly string AvailDisk = new Regex(@"[a-zA-Z]").ToString();

        /// <summary>
        /// 有效分隔符
        /// </summary>
        public static readonly string AvailSplit = new Regex(@"(?<!\\| |\.)\\(?!\\| )").ToString();

        /// <summary>
        /// 无效命名字符集
        /// </summary>
        // ""转义为"，并非正则的转义
        public static readonly string NoAvailChar = new Regex(@"\\/:*?""<>|\f\n\r\t\v").ToString();

        /// <summary>
        /// 无效扩展名字符集
        /// </summary>
        public static readonly string NoAvailExt = NoAvailChar + @" \.";

        #endregion

        /// <summary>
        /// 文件扩展名（不含.），示例：
        /// <para>txt</para>
        /// <para>xls</para>
        /// </summary>
        public static readonly string ExtName = $@"^([^{NoAvailExt}])+$";

        /// <summary>
        /// 文件名（扩展名可有可无）
        /// <para>123txt</para>
        /// <para>123.txt</para>
        /// </summary>
        public static readonly string FileName = $@"^[^{NoAvailChar}]+$";

        /// <summary>
        /// 文件名（带扩展名）
        /// <para>123.txt</para>
        /// </summary>
        public static readonly string FileName2 = $@"^[^{NoAvailChar}]+\.[^{NoAvailExt}]+$";

        /// <summary>
        /// 文件夹名称（以 \ 开头），示例：
        /// <para>\folder</para>
        /// </summary>
        public static readonly string FolderName = $@"^({AvailSplit}[^{NoAvailChar}]+)({AvailSplit})?(?<! |\.)$";

        /// <summary>
        /// 文件夹名称（以 \ 开头，多段组合），示例：
        /// <para>\folder\folder\</para>
        /// </summary>
        public static readonly string FolderName2 = $@"^({AvailSplit}[^{NoAvailChar}]+)+({AvailSplit})?(?<! |\.)$";

        /// <summary>
        /// 文件路径（扩展名可有可无），示例：
        /// <para>C:\folder\1txt</para>
        /// </summary>
        // 解析：[盘符:] + 1或多段[\合法文件夹或文件名]
        public static readonly string FilePath = $@"^{AvailDisk}:({AvailSplit}[^{NoAvailChar}]+)+(?<! |\.)$";

        /// <summary>
        /// 文件路径（带扩展名），示例：
        /// <para>C:\1.txt</para>
        /// </summary>
        // 解析：[盘符:] + 1或多段[\合法文件夹或文件名] + [合法后缀]
        public static readonly string FilePath2 = $@"^{AvailDisk}:({AvailSplit}[^{NoAvailChar}]+)+(?<=\.[^ \.]+)$";

        /// <summary>
        /// 文件夹路径（磁盘根路径有效），示例：
        /// <para>C:\</para>
        /// <para>C:\folder\</para>
        /// </summary>
        // 解析：[盘符:] + 0或多段[\合法文件夹名]
        public static readonly string FolderPath = $@"^{AvailDisk}:({AvailSplit}[^{NoAvailChar}]*)*(?<! |\.)$";

        /// <summary>
        /// 文件夹路径（磁盘根路径无效），示例：
        /// <para>C:\folder</para>
        /// </summary>
        // 解析：[盘符:] + 1或多段[\合法文件夹名]
        public static readonly string FolderPath2 = $@"^{AvailDisk}:(?!\\$)({AvailSplit}[^{NoAvailChar}]*)+(?<! |\.)$";

        #endregion

        #endregion

        /// <summary>
        /// 普通字符串处理为正则表达式可识别字符串
        /// </summary>
        /// <param name="value">待转义字符串</param>
        /// <returns></returns>
        public static string ToRegex(this string value)
        {
            return Regex.Replace(value, @"\W", match => @"\" + match);
        }

        /// <summary>
        /// 忽略大小写的正则匹配
        /// </summary>
        /// <param name="input">待匹配字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns></returns>
        public static bool IsMatchNoCase(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }
    }
}
