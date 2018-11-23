using System.Collections.Generic;

namespace linq_tdd
{
    public static partial class EnumerableExtensions
    {
        public static TSource FirstOrDefault2<TSource>(this IEnumerable<TSource> source)
        {
            TSource result = default(TSource);
            using (var _enum = source.GetEnumerator())
            {
                if (_enum.MoveNext())
                    result = _enum.Current;
            }
             return result;

        }
    }
}
