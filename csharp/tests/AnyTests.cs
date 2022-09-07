using linq_tdd;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace tests
{
    public class AnyTests
    {
        [Fact]
        public void SameResultsRepeatCallsIntQuery()
        {
            var q = from x in new[] { 9999, 0, 888, -1, 66, -777, 1, 2, -12345 }
                    where x > int.MinValue
                    select x;

            Func<int, bool> predicate = (i) => i % 2 == 0;
            Assert.Equal(q.Any2(predicate), q.Any2(predicate));
        }

        [Fact]
        public void SameResultsRepeatCallsStringQuery()
        {
            var q = from x in new[] { "!@#$%^", "C", "AAA", "", "Calling Twice", "SoS", string.Empty }
                    select x;

            Func<string, bool> predicate = string.IsNullOrEmpty;
            Assert.Equal(q.Any2(predicate), q.Any2(predicate));
        }


        public static IEnumerable<object[]> TestDataWithPredicate()
        {
            yield return new object[] { new int[0], null, false };
            yield return new object[] { new int[] { 3 }, null, true };

            Func<int, bool> isEvenFunc = (i) => i % 2 == 0;
            yield return new object[] { new int[0], isEvenFunc, false };
            yield return new object[] { new int[] { 4 }, isEvenFunc, true };
            yield return new object[] { new int[] { 5 }, isEvenFunc, false };
            yield return new object[] { new int[] { 5, 9, 3, 7, 4 }, isEvenFunc, true };
            yield return new object[] { new int[] { 5, 8, 9, 3, 7, 11 }, isEvenFunc, true };

            int[] range = Enumerable.Range(1, 10).ToArray();
            yield return new object[] { range, (Func<int, bool>)(i => i > 10), false };
            for (int j = 0; j <= 9; j++)
            {
                int k = j; // Local copy for iterator
                yield return new object[] { range, (Func<int, bool>)(i => i > k), true };
            }
        }

        [Theory]
        [MemberData(nameof(TestDataWithPredicate))]
        public void Any2_Predicate(IEnumerable<int> source, Func<int, bool> predicate, bool expected)
        {
            if (predicate == null)
            {
                Assert.Equal(expected, source.Any2());
            }
            else
            {
                Assert.Equal(expected, source.Any2(predicate));
            }
        }

        [Theory, MemberData(nameof(TestDataWithPredicate))]
        public void Any2RunOnce(IEnumerable<int> source, Func<int, bool> predicate, bool expected)
        {
            if (predicate == null)
            {
                Assert.Equal(expected, source.Any2());
            }
            else
            {
                Assert.Equal(expected, source.Any2(predicate));
            }
        }

        [Fact]
        public void NullObjectsInArray_Included()
        {
            int?[] source = { null, null, null, null };
            Assert.True(source.Any2());
        }
    }
}
