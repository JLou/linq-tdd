using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TSource> Take2<TSource>(this IEnumerable<TSource> source, int count)
        {
            var enumerator = source.GetEnumerator();
            while (count > 0 && enumerator.MoveNext())
            {
                count--;
                yield return enumerator.Current;
            }
        }
    }
}
