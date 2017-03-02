using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyExtend
{
    public static class DateExt
    {
        /// <summary>
        /// 获取日期yyyy-MM格式字符串
        /// </summary>
        /// <returns></returns>
        public static string GetYM(this DateTime date)
        {
            return date.ToString("yyyy-MM");
        }

        /// <summary>
        /// 获取日期yyyy-MM-dd格式字符串
        /// </summary>
        /// <returns></returns>
        public static string GetYMD(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
