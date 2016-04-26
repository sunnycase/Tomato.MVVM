using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    public static class LinqExtensions
    {
        /// <summary>
        /// 对集合中每个元素执行动作。
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="source">集合</param>
        /// <param name="sinker">动作</param>
        public static void Sink<T>(this IEnumerable<T> source, Action<T> sinker)
        {
            foreach (var item in source)
            {
                sinker(item);
            }
        }

        /// <summary>
        /// 对集合中每个元素执行动作。
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="source">集合</param>
        /// <param name="sinker">动作，第二个参数为索引</param>
        public static void Sink<T>(this IEnumerable<T> source, Action<T, int> sinker)
        {
            int index = 0;
            foreach (var item in source)
            {
                sinker(item, index++);
            }
        }

        /// <summary>
        /// 对两个集合执行同步执行动作。
        /// </summary>
        /// <typeparam name="TFirst">第一个集合的元素类型</typeparam>
        /// <typeparam name="TSecond">第二个集合的元素类型</typeparam>
        /// <param name="first">第一个集合</param>
        /// <param name="second">第二个集合</param>
        /// <param name="sinker">动作</param>
        public static void Sink<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Action<TFirst, TSecond> sinker)
        {
            var enu1 = first.GetEnumerator();
            var enu2 = second.GetEnumerator();

            while (enu1.MoveNext() && enu2.MoveNext())
            {
                sinker(enu1.Current, enu2.Current);
            }
        }

        /// <summary>
        /// 对两个集合执行同步执行动作。
        /// </summary>
        /// <typeparam name="TFirst">第一个集合的元素类型</typeparam>
        /// <typeparam name="TSecond">第二个集合的元素类型</typeparam>
        /// <param name="first">第一个集合</param>
        /// <param name="second">第二个集合</param>
        /// <param name="sinker">动作，第三个参数为索引</param>
        public static void Sink<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Action<TFirst, TSecond, int> sinker)
        {
            var enu1 = first.GetEnumerator();
            var enu2 = second.GetEnumerator();

            int index = 0;
            while (enu1.MoveNext() && enu2.MoveNext())
            {
                sinker(enu1.Current, enu2.Current, index++);
            }
        }

        /// <summary>
        /// 按索引集合提取数组中的元素。
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="source">数组</param>
        /// <param name="indexes">索引列表</param>
        /// <returns>提取的元素集合</returns>
        public static IEnumerable<T> Pick<T>(this T[] source, IEnumerable<int> indexes)
        {
            var result = new List<T>(indexes.Count());
            foreach (var id in indexes)
            {
                if (id < source.Length)
                    result.Add(source[id]);
            }
            return result;
        }
    }
}
