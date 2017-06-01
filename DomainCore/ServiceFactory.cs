using System;
using System.Diagnostics;
using Castle.DynamicProxy;
using AnyExtend;

namespace DomainCore
{
    public static class ServiceFactory
    {
        public static object GetService(Type t)
        {
            try
            {
                var obj = _proxy.CreateClassProxy(t, getInterceptor());
                return obj;
            }
            catch (Exception ex)
            {
                Log.Record($"创建对象[{t.FullName}]失败", ex);
                throw;
            }
        }

        public static T GetService<T>() where T : class, new()
        {
            return (T)GetService(typeof(T));
        }

        #region 私有

        private static readonly ProxyGenerator _proxy = new ProxyGenerator();

        private static IInterceptor[] getInterceptor()
        {
            // Debug模式下做性能统计
#if DEBUG
            return new[] { (IInterceptor)new ExceptionInterceptor(), new ProfilerInterceptor() };
#else
            return new[] { (IInterceptor)new ExceptionInterceptor() };
#endif
        }

        #endregion
    }

    /// <summary>
    /// 异常处理
    /// </summary>
    public class ExceptionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Action<Exception> log = ex =>
            {
                Log.Record($"方法发生异常：{invocation.Method.DeclaringType?.FullName}.{invocation.Method.Name}", ex);
            };

            try
            {
                invocation.Proceed();
            }
            catch (DomainException ex)
            {
                log(ex);
                throw;
            }
            catch (Exception ex)
            {
                Exception innerEx = ex.InnerException;

                if (innerEx != null && innerEx.GetType().BaseType == typeof(DomainException))
                {
                    log(innerEx);
                }

                log(ex);
                throw;
            }
        }
    }

    /// <summary>
    /// 性能统计
    /// </summary>
    public class ProfilerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var watch = new Stopwatch();
            watch.Start();

            invocation.Proceed();

            watch.Stop();
            
            if (watch.ElapsedMilliseconds >= 500)
            {
                Log.Record(
                    $"性能警告：[{invocation.TargetType.FullName}.{invocation.Method.Name}]执行耗时(ms)：{watch.ElapsedMilliseconds}");
            }
        }
    }
}
