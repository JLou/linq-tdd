using System;
using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TSource> Where2<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }

        }
    }
}