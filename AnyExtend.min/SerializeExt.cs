using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AnyExtend
{
    /// <summary>
    /// 各类序列化方法
    /// </summary>
    public static class SerializeExt
    {
        #region 对象序列化
        
        /// <summary>
        /// 对象深度复制（对象需标记为可序列化）
        /// </summary>
        public static T DeepClone<T>(this object obj) where T : class
        {
            using (var ms = new MemoryStream())
            {
                var s = new BinaryFormatter();
                s.Serialize(ms, obj);
                ms.Position = 0;
                return s.Deserialize(ms) as T;
            }
        }

        #endregion
    }
}
