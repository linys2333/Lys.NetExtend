using System.Data;
using System.Data.SqlClient;

namespace AnyExtend
{
    /// <summary>
    /// 数据库信息
    /// </summary>
    public class DBInfo
    {
        public string Server { get; }
        public string UserName { get; }
        public string Password { get; }
        public string Database { get; }
        public string ConnString { get; }
        public SqlConnection Conn => new SqlConnection(ConnString);

        public DBInfo(string server, string database, string userName, string password)
        {
            Server = server.Trim();
            Database = database.Trim();
            UserName = userName.Trim();
            Password = password.Trim();
            
            ConnString = $"Server={Server};Database={Database};User ID={UserName};Password={Password};";
        }

        public static bool operator ==(DBInfo a, DBInfo b)
        {
            if ((object)a == null || (object)b == null)
            {
                return Equals(a, b);
            }

            return a?.Server == b?.Server &&
                a?.UserName == b?.UserName &&
                a?.Password == b?.Password &&
                a?.Database == b?.Database;
        }

        public static bool operator !=(DBInfo a, DBInfo b) => !(a == b);
    }


    /// <summary>
    /// 提供数据库扩展方法
    /// </summary>
    public static class DBExt
    {
        /// <summary>
        /// 测试数据库连接（主要捕获异常）
        /// </summary>
        public static bool TestSqlServerDB(DBInfo dbInfo)
        {
            using (var conn = dbInfo.Conn)
            {
                conn.Open();

                return conn.State == ConnectionState.Open;
            }
        }
    }
}
