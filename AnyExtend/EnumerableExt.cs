using System;
using System.Collections.Generic;
using System.Linq;

namespace AnyExtend
{
    /// <summary>
    /// 用于Distinct选择保留模式
    /// </summary>
    public enum ReserveMode
    {
        First,  // 保留第一个
        Last    // 保留最后一个
    }

    /// <summary>
    /// 用于扩展的Distinct方法
    /// </summary>
    public class PubEqualComparer<T, TResult> : IEqualityComparer<T>
    {
        private Func<T, TResult> keySelector;
        private IEqualityComparer<TResult> comparer;

        public PubEqualComparer(Func<T, TResult> keySelector, IEqualityComparer<TResult> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer;
        }

        public PubEqualComparer(Func<T, TResult> keySelector)
            : this(keySelector, EqualityComparer<TResult>.Default)
        {

        }

        public bool Equals(T t1, T t2)
        {
            return comparer.Equals(keySelector(t1), keySelector(t2));
        }

        public int GetHashCode(T t)
        {
            return comparer.GetHashCode(keySelector(t));
        }
    }

    /// <summary>
    /// 提供IEnumerable扩展方法
    /// </summary>
    public static class EnumerableExt
    {
        /// <summary>
        /// 扩展ForEach方法
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var e in list)
            {
                action(e);
            }
        }

        /// <summary>
        /// 扩展ForEach方法
        /// <para>action返回false中断循环</para>
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> list, Func<T, bool> action)
        {
            foreach (var e in list)
            {
                if (!action(e))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 扩展ForEach方法（带序号）
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T, int> action)
        {
            int i = 0;
            list.ForEach(e => action(e, i++));
        }

        /// <summary>
        /// 扩展ForEach方法（带序号）
        /// <para>action返回false中断循环</para>
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> list, Func<T, int, bool> action)
        {
            int i = 0;
            list.ForEach(e => action(e, i++));
        }

        /// <summary>
        /// 扩展Distinct方法
        /// </summary>
        public static IEnumerable<T> Distinct<T, TResult>(this IEnumerable<T> list, Func<T, TResult> keySelector)
        {
            return list.Distinct(new PubEqualComparer<T, TResult>(keySelector));
        }

        /// <summary>
        /// 扩展Distinct方法
        /// </summary>
        public static IEnumerable<T> Distinct<T, TResult>(this IEnumerable<T> list, Func<T, TResult> keySelector, IEqualityComparer<TResult> comparer)
        {
            return list.Distinct(new PubEqualComparer<T, TResult>(keySelector, comparer));
        }

        /// <summary>
        /// 扩展Except方法
        /// </summary>
        public static IEnumerable<T1> Except<T1, T2, TResult>
        (
            this IEnumerable<T1> first,
            IEnumerable<T2> second,
            Func<T1, TResult> firstKeySelector,
            Func<T2, TResult> secondKeySelector
        )
        {
            return first.Where(t1 =>
                !second.Any(t2 => firstKeySelector(t1).Equals(secondKeySelector(t2)))
            );
        }

        /// <summary>
        /// 扩展SingleOrDefault方法
        /// </summary>
        public static T SingleOrNew<T>(this IEnumerable<T> list, Func<T, bool> predicate) where T : class, new()
        {
            return list.SingleOrDefault(predicate) ?? new T();
        }

        /// <summary>
        /// 扩展FirstOrDefault方法
        /// </summary>
        public static T FirstOrNew<T>(this IEnumerable<T> list, Func<T, bool> predicate) where T : class, new()
        {
            return list.FirstOrDefault(predicate) ?? new T();
        }

        /// <summary>
        /// 封装string.Join方法
        /// </summary>
        public static string Join<T>(this IEnumerable<T> list, string separator)
        {
            return string.Join(separator, list);
        }
        
        public static IEnumerable<TResult> LeftJoin<T1, T2, TKey, TResult>
        (
            this IEnumerable<T1> left,
            IEnumerable<T2> right,
            Func<T1, TKey> leftSelector,
            Func<T2, TKey> rightSelector,
            Func<T1, T2, TResult> resultSelector,
            T2 defaultValue = default(T2)
        )
        {
            return left.GroupJoin(right, leftSelector, rightSelector, (tb1, tb2List) => new { tb1, tb2List })
                .SelectMany(t => t.tb2List.DefaultIfEmpty(defaultValue), (t, tb2) => resultSelector(t.tb1, tb2));
        }

        public static IEnumerable<TResult> RightJoin<T1, T2, TKey, TResult>
        (
            this IEnumerable<T1> left,
            IEnumerable<T2> right,
            Func<T1, TKey> leftSelector,
            Func<T2, TKey> rightSelector,
            Func<T1, T2, TResult> resultSelector,
            T1 defaultValue = default(T1)
        )
        {
            return right.GroupJoin(left, rightSelector, leftSelector, (tb2, tb1List) => new { tb2, tb1List })
                .SelectMany(t => t.tb1List.DefaultIfEmpty(defaultValue), (t, tb1) => resultSelector(tb1, t.tb2));
        }

        public static IEnumerable<TResult> FullJoin<T1, T2, TKey, TResult>
        (
            this IEnumerable<T1> left,
            IEnumerable<T2> right,
            Func<T1, TKey> leftSelector,
            Func<T2, TKey> rightSelector,
            Func<T1, T2, TResult> resultSelector,
            T1 leftDefaultValue = default(T1),
            T2 rightDefaultValue = default(T2)
        )
        {
            // 第1个结果集
            var result1 = left.LeftJoin(right, leftSelector, rightSelector, resultSelector, rightDefaultValue);

            // 第2个结果集
            right = right.Except(left, rightSelector, leftSelector);
            var result2 = left.RightJoin(right, leftSelector, rightSelector, resultSelector, leftDefaultValue);

            // 合并结果
            return result1.Concat(result2);
        }
    }
    
    /// <summary>
    /// 提供List扩展方法
    /// </summary>
    public static class ListExt
    {
        /// <summary>
        /// 安全ForEach方法（带序号），只循环list.Count次
        /// <para>返回true，则继续循环，否则中断循环</para>
        /// </summary>
        public static void SafeForEach<T>(this IList<T> list, Func<T, int, bool> action)
        {
            for (int i = 0, count = list.Count; i < count; i++)
            {
                if (!action(list[i], i))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 扩展Distinct方法（对象需标记为可序列化）
        /// </summary>
        /// <param name="reserveMode">保留模式</param>
        public static List<T> Distinct<T, TResult>(this IList<T> list, Func<T, TResult> keySelector, ReserveMode reserveMode) where T : class
        {
            PubEqualComparer<T, TResult> eq = new PubEqualComparer<T, TResult>(keySelector);
            var result = new List<T>();

            if (reserveMode == ReserveMode.First)
            {
                list.Reverse();
            }

            for (int i = 0, len = list.Count; i < len; i++)
            {
                bool isFind = false;

                for (int j = i + 1; j < len; j++)
                {
                    if (eq.Equals(list[i], list[j]))
                    {
                        isFind = true;
                        break;
                    }
                }

                // 保留最后1个不重复项
                if (!isFind)
                {
                    result.Add(list[i].DeepClone<T>());
                }
            }

            if (reserveMode == ReserveMode.First)
            {
                result.Reverse();
            }

            return result;
        }

        /// <summary>
        /// 扩展List.Add，方便格式化
        /// </summary>
        public static void AddFormat(this IList<string> list, string format, params object[] args)
        {
            list.Add(string.Format(format, args));
        }
    }

    /// <summary>
    /// 提供Dictionary扩展方法
    /// </summary>
    public static class DictionaryExt
    {
        /// <summary>
        /// 扩展Dictionary的Add方法
        /// <para>如果存在相同key，则覆盖value，否则新增</para>
        /// <para>返回旧的value值，如果没有则返回当前value值</para>
        /// </summary>
        public static TValue SafeAdd<TKey, TValue>(this IDictionary<TKey,TValue> dic, TKey key, TValue value)
        {
            TValue oldValue = value;

            if (dic.ContainsKey(key))
            {
                oldValue = dic[key];
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }

            return oldValue;
        }
    }
}
