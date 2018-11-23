using System.Linq;
using linq_tdd;
using Xunit;

namespace tests
{
    public class SelectMany2Tests
    {
        protected struct StringWithIntArray
        {
            public string name { get; set; }
            public int?[] total { get; set; }
        }

        [Fact]
        public void EmptySource()
        {
            Assert.Empty(Enumerable.Empty<StringWithIntArray>().SelectMany2(e => e.total));
        }

        [Fact]
        public void SingleElement()
        {
            int?[] expected = { 90, 55, null, 43, 89 };
            StringWithIntArray[] source =
            {
                new StringWithIntArray { name = "Prakash", total = expected }
            };
            Assert.Equal(expected, source.SelectMany2(e => e.total));
        }

        [Fact]
        public void NonEmptySelectingEmpty()
        {
            StringWithIntArray[] source =
            {
                new StringWithIntArray { name="Prakash", total=new int?[0] },
                new StringWithIntArray { name="Bob", total=new int?[0] },
                new StringWithIntArray { name="Chris", total=new int?[0] },
                new StringWithIntArray { name=null, total=new int?[0] },
                new StringWithIntArray { name="Prakash", total=new int?[0] }
            };

            Assert.Empty(source.SelectMany2(e => e.total));
        }

        [Fact]
        public void ResultsSelected()
        {
            StringWithIntArray[] source =
            {
                new StringWithIntArray { name="Prakash", total=new int?[]{1, 2, 3, 4} },
                new StringWithIntArray { name="Bob", total=new int?[]{5, 6} },
                new StringWithIntArray { name="Chris", total=new int?[0] },
                new StringWithIntArray { name=null, total=new int?[]{8, 9} },
                new StringWithIntArray { name="Prakash", total=new int?[]{-10, 100} }
            };
            int?[] expected = { 1, 2, 3, 4, 5, 6, 8, 9, -10, 100 };
            Assert.Equal(expected, source.SelectMany2(e => e.total));
        }
    }
}