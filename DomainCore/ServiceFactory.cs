using System;
using Castle.DynamicProxy;
using AnyExtend;

namespace DomainCore
{
    public static class ServiceFactory
    {
        private static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

        public static T GetService<T>() where T : class
        {
            try
            {
                var obj = ProxyGenerator.CreateClassProxy<T>(new ExceptionLogInterceptor());
                return obj;
            }
            catch (Exception ex)
            {
                Log.Record($"创建对象[{typeof(T).FullName}]失败", ex);
                throw;
            }
        }
    }

    /// <summary>
    /// 记录异常日志
    /// </summary>
    public class ExceptionLogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (DomainException)
            {
                // 不处理领域异常
                throw;
            }
            catch (Exception ex)
            {
                // 记录其它异常
                Log.Record($"方法发生异常：{invocation.Method.DeclaringType?.FullName}.{invocation.Method.Name}", ex);
                throw;
            }
        }
    }
}
