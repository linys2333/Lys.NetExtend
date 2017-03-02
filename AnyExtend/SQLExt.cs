using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnyExtend
{
    public static class SQLExt
    {
        #region 常用脚本

        /// <summary>
        /// 获取存储过程脚本
        /// </summary>
        public static readonly string GetProcTextSQL = @"
SELECT  m.definition
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON m.object_id = o.object_id
WHERE   o.type = 'P'
        AND o.name = @proc";

        /// <summary>
        /// 获取当前日期
        /// </summary>
        public static readonly string GetDateSQL = @"SELECT GETDATE()";

        #endregion

        /// <summary>
        /// 删除SQL注释
        /// </summary>
        public static string DelNotes(string SQL)
        {
            // 先删多行注释，再删单行注释
            SQL = Regex.Replace(SQL, @"/\*[\s\S]*?\*/", "");  // 匹配\r\n的非贪婪模式
            SQL = Regex.Replace(SQL, @"--.*", "");

            return SQL;
        }
    }
}
