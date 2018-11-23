using System;
using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static bool Any2<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate = null)
        {
            if (predicate == null)
            {
                return source.GetEnumerator().MoveNext();
            }

            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
