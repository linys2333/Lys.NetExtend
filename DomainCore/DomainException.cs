using System;

namespace DomainCore
{
    /// <summary>
    /// 供领域使用的特定异常，不会被日志记录
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DomainException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }
    }
}
