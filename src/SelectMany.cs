using System;
using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TResult> SelectMany2<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
        }
    }
}