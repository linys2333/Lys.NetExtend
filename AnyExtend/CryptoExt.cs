using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace AnyExtend
{   
    /// <summary>
    /// 加密扩展方法
    /// </summary>
    public static class CryptoExt
    {
        /// <summary>
        /// HMAC系列加密
        /// </summary>
        /// <param name="alg">继承HMAC的加密算法</param>
        /// <param name="content">待加密内容</param>
        /// <param name="salt">加密盐</param>
        /// <returns></returns>
        public static byte[] GetHmacHash(string alg, string content, string salt)
        {
            var hmac = (HMAC)Assembly.Load("mscorlib.dll")
                .CreateInstance($"System.Security.Cryptography.{alg}");

            hmac.Key = EncodingExt.GetBytes(salt);

            return hmac.ComputeHash(EncodingExt.GetBytes(content));
        }

        /// <summary>
        /// HMAC系列加密
        /// </summary>
        /// <param name="alg">继承HMAC的加密算法</param>
        /// <param name="content">待加密内容</param>
        /// <param name="salt">加密盐</param>
        /// <param name="type">密文编码类型</param>
        /// <returns></returns>
        public static string GetHmacHash(string alg, string content, string salt, EncodeType type)
        {
            byte[] data = GetHmacHash(alg, content, salt);
            return EncodingExt.GetString(data, type);
        }

        /// <summary>
        /// HMAC系列加密
        /// </summary>
        /// <typeparam name="T">继承HMAC的加密算法</typeparam>
        /// <param name="content">待加密内容</param>
        /// <param name="salt">加密盐</param>
        /// <returns></returns>
        public static byte[] GetHmacHash<T>(string content, string salt) where T : HMAC, new()
        {
            T hmac = new T
            {
                Key = EncodingExt.GetBytes(salt)
            };

            return hmac.ComputeHash(EncodingExt.GetBytes(content));
        }

        /// <summary>
        /// HMAC系列加密
        /// </summary>
        /// <typeparam name="T">继承HMAC的加密算法</typeparam>
        /// <param name="content">待加密内容</param>
        /// <param name="salt">加密盐</param>
        /// <param name="type">密文编码类型</param>
        /// <returns></returns>
        public static string GetHmacHash<T>(string content, string salt, EncodeType type) where T : HMAC, new()
        {
            byte[] data = GetHmacHash<T>(content, salt);
            return EncodingExt.GetString(data, type);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="content">待加密内容</param>
        /// <param name="salt">加密盐，为null则只加密内容</param>
        /// <returns></returns>
        public static byte[] GetMd5Hash(string content, string salt)
        {
            using (var md5Hash = MD5.Create())
            {
                content = salt == null ? content : $"{content}.{salt}";
                return md5Hash.ComputeHash(EncodingExt.GetBytes(content));
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="content">待加密内容</param>
        /// <param name="salt">加密盐，为null则只加密内容</param>
        /// <param name="type">密文编码类型</param>
        /// <returns></returns>
        public static string GetMd5Hash(string content, string salt, EncodeType type)
        {
            byte[] data = GetMd5Hash(content, salt);
            return EncodingExt.GetString(data, type);
        }
    }
}
