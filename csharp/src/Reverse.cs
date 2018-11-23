using System;
using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TSource> Reverse2<TSource>(this IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            var buffer = new Stack<TSource>();
            while (enumerator.MoveNext())
            {
                buffer.Push(enumerator.Current);
            }
            while (buffer.Count > 0)
            {
                yield return buffer.Pop();
            }
        }
    }
}
