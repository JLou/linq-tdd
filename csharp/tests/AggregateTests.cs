using System.Collections.Generic;
using linq_tdd;
using Xunit;

namespace tests
{
    public class AggregateTests
    {
        [Fact]
        public void NoElementsSeedResultSeletor()
        {
            int[] source = { };
            long seed = 2;
            double expected = 7;

            Assert.Equal(expected, source.Aggregate2(seed, (x, y) => x * y, x => x + 5.0));
        }

        [Fact]
        public void MultipleElementsSeedResultSelector()
        {
            int[] source = { 5, 6, 2, -4 };
            long seed = 2;
            long expected = -475;

            Assert.Equal(expected, source.Aggregate2(seed, (x, y) => x * y, x => x + 5.0));
        }

        [Fact]
        public void TwoElementsSeedResultSelector()
        {
            int[] source = { 5, 6 };
            long seed = 2;
            long expected = 65;

            Assert.Equal(expected, source.Aggregate2(seed, (x, y) => x * y, x => x + 5.0));
        }

        [Fact]
        public void SingleElementSeedResultSelector()
        {
            int[] source = { 5 };
            long seed = 2;
            long expected = 15;

            Assert.Equal(expected, source.Aggregate2(seed, (x, y) => x * y, x => x + 5.0));
        }
    }
}