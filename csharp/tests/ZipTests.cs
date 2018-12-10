using linq_tdd;
using Xunit;

namespace tests
{
    public class ZipTests
    {
        [Fact]
        public void EmptyListFirst()
        {
            //Arrange
            int[] numbers = { };
            string[] words = { "one", "two", "three" };

            //Act
            var result = numbers.Zip2(words, (first, second) => first + " " + second);

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void EmptyListSecond()
        {
            //Arrange
            int[] numbers = { 1, 2, 3 };
            string[] words = { };

            //Act
            var result = numbers.Zip2(words, (first, second) => first + " " + second);

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakesSmallestFirst()
        {
            //Arrange
            int[] numbers = { 1, 2 };
            string[] words = { "one", "two", "three" };

            //Act
            var result = numbers.Zip2(words, (first, second) => first + " " + second);

            //Assert
            Assert.Collection(result, e => Assert.Equal("1 one", e), e => Assert.Equal("2 two", e));
        }

        [Fact]
        public void TakesSmallestSecond()
        {
            //Arrange
            int[] numbers = { 1, 2, 3 };
            string[] words = { "one", "two" };

            //Act
            var result = numbers.Zip2(words, (first, second) => first + " " + second);

            //Assert
            Assert.Collection(result, e => Assert.Equal("1 one", e), e => Assert.Equal("2 two", e));
        }

        [Fact]
        public void ThirdType()
        {
            //Arrange
            int[] numbers = { 1, 2, 3 };
            string[] words = { "one", "two" };

            //Act
            var result = numbers.Zip2(words, (first, second) => (first, second));

            //Assert
            Assert.Collection(result, e => Assert.Equal((1, "one"), e), e => Assert.Equal((2, "two"), e));
        }
    }
}