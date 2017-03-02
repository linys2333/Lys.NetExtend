using System;

namespace AnyExtend
{
    /// <summary>
    /// 数学函数扩展
    /// </summary>
    public static class MathExt
    {
        /// <summary>
        /// 我们熟悉的四舍五入（适用decimal类型）
        /// </summary>
        /// <param name="d">要舍入的小数</param>
        /// <param name="decimals">保留的小数位（负数则不处理）</param>
        /// <returns></returns>
        public static decimal Round(decimal d, int decimals)
        {
            return decimals < 0 ? d : Math.Round(d, decimals, MidpointRounding.AwayFromZero);
        }
        
        /// <summary>
        /// 幂运算xⁿ
        /// </summary>
        /// <param name="x">底数</param>
        /// <param name="n">指数</param>
        /// <param name="decimals">保留的小数位（负数则不处理）</param>
        /// <returns></returns>
        public static decimal Pow(decimal x, decimal n, int decimals = -1)
        {
            decimal result = (decimal)Math.Pow((double)x, (double)n);
            return Round(result, decimals);
        }

        /// <summary>
        /// 安全除
        /// </summary>
        /// <param name="first">被除数</param>
        /// <param name="second">除数</param>
        /// <param name="decimals">保留的小数位（负数则不处理）</param>
        /// <returns></returns>
        public static decimal Division(decimal first, decimal second, int decimals = -1)
        {
            decimal result = second == 0 ? 0 : (first / second);
            return Round(result, decimals);
        }

        /// <summary>
        /// 安全除
        /// </summary>
        /// <param name="first">被除数</param>
        /// <param name="second">除数</param>
        /// <returns></returns>
        public static int Division(int first, int second)
        {
            int result = second == 0 ? 0 : (first / second);
            return result;
        }

        /// <summary>
        /// 安全除（计算结果为正负无穷大时，返回0）
        /// </summary>
        /// <param name="first">被除数</param>
        /// <param name="second">除数</param>
        /// <param name="decimals">保留的小数位（负数则不处理）</param>
        /// <returns></returns>
        public static double Division(double first, double second, int decimals = -1)
        {
            // double类型不能直接判断0，会有精度丢失
            // 而当除数=0时，计算结果=正负无穷大，并不会报错
            double result = first / second;
            result = double.IsInfinity(result) ? 0 : result;
            return decimals < 0 ? result : Math.Round(result, decimals);
        }
    }
}
