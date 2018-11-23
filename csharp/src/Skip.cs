using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TSource> Skip2<TSource>(this IEnumerable<TSource> source, int count)
        {
            var enumerator = source.GetEnumerator();
            while (count > 0 && enumerator.MoveNext())
            {
                count--;
            }
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}
