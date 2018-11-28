using System;
using System.Collections;
using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TResult> Select2<TSource, TResult>(
            this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            throw new NotImplementedException();
        }
    }
}