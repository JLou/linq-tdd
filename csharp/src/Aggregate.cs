using System;
using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static TResult Aggregate2<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
        {
            var enumerator = source.GetEnumerator();
            var acc = seed;

            while(enumerator.MoveNext())
            {
                acc = func(acc, enumerator.Current);
            }
            return resultSelector(acc);
        }
    }
}