using System;
using System.Reflection;

namespace AnyExtend
{
    /// <summary>
    /// 反射扩展
    /// </summary>
    public static class ReflectExt
    {
        #region 获取类或方法



        #endregion

        #region 获取或设置字段

        /// <summary>
        /// 获取或设置静态对象字段
        /// </summary>
        /// <param name="obj">操作的静态对象类型</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">要设置的值</param>
        /// <returns></returns>
        public static object InvokeStaticField(Type obj, string fieldName, object value = null)
        {
            try
            {
                FieldInfo field = obj.GetField(fieldName,
                    BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField);

                if (value != null)
                {
                    field?.SetValue(null, value);
                }

                return field?.GetValue(null);
            }
            catch (Exception ex)
            {
                throw new Exception("字段调用失败：" + fieldName, ex);
            }
        }

        /// <summary>
        /// 获取或设置对象字段
        /// </summary>
        /// <param name="obj">操作的对象</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">要设置的值</param>
        /// <returns></returns>
        public static object InvokeField(this object obj, string fieldName, object value = null)
        {
            try
            {
                FieldInfo field = obj.GetType().GetField(fieldName,
                       BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField);

                if (value != null)
                {
                    field?.SetValue(obj, value);
                }

                return field?.GetValue(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("字段调用失败：" + fieldName, ex);
            }
        }

        #endregion
    }
}
