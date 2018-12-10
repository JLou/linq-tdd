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
            throw new NotImplementedException();
        }
    }
}