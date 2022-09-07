using linq_tdd;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace tests
{
    public class TakeTests : EnumerableTests
    {
        [Fact]
        public void SameResultsRepeatCallsIntQuery()
        {
            var q = from x in new[] { 9999, 0, 888, -1, 66, -777, 1, 2, -12345 }
                    where x > int.MinValue
                    select x;

            Assert.Equal(q.Take2(9), q.Take2(9));
        }

        [Fact]
        public void SameResultsRepeatCallsIntQueryIList()
        {
            var q = (from x in new[] { 9999, 0, 888, -1, 66, -777, 1, 2, -12345 }
                     where x > Int32.MinValue
                     select x).ToList();

            Assert.Equal(q.Take2(9), q.Take2(9));
        }

        [Fact]
        public void SameResultsRepeatCallsStringQuery()
        {
            var q = from x in new[] { "!@#$%^", "C", "AAA", "", "Calling Twice", "SoS", string.Empty }
                    where !string.IsNullOrEmpty(x)
                    select x;

            Assert.Equal(q.Take2(7), q.Take2(7));
        }

        [Fact]
        public void SameResultsRepeatCallsStringQueryIList()
        {
            var q = (from x in new[] { "!@#$%^", "C", "AAA", "", "Calling Twice", "SoS", String.Empty }
                     where !String.IsNullOrEmpty(x)
                     select x).ToList();

            Assert.Equal(q.Take2(7), q.Take2(7));
        }

        [Fact]
        public void SourceEmptyCountPositive()
        {
            var source = new int[] { };
            Assert.Empty(source.Take2(5));
        }

        [Fact]
        public void SourceEmptyCountPositiveNotIList()
        {
            var source = NumberRangeGuaranteedNotCollectionType(0, 0);
            Assert.Empty(source.Take2(5));
        }

        [Fact]
        public void SourceNonEmptyCountNegative()
        {
            var source = new[] { 2, 5, 9, 1 };
            Assert.Empty(source.Take2(-5));
        }

        [Fact]
        public void SourceNonEmptyCountNegativeNotIList()
        {
            var source = ForceNotCollection(new[] { 2, 5, 9, 1 });
            Assert.Empty(source.Take2(-5));
        }

        [Fact]
        public void SourceNonEmptyCountZero()
        {
            var source = new[] { 2, 5, 9, 1 };
            Assert.Empty(source.Take2(0));

        }

        [Fact]
        public void SourceNonEmptyCountZeroNotIList()
        {
            var source = ForceNotCollection(new[] { 2, 5, 9, 1 });
            Assert.Empty(source.Take2(0));
        }

        [Fact]
        public void SourceNonEmptyCountOne()
        {
            var source = new[] { 2, 5, 9, 1 };
            int[] expected = { 2 };

            Assert.Equal(expected, source.Take2(1));
        }

        [Fact]
        public void SourceNonEmptyCountOneNotIList()
        {
            var source = ForceNotCollection(new[] { 2, 5, 9, 1 });
            int[] expected = { 2 };

            Assert.Equal(expected, source.Take2(1));
        }

        [Fact]
        public void SourceNonEmptyTakeAllExactly()
        {
            var source = new[] { 2, 5, 9, 1 };

            Assert.Equal(source, source.Take2(source.Length));
        }

        [Fact]
        public void SourceNonEmptyTakeAllExactlyNotIList()
        {
            var source = ForceNotCollection(new[] { 2, 5, 9, 1 });

            Assert.Equal(source, source.Take2(source.Count()));
        }

        [Fact]
        public void SourceNonEmptyTakeAllButOne()
        {
            var source = new[] { 2, 5, 9, 1 };
            int[] expected = { 2, 5, 9 };

            Assert.Equal(expected, source.Take2(3));
        }

        [Fact]
        public void RunOnce()
        {
            var source = new[] { 2, 5, 9, 1 };
            int[] expected = { 2, 5, 9 };

            Assert.Equal(expected, source.RunOnce().Take2(3));
        }

        [Fact]
        public void SourceNonEmptyTakeAllButOneNotIList()
        {
            var source = ForceNotCollection(new[] { 2, 5, 9, 1 });
            int[] expected = { 2, 5, 9 };

            Assert.Equal(expected, source.RunOnce().Take2(3));
        }

        [Fact]
        public void SourceNonEmptyTakeExcessive()
        {
            var source = new int?[] { 2, 5, null, 9, 1 };

            Assert.Equal(source, source.Take2(source.Length + 1));
        }

        [Fact]
        public void SourceNonEmptyTakeExcessiveNotIList()
        {
            var source = ForceNotCollection(new int?[] { 2, 5, null, 9, 1 });

            Assert.Equal(source, source.Take2(source.Count() + 1));
        }

        [Fact]
        public void ForcedToEnumeratorDoesNotEnumerate()
        {
            var iterator1 = NumberRangeGuaranteedNotCollectionType(0, 3).Take2(2);
            // Don't insist on this behaviour, but check it's correct if it happens
            var en1 = iterator1 as IEnumerator<int>;
            Assert.False(en1 != null && en1.MoveNext());
        }

        [Fact]
        public void Count()
        {
            Assert.Equal(2, NumberRangeGuaranteedNotCollectionType(0, 3).Take2(2).Count());
            Assert.Equal(2, new[] { 1, 2, 3 }.Take2(2).Count());
            Assert.Equal(0, NumberRangeGuaranteedNotCollectionType(0, 3).Take2(0).Count());
        }

        [Fact]
        public void ForcedToEnumeratorDoesntEnumerateIList()
        {
            var iterator1 = NumberRangeGuaranteedNotCollectionType(0, 3).ToList().Take2(2);
            // Don't insist on this behaviour, but check it's correct if it happens
            var en1 = iterator1 as IEnumerator<int>;
            Assert.False(en1 != null && en1.MoveNext());
        }

        [Fact]
        public void FollowWithTake2()
        {
            var source = new[] { 5, 6, 7, 8 };
            var expected = new[] { 5, 6 };
            Assert.Equal(expected, source.Take2(5).Take2(3).Take2(2).Take2(40));
        }

        [Fact]
        public void FollowWithTakeNotIList()
        {
            var source = NumberRangeGuaranteedNotCollectionType(5, 4);
            var expected = new[] { 5, 6 };
            Assert.Equal(expected, source.Take2(5).Take2(3).Take2(2));
        }

        [Fact]
        public void FollowWithSkip()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6 };
            var expected = new[] { 3, 4, 5 };
            Assert.Equal(expected, source.Take2(5).Skip(2).Skip(-4));
        }

        [Fact]
        public void FollowWithSkipNotIList()
        {
            var source = NumberRangeGuaranteedNotCollectionType(1, 6);
            var expected = new[] { 3, 4, 5 };
            Assert.Equal(expected, source.Take2(5).Skip(2).Skip(-4));

        }

        [Fact]
        public void ElementAt()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6 };
            var taken0 = source.Take2(3);
            Assert.Equal(1, taken0.ElementAt(0));
            Assert.Equal(3, taken0.ElementAt(2));
            Assert.Throws<ArgumentOutOfRangeException>("index", () => taken0.ElementAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>("index", () => taken0.ElementAt(3));
        }

        [Fact]
        public void ElementAtNotIList()
        {
            var source = ForceNotCollection(new[] { 1, 2, 3, 4, 5, 6 });
            var taken0 = source.Take2(3);
            Assert.Equal(1, taken0.ElementAt(0));
            Assert.Equal(3, taken0.ElementAt(2));
            Assert.Throws<ArgumentOutOfRangeException>("index", () => taken0.ElementAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>("index", () => taken0.ElementAt(3));
        }

        [Fact]
        public void ElementAtOrDefault()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6 };
            var taken0 = source.Take2(3);
            Assert.Equal(1, taken0.ElementAtOrDefault(0));
            Assert.Equal(3, taken0.ElementAtOrDefault(2));
            Assert.Equal(0, taken0.ElementAtOrDefault(-1));
            Assert.Equal(0, taken0.ElementAtOrDefault(3));
        }

        [Fact]
        public void ElementAtOrDefaultNotIList()
        {
            var source = ForceNotCollection(new[] { 1, 2, 3, 4, 5, 6 });
            var taken0 = source.Take2(3);
            Assert.Equal(1, taken0.ElementAtOrDefault(0));
            Assert.Equal(3, taken0.ElementAtOrDefault(2));
            Assert.Equal(0, taken0.ElementAtOrDefault(-1));
            Assert.Equal(0, taken0.ElementAtOrDefault(3));
        }

        [Fact]
        public void First()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            Assert.Equal(1, source.Take2(1).First());
            Assert.Equal(1, source.Take2(4).First());
            Assert.Equal(1, source.Take2(40).First());
            Assert.Throws<InvalidOperationException>(() => source.Take2(0).First());
            Assert.Throws<InvalidOperationException>(() => source.Skip(5).Take2(10).First());
        }

        [Fact]
        public void FirstNotIList()
        {
            var source = ForceNotCollection(new[] { 1, 2, 3, 4, 5 });
            Assert.Equal(1, source.Take2(1).First());
            Assert.Equal(1, source.Take2(4).First());
            Assert.Equal(1, source.Take2(40).First());
            Assert.Throws<InvalidOperationException>(() => source.Take2(0).First());
            Assert.Throws<InvalidOperationException>(() => source.Skip(5).Take2(10).First());
        }

        [Fact]
        public void FirstOrDefault()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            Assert.Equal(1, source.Take2(1).FirstOrDefault());
            Assert.Equal(1, source.Take2(4).FirstOrDefault());
            Assert.Equal(1, source.Take2(40).FirstOrDefault());
            Assert.Equal(0, source.Take2(0).FirstOrDefault());
            Assert.Equal(0, source.Skip(5).Take2(10).FirstOrDefault());

        }

        [Fact]
        public void FirstOrDefaultNotIList()
        {
            var source = ForceNotCollection(new[] { 1, 2, 3, 4, 5 });
            Assert.Equal(1, source.Take2(1).FirstOrDefault());
            Assert.Equal(1, source.Take2(4).FirstOrDefault());
            Assert.Equal(1, source.Take2(40).FirstOrDefault());
            Assert.Equal(0, source.Take2(0).FirstOrDefault());
            Assert.Equal(0, source.Skip(5).Take2(10).FirstOrDefault());
        }

        [Fact]
        public void Last()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            Assert.Equal(1, source.Take2(1).Last());
            Assert.Equal(5, source.Take2(5).Last());
            Assert.Equal(5, source.Take2(40).Last());
            Assert.Throws<InvalidOperationException>(() => source.Take2(0).Last());
            Assert.Throws<InvalidOperationException>(() => Array.Empty<int>().Take2(40).Last());
        }

        [Fact]
        public void LastNotIList()
        {
            var source = ForceNotCollection(new[] { 1, 2, 3, 4, 5 });
            Assert.Equal(1, source.Take2(1).Last());
            Assert.Equal(5, source.Take2(5).Last());
            Assert.Equal(5, source.Take2(40).Last());
            Assert.Throws<InvalidOperationException>(() => source.Take2(0).Last());
            Assert.Throws<InvalidOperationException>(() => ForceNotCollection(Array.Empty<int>()).Take2(40).Last());

        }

        [Fact]
        public void LastOrDefault()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            Assert.Equal(1, source.Take2(1).LastOrDefault());
            Assert.Equal(5, source.Take2(5).LastOrDefault());
            Assert.Equal(5, source.Take2(40).LastOrDefault());
            Assert.Equal(0, source.Take2(0).LastOrDefault());
            Assert.Equal(0, Array.Empty<int>().Take2(40).LastOrDefault());

        }

        [Fact]
        public void LastOrDefaultNotIList()
        {
            var source = ForceNotCollection(new[] { 1, 2, 3, 4, 5 });
            Assert.Equal(1, source.Take2(1).LastOrDefault());
            Assert.Equal(5, source.Take2(5).LastOrDefault());
            Assert.Equal(5, source.Take2(40).LastOrDefault());
            Assert.Equal(0, source.Take2(0).LastOrDefault());
            Assert.Equal(0, ForceNotCollection(Array.Empty<int>()).Take2(40).LastOrDefault());

        }

        [Fact]
        public void ToArray()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(5).ToArray());
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(6).ToArray());
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(40).ToArray());
            Assert.Equal(new[] { 1, 2, 3, 4 }, source.Take2(4).ToArray());
            Assert.Equal(1, source.Take2(1).ToArray().Single());
            Assert.Empty(source.Take2(0).ToArray());
            Assert.Empty(source.Take2(-10).ToArray());
        }

        [Fact]
        public void ToArrayNotList()
        {
            var source = ForceNotCollection(new[] { 1, 2, 3, 4, 5 });
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(5).ToArray());
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(6).ToArray());
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(40).ToArray());
            Assert.Equal(new[] { 1, 2, 3, 4 }, source.Take2(4).ToArray());
            Assert.Equal(1, source.Take2(1).ToArray().Single());
            Assert.Empty(source.Take2(0).ToArray());
            Assert.Empty(source.Take2(-10).ToArray());
        }

        [Fact]
        public void ToList()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(5).ToList());
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(6).ToList());
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(40).ToList());
            Assert.Equal(new[] { 1, 2, 3, 4 }, source.Take2(4).ToList());
            Assert.Equal(1, source.Take2(1).ToList().Single());
            Assert.Empty(source.Take2(0).ToList());
            Assert.Empty(source.Take2(-10).ToList());
        }

        [Fact]
        public void ToListNotList()
        {
            var source = ForceNotCollection(new[] { 1, 2, 3, 4, 5 });
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(5).ToList());
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(6).ToList());
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, source.Take2(40).ToList());
            Assert.Equal(new[] { 1, 2, 3, 4 }, source.Take2(4).ToList());
            Assert.Equal(1, source.Take2(1).ToList().Single());
            Assert.Empty(source.Take2(0).ToList());
            Assert.Empty(source.Take2(-10).ToList());
        }

        [Fact]
        public void TakeCanOnlyBeOneList()
        {
            var source = new[] { 2, 4, 6, 8, 10 };
            Assert.Equal(new[] { 2 }, source.Take2(1));
            Assert.Equal(new[] { 4 }, source.Skip(1).Take2(1));
            Assert.Equal(new[] { 6 }, source.Take2(3).Skip(2));
            Assert.Equal(new[] { 2 }, source.Take2(3).Take2(1));
        }

        [Fact]
        public void TakeCanOnlyBeOneNotList()
        {
            var source = ForceNotCollection(new[] { 2, 4, 6, 8, 10 });
            Assert.Equal(new[] { 2 }, source.Take2(1));
            Assert.Equal(new[] { 4 }, source.Skip(1).Take2(1));
            Assert.Equal(new[] { 6 }, source.Take2(3).Skip(2));
            Assert.Equal(new[] { 2 }, source.Take2(3).Take2(1));
        }

        [Fact]
        public void RepeatEnumerating()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var taken1 = source.Take2(3);
            Assert.Equal(taken1, taken1);
        }

        [Fact]
        public void RepeatEnumeratingNotList()
        {
            var source = ForceNotCollection(new[] { 1, 2, 3, 4, 5 });
            var taken1 = source.Take2(3);
            Assert.Equal(taken1, taken1);
        }

        [Fact]
        public void LazyOverflowRegression()
        {
            var range = NumberRangeGuaranteedNotCollectionType(1, 100);
            var skipped = range.Skip(42); // Min index is 42.
            var taken1 = skipped.Take2(int.MaxValue); // May try to calculate max index as 42 + int.MaxValue, leading to integer overflow.
            Assert.Equal(Enumerable.Range(43, 100 - 42), taken1);
            Assert.Equal(100 - 42, taken1.Count());
            Assert.Equal(Enumerable.Range(43, 100 - 42), taken1.ToArray());
            Assert.Equal(Enumerable.Range(43, 100 - 42), taken1.ToList());
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0, int.MaxValue, 100)]
        [InlineData(int.MaxValue, 0, 0)]
        [InlineData(0xffff, 1, 0)]
        [InlineData(1, 0xffff, 99)]
        [InlineData(int.MaxValue, int.MaxValue, 0)]
        [InlineData(1, int.MaxValue, 99)] // Regression test: The max index is precisely int.MaxValue.
        [InlineData(0, 100, 100)]
        [InlineData(10, 100, 90)]
        public void CountOfLazySkipTakeChain(int skip, int take, int expected)
        {
            int totalCount = 100;
            var partition1 = NumberRangeGuaranteedNotCollectionType(1, totalCount).Skip(skip).Take2(take);
            Assert.Equal(expected, partition1.Count());
            Assert.Equal(expected, partition1.Select(i => i).Count());
            Assert.Equal(expected, partition1.Select(i => i).ToArray().Length);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4 }, 1, 3, 2, 4)]
        [InlineData(new[] { 1 }, 0, 1, 1, 1)]
        [InlineData(new[] { 1, 2, 3, 5, 8, 13 }, 1, int.MaxValue, 2, 13)] // Regression test: The max index is precisely int.MaxValue.
        [InlineData(new[] { 1, 2, 3, 5, 8, 13 }, 0, 2, 1, 2)]
        [InlineData(new[] { 1, 2, 3, 5, 8, 13 }, 500, 2, 0, 0)]
        [InlineData(new int[] { }, 10, 8, 0, 0)]
        public void FirstAndLastOfLazySkipTakeChain(int[] source, int skip, int take, int first, int last)
        {
            var partition1 = ForceNotCollection(source).Skip(skip).Take2(take);

            Assert.Equal(first, partition1.FirstOrDefault());
            Assert.Equal(first, partition1.ElementAtOrDefault(0));
            Assert.Equal(last, partition1.LastOrDefault());
            Assert.Equal(last, partition1.ElementAtOrDefault(partition1.Count() - 1));

        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 1, 3, new[] { -1, 0, 1, 2 }, new[] { 0, 2, 3, 4 })]
        [InlineData(new[] { 0xfefe, 7000, 123 }, 0, 3, new[] { -1, 0, 1, 2 }, new[] { 0, 0xfefe, 7000, 123 })]
        [InlineData(new[] { 0xfefe }, 100, 100, new[] { -1, 0, 1, 2 }, new[] { 0, 0, 0, 0 })]
        [InlineData(new[] { 0xfefe, 123, 456, 7890, 5555, 55 }, 1, 10, new[] { -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, new[] { 0, 123, 456, 7890, 5555, 55, 0, 0, 0, 0, 0, 0, 0 })]
        public void ElementAtOfLazySkipTakeChain(int[] source, int skip, int take, int[] indices, int[] expectedValues)
        {
            var partition1 = ForceNotCollection(source).Skip(skip).Take2(take);

            Assert.Equal(indices.Length, expectedValues.Length);
            for (int i = 0; i < indices.Length; i++)
            {
                Assert.Equal(expectedValues[i], partition1.ElementAtOrDefault(indices[i]));
            }

            int end;
            try
            {
                end = checked(skip + take);
            }
            catch (OverflowException)
            {
                end = int.MaxValue;
            }
        }

        [Fact]
        public void MutableSource()
        {
            var source1 = new List<int>() { 0, 1, 2, 3, 4 };
            var query1 = source1.Take2(3);
            source1.RemoveAt(0);
            source1.InsertRange(2, new[] { -1, -2 });
            Assert.Equal(new[] { 1, 2, -1 }, query1);
        }

        [Fact]
        public void MutableSourceNotList()
        {
            var source1 = new List<int>() { 0, 1, 2, 3, 4 };
            var query1 = ForceNotCollection(source1).Select(i => i).Take2(3);
            source1.RemoveAt(0);
            source1.InsertRange(2, new[] { -1, -2 });
            Assert.Equal(new[] { 1, 2, -1 }, query1);

        }

        [Fact]
        public void NonEmptySource_ConsistencyWithCountable()
        {
            Func<int[]> source = () => new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        }

        [Fact]
        public void NonEmptySource_ConsistencyWithCountable_NotList()
        {
            int[] source = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        }
    }
}
