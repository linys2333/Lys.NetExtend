using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyExtend
{
    public static class DataRowExt
    {
        public static string GetString(this DataRow dr, string fieldName)
        {
            return TypeExt.ConvertType<string>(dr[fieldName]);
        }

        public static int GetInt(this DataRow dr, string fieldName)
        {
            return TypeExt.ConvertType<int>(dr[fieldName]);
        }

        public static decimal GetDecimal(this DataRow dr, string fieldName)
        {
            return TypeExt.ConvertType<decimal>(dr[fieldName]);
        }

        public static Guid GetGuid(this DataRow dr, string fieldName)
        {
            return TypeExt.ConvertType<Guid>(dr[fieldName]);
        }

        public static DateTime GetDateTime(this DataRow dr, string fieldName)
        {
            return TypeExt.ConvertType<DateTime>(dr[fieldName]);
        }
    }
}
