using System;
using System.Collections.Generic;
using linq_tdd;
using Xunit;

namespace tests
{
    public class FirstOrDefaultTests
    {
        private static void TestEmptyIList<T>()
        {
            T[] source = { };
            T expected = default(T);

            Assert.IsAssignableFrom<IList<T>>(source);

            Assert.Equal(expected, source.FirstOrDefault2());
        }

        [Fact]
        public void EmptyIListT()
        {
            TestEmptyIList<int>();
            TestEmptyIList<string>();
            TestEmptyIList<DateTime>();
            TestEmptyIList<FirstOrDefaultTests>();
        }

        [Fact]
        public void IListTOneElement()
        {
            int[] source = { 5 };
            int expected = 5;

            Assert.IsAssignableFrom<IList<int>>(source);

            Assert.Equal(expected, source.FirstOrDefault2());
        }

        [Fact]
        public void IListTManyElementsFirstIsDefault()
        {
            int?[] source = { null, -10, 2, 4, 3, 0, 2 };
            int? expected = null;

            Assert.IsAssignableFrom<IList<int?>>(source);

            Assert.Equal(expected, source.FirstOrDefault2());
        }

        [Fact]
        public void IListTManyElementsFirstIsNotDefault()
        {
            int?[] source = { 19, null, -10, 2, 4, 3, 0, 2 };
            int? expected = 19;

            Assert.IsAssignableFrom<IList<int?>>(source);

            Assert.Equal(expected, source.FirstOrDefault2());
        }

        private static IEnumerable<T> GetEmptySource<T>()
        {
            yield break;
        }

        private static void TestEmptyNotIList<T>()
        {
            var source = GetEmptySource<T>();
            T expected = default(T);

            Assert.Null(source as IList<T>);

            Assert.Equal(expected, source.FirstOrDefault2());
        }

        [Fact]
        public void EmptyNotIListT()
        {
            TestEmptyNotIList<int>();
            TestEmptyNotIList<string>();
            TestEmptyNotIList<DateTime>();
            TestEmptyNotIList<FirstOrDefaultTests>();
        }

        [Fact]
        public void OneElementNotIListT()
        {
            IEnumerable<int> source = NumberRangeGuaranteedNotCollectionType(-5, 1);
            int expected = -5;

            Assert.Null(source as IList<int>);

            Assert.Equal(expected, source.FirstOrDefault2());
        }

        [Fact]
        public void ManyElementsNotIListT()
        {
            IEnumerable<int> source = NumberRangeGuaranteedNotCollectionType(3, 10);
            int expected = 3;

            Assert.Null(source as IList<int>);

            Assert.Equal(expected, source.FirstOrDefault2());
        }


        protected static IEnumerable<int> NumberRangeGuaranteedNotCollectionType(int num, int count)
        {
            for (int i = 0; i < count; i++) yield return num + i;
        }

        protected static bool IsEven(int num) => num % 2 == 0;


    }
}