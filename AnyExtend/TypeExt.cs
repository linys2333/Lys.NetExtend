using System;

namespace AnyExtend
{
    /// <summary>
    /// 提供类型扩展方法
    /// </summary>
    public static class TypeExt
    {
        #region 类型转换

        /// <summary>
        /// 安全类型转换，转换失败返回null，不抛出异常
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="obj">待转换的对象</param>
        /// <returns>null值将转换成类型默认值</returns>
        public static T ConvertType<T>(object obj)
        {
            var result = ConvertType(typeof(T), obj);
            return result == null ? default(T) : (T) result;
        }

        /// <summary>
        /// 安全类型转换，转换失败返回null，不抛出异常
        /// </summary>
        /// <param name="type">转换类型</param>
        /// <param name="obj">待转换的对象</param>
        /// <returns>null值不做处理，返回null</returns>
        public static object ConvertType(Type type, object obj)
        {
            try
            {
                if (obj == null || obj == DBNull.Value)
                {
                    // 部分类型的null值做特殊处理
                    if (type == typeof(string))
                    {
                        return "";
                    }

                    if (type == typeof(int))
                    {
                        return 0;
                    }

                    return null;
                }
            
                if (type.IsGenericType && type.Name.Contains("Nullable`"))
                {
                    Type realType = type.GetGenericArguments()[0];
                    return ConvertType(realType, obj);
                }

                if (obj is string)
                {
                    if (type == typeof (Guid))
                    {
                        return new Guid((string)obj);
                    }

                    if (type == typeof (DateTime))
                    {
                        return DateTime.Parse((string)obj);
                    }
                }

                return Convert.ChangeType(obj, type) ?? ConvertType(type, obj.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        #endregion
    }
}
