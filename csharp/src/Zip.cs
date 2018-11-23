using System;
using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TResult> Zip2<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            var enum1 = first.GetEnumerator();
            var enum2 = second.GetEnumerator();
            while (enum1.MoveNext() && enum2.MoveNext())
            {
                yield return resultSelector(enum1.Current, enum2.Current);
            }
        }
    }
}