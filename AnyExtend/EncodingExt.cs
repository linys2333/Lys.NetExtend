using System.Text;

namespace AnyExtend
{
    /// <summary>
    /// 提供编码扩展方法
    /// </summary>
    public static class EncodingExt
    {
        // 默认编码方式
        public static readonly Encoding DefaultEncoding = Encoding.UTF8;

        public static void SetEncoding(ref Encoding encoding)
        {
            encoding = encoding ?? DefaultEncoding;
        }
    }
}
