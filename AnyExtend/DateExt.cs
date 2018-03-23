using System;

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

        /// <summary>
        /// 是否在2个时间之间
        /// </summary>
        public static bool Between(this DateTime dt, DateTime t1, DateTime t2)
        {
            return t1 <= dt && dt <= t2;
        }

        /// <summary>        
        /// 是否在2个时间之间
        /// </summary>
        public static bool Between(this DateTime dt, DateTime? t1, DateTime? t2)
        {
            return dt.Between(t1 ?? DateTime.MinValue, t2 ?? DateTime.MinValue);
        }

        /// <summary>
        /// 是否同一天
        /// </summary>
        public static bool EqualsDate(this DateTime dt, DateTime t1)
        {
            return dt.Date == t1.Date;
        }
    }
}
