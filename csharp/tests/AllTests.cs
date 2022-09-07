using linq_tdd;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace tests
{
    public class AllTests
    {
        private static Func<int, bool> IsEven = (x) => x % 2 == 0;

        [Fact]
        public void SameResultsRepeatCallsIntQuery()
        {
            var q = from x in new[] { 9999, 0, 888, -1, 66, -777, 1, 2, -12345 }
                    where x > int.MinValue
                    select x;

            Func<int, bool> predicate = IsEven;
            Assert.Equal(q.All2(predicate), q.All2(predicate));
        }

        [Fact]
        public void SameResultsRepeatCallsStringQuery()
        {
            var q = from x in new[] { "!@#$%^", "C", "AAA", "", "Calling Twice", "SoS", string.Empty }
                    select x;

            Func<string, bool> predicate = string.IsNullOrEmpty;
            Assert.Equal(q.All2(predicate), q.All2(predicate));
        }

        public static IEnumerable<object[]> All_TestData()
        {
            Func<int, bool> isEvenFunc = IsEven;
            yield return new object[] { new int[0], isEvenFunc, true };
            yield return new object[] { new int[] { 3 }, isEvenFunc, false };
            yield return new object[] { new int[] { 4 }, isEvenFunc, true };
            yield return new object[] { new int[] { 3 }, isEvenFunc, false };
            yield return new object[] { new int[] { 4, 8, 3, 5, 10, 20, 12 }, isEvenFunc, false };
            yield return new object[] { new int[] { 4, 2, 10, 12, 8, 6, 3 }, isEvenFunc, false };
            yield return new object[] { new int[] { 4, 2, 10, 12, 8, 6, 14 }, isEvenFunc, true };

            int[] range = Enumerable.Range(1, 10).ToArray();
            yield return new object[] { range, (Func<int, bool>)(i => i > 0), true };
            for (int j = 1; j <= 10; j++)
            {
                int k = j; // Local copy for iterator
                yield return new object[] { range, (Func<int, bool>)(i => i > k), false };
            }
        }

        [Theory]
        [MemberData(nameof(All_TestData))]
        public void All2(IEnumerable<int> source, Func<int, bool> predicate, bool expected)
        {
            Assert.Equal(expected, source.All2(predicate));
        }

        [Theory, MemberData(nameof(All_TestData))]
        public void AllRunOnce(IEnumerable<int> source, Func<int, bool> predicate, bool expected)
        {
            Assert.Equal(expected, source.All2(predicate));
        }

    }
}
