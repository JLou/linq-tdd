using System;
using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static bool Any2<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate = null)
        {
            return false;
        }
    }
}
