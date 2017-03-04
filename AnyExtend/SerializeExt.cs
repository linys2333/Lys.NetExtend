using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace AnyExtend
{
    /// <summary>
    /// 各类序列化方法
    /// </summary>
    public static class SerializeExt
    {
        #region xml序列化

        /// <summary>
        /// 序列化对象成xml文本
        /// </summary>
        /// <param name="obj">待序列化对象</param>
        /// <param name="encoding">编码方式（默认UTF8）</param>
        /// <returns></returns>
        public static string ToXml<T>(T obj, Encoding encoding = null)
        {
            EncodingExt.SetEncoding(ref encoding);

            var serializer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                var xmlSet = new XmlWriterSettings
                {
                    Encoding = encoding,
                    Indent = true,
                    IndentChars = "  ",
                    NewLineChars = "\r\n",
                    OmitXmlDeclaration = false
                };

                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                using (var xw = XmlWriter.Create(ms, xmlSet))
                {
                    serializer.Serialize(xw, obj, ns);
                }

                ms.Position = 0;
                using (var sw = new StreamReader(ms, encoding))
                {
                    return sw.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// 序列化对象成xml文本，并输出到指定路径文件
        /// </summary>
        /// <param name="obj">待序列化对象</param>
        /// <param name="path">输出文件路径</param>
        /// <param name="encoding">编码方式（默认UTF8）</param>
        /// <returns></returns>
        public static string ToXml<T>(T obj, string path, Encoding encoding = null)
        {
            var xml = new XmlDocument { InnerXml = ToXml(obj) };
            IOExt.WriteXml(path, xml);

            return xml.InnerXml;
        }

        /// <summary>
        /// 反序列化xml文本至对象
        /// </summary>
        /// <param name="xmlOrPath">待反序列化文本或文件的路径</param>
        /// <param name="isPath">是否从指定路径加载文件</param>
        /// <param name="encoding">编码方式（默认UTF8）</param>
        /// <returns></returns>
        public static T XmlTo<T>(string xmlOrPath, bool isPath = false, Encoding encoding = null)
        {
            EncodingExt.SetEncoding(ref encoding);

            // 如果是文件路径，则先加载文件
            string xml = isPath ? IOExt.ReadXml(xmlOrPath).InnerXml : xmlOrPath;

            var serializer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream(encoding.GetBytes(xml)))
            {
                using (var sw = new StreamReader(ms, encoding))
                {
                    return (T) serializer.Deserialize(sw);
                }
            }
        }

        #endregion

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

        #region Json序列化

        /// <summary>
        /// 序列化对象为json字符串
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <param name="isFormat">是否格式化（缩进）</param>
        /// <returns></returns>
        public static string ToJson(object obj, bool isFormat = true)
        {
            return obj == null
                ? "{}"
                : JsonConvert.SerializeObject(obj, isFormat
                    ? Newtonsoft.Json.Formatting.Indented
                    : Newtonsoft.Json.Formatting.None);
        }

        /// <summary>
        /// 从json字符串还原对象
        /// </summary>
        /// <param name="json">json格式字符串</param>
        /// <param name="type">对象类型</param>
        /// <returns></returns>
        public static object JsonTo(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        /// <summary>
        /// 从json字符串还原对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json格式字符串</param>
        /// <returns></returns>
        public static T JsonTo<T>(string json)
        {
            return json.IsEmpty() ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }

        #endregion
    }
}
