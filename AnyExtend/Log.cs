using System;
using System.Collections;
using System.Reflection;
using AnyExtend;

namespace AnyExtend
{
    /// <summary>
    /// 日志处理
    /// <para>使用前，请先调用InitLogPath方法初始化日志路径</para>
    /// <para>若日志路径为空，则视为禁用日志</para>
    /// </summary>
    public static class Log
    {
        private static string _logFolder;

        public static void InitPath(string path)
        {
            if (!IOExt.CheckFolderPath(path))
            {
                throw new IOFolderPathException(path);
            }

            if (path[path.Length - 1] != '\\')
            {
                path += @"\";
            }

            _logFolder = path;
        }

        public static void Record(string message, Exception ex)
        {
            if (ex != null)
            {
                ArrayList infoArr = new ArrayList();

                PropertyInfo[] propList = ex.GetType().GetProperties();
                foreach (var prop in propList)
                {
                    infoArr.Add($"{prop.Name}:{prop.GetValue(ex, null)}");
                }

                message += "\r\n" + string.Join("\r\n", infoArr.ToArray());
            }

            Write(message);
        }

        public static void Record(string message)
        {
            Record(message, null);
        }

        public static void Record(Exception ex)
        {
            Record("", ex);
        }

        private static void Write(string logInfo)
        {
            if (_logFolder.IsEmpty())
            {
                return;
            }

            logInfo = $"\r\n【记录时间：{DateTime.Now}】\r\n{logInfo}";
            string logPath = $"{_logFolder}{DateTime.Now.ToString("yyyy-MM-dd")}.txt";

            IOExt.Write(logPath, logInfo, true);
        }
    }

    /// <summary>
    /// 提供日志扩展方法
    /// </summary>
    public static class LogExt
    {
        /// <summary>
        /// 处理异常并记录日志
        /// </summary>
        /// <param name="action">正常执行代码</param>
        /// <param name="exAction">异常执行代码</param>
        /// <param name="isThrow">是否抛出异常</param>
        public static void Exec(Action action, Action exAction = null, bool isThrow = false)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Log.Record(ex);

                exAction?.Invoke();

                if (isThrow)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 处理异常并记录日志
        /// </summary>
        /// <param name="action">正常执行代码</param>
        /// <param name="exAction">异常执行代码</param>
        /// <param name="isThrow">是否抛出异常</param>
        /// <returns></returns>
        public static T Exec<T>(Func<T> action, Func<T> exAction = null, bool isThrow = false)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                Log.Record(ex);
                T result = exAction != null ? exAction() : default(T);

                if (isThrow)
                {
                    throw;
                }
                return result;
            }
        }
    }
}
