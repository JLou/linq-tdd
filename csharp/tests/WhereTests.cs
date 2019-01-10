using linq_tdd;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;


namespace tests
{
    public class WhereTests
    {
        [Fact]
        public void Where_IEnumerable_ExecutionIsDeferred()
        {
            bool funcCalled = false;
            IEnumerable<Func<bool>> source = Enumerable.Repeat((Func<bool>)(() => { funcCalled = true; return true; }), 1);

            IEnumerable<Func<bool>> query = source.Where2(value => value());
            Assert.False(funcCalled);
        }

        [Fact]
        public void Where_Array_ReturnsExpectedValues_True()
        {
            int[] source = new[] { 1, 2, 3, 4, 5 };
            Func<int, bool> truePredicate = (value) => true;

            IEnumerable<int> result = source.Where2(truePredicate);

            Assert.Equal(source.Length, result.Count());
            for (int i = 0; i < source.Length; i++)
            {
                Assert.Equal(source.ElementAt(i), result.ElementAt(i));
            }
        }

        [Fact]
        public void Where_Array_ReturnsExpectedValues_False()
        {
            int[] source = new[] { 1, 2, 3, 4, 5 };
            Func<int, bool> falsePredicate = (value) => false;

            IEnumerable<int> result = source.Where2(falsePredicate);

            Assert.Empty(result);
        }

        [Fact]
        public void Where_List_ReturnsExpectedValues_True()
        {
            List<int> source = new List<int> { 1, 2, 3, 4, 5 };
            Func<int, bool> truePredicate = (value) => true;

            IEnumerable<int> result = source.Where2(truePredicate);

            Assert.Equal(source.Count, result.Count());
            for (int i = 0; i < source.Count; i++)
            {
                Assert.Equal(source.ElementAt(i), result.ElementAt(i));
            }
        }

        [Fact]
        public void Where_List_ReturnsExpectedValues_False()
        {
            List<int> source = new List<int> { 1, 2, 3, 4, 5 };
            Func<int, bool> falsePredicate = (value) => false;

            IEnumerable<int> result = source.Where2(falsePredicate);

            Assert.Empty(result);
        }


        [Fact]
        public void Where_IReadOnlyCollection_ReturnsExpectedValues_True()
        {
            IReadOnlyCollection<int> source = new ReadOnlyCollection<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> truePredicate = (value) => true;

            IEnumerable<int> result = source.Where2(truePredicate);

            Assert.Equal(source.Count, result.Count());
            for (int i = 0; i < source.Count; i++)
            {
                Assert.Equal(source.ElementAt(i), result.ElementAt(i));
            }
        }

        [Fact]
        public void Where_IReadOnlyCollection_ReturnsExpectedValues_False()
        {
            IReadOnlyCollection<int> source = new ReadOnlyCollection<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> falsePredicate = (value) => false;

            IEnumerable<int> result = source.Where2(falsePredicate);

            Assert.Empty(result);
        }


        [Fact]
        public void Where_ICollection_ReturnsExpectedValues_True()
        {
            ICollection<int> source = new LinkedList<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> truePredicate = (value) => true;

            IEnumerable<int> result = source.Where2(truePredicate);

            Assert.Equal(source.Count, result.Count());
            for (int i = 0; i < source.Count; i++)
            {
                Assert.Equal(source.ElementAt(i), result.ElementAt(i));
            }
        }

        [Fact]
        public void Where_ICollection_ReturnsExpectedValues_False()
        {
            ICollection<int> source = new LinkedList<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> falsePredicate = (value) => false;

            IEnumerable<int> result = source.Where2(falsePredicate);

            Assert.Empty(result);
        }


        [Fact]
        public void Where_IEnumerable_ReturnsExpectedValues_True()
        {
            IEnumerable<int> source = Enumerable.Range(1, 5);
            Func<int, bool> truePredicate = (value) => true;

            IEnumerable<int> result = source.Where2(truePredicate);

            Assert.Equal(source.Count(), result.Count());
            for (int i = 0; i < source.Count(); i++)
            {
                Assert.Equal(source.ElementAt(i), result.ElementAt(i));
            }
        }

        [Fact]
        public void Where_IEnumerable_ReturnsExpectedValues_False()
        {
            IEnumerable<int> source = Enumerable.Range(1, 5);
            Func<int, bool> falsePredicate = (value) => false;

            IEnumerable<int> result = source.Where2(falsePredicate);

            Assert.Empty(result);
        }
        [Fact]
        public void Where_EmptyEnumerable_ReturnsNoElements()
        {
            IEnumerable<int> source = Enumerable.Empty<int>();
            bool wasSelectorCalled = false;

            IEnumerable<int> result = source.Where2(value => { wasSelectorCalled = true; return true; });

            Assert.Empty(result);
            Assert.False(wasSelectorCalled);
        }

        [Fact]
        public void WhereWhere_Array_ReturnsExpectedValues()
        {
            int[] source = new[] { 1, 2, 3, 4, 5 };
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;

            IEnumerable<int> result = source.Where2(evenPredicate).Where2(evenPredicate);

            Assert.Equal(2, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
        }

        [Fact]
        public void WhereWhere_List_ReturnsExpectedValues()
        {
            List<int> source = new List<int> { 1, 2, 3, 4, 5 };
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;

            IEnumerable<int> result = source.Where2(evenPredicate).Where2(evenPredicate);

            Assert.Equal(2, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
        }

        [Fact]
        public void WhereWhere_IReadOnlyCollection_ReturnsExpectedValues()
        {
            IReadOnlyCollection<int> source = new ReadOnlyCollection<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;

            IEnumerable<int> result = source.Where2(evenPredicate).Where2(evenPredicate);

            Assert.Equal(2, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
        }

        [Fact]
        public void WhereWhere_ICollection_ReturnsExpectedValues()
        {
            ICollection<int> source = new LinkedList<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;

            IEnumerable<int> result = source.Where2(evenPredicate).Where2(evenPredicate);

            Assert.Equal(2, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
        }

        [Fact]
        public void WhereWhere_IEnumerable_ReturnsExpectedValues()
        {
            IEnumerable<int> source = Enumerable.Range(1, 5);
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;

            IEnumerable<int> result = source.Where2(evenPredicate).Where2(evenPredicate);

            Assert.Equal(2, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelect_Array_ReturnsExpectedValues()
        {
            int[] source = new[] { 1, 2, 3, 4, 5 };
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelectSelect_Array_ReturnsExpectedValues()
        {
            int[] source = new[] { 1, 2, 3, 4, 5 };
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(i => i).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelect_List_ReturnsExpectedValues()
        {
            List<int> source = new List<int> { 1, 2, 3, 4, 5 };
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelectSelect_List_ReturnsExpectedValues()
        {
            List<int> source = new List<int> { 1, 2, 3, 4, 5 };
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(i => i).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelect_IReadOnlyCollection_ReturnsExpectedValues()
        {
            IReadOnlyCollection<int> source = new ReadOnlyCollection<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelectSelect_IReadOnlyCollection_ReturnsExpectedValues()
        {
            IReadOnlyCollection<int> source = new ReadOnlyCollection<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(i => i).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelect_ICollection_ReturnsExpectedValues()
        {
            ICollection<int> source = new LinkedList<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelectSelect_ICollection_ReturnsExpectedValues()
        {
            ICollection<int> source = new LinkedList<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(i => i).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelect_IEnumerable_ReturnsExpectedValues()
        {
            IEnumerable<int> source = Enumerable.Range(1, 5);
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void WhereSelectSelect_IEnumerable_ReturnsExpectedValues()
        {
            IEnumerable<int> source = Enumerable.Range(1, 5);
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Where2(evenPredicate).Select(i => i).Select(addSelector);

            Assert.Equal(2, result.Count());
            Assert.Equal(3, result.ElementAt(0));
            Assert.Equal(5, result.ElementAt(1));
        }

        [Fact]
        public void SelectWhere_Array_ReturnsExpectedValues()
        {
            int[] source = new[] { 1, 2, 3, 4, 5 };
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Select(addSelector).Where2(evenPredicate);

            Assert.Equal(3, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
            Assert.Equal(6, result.ElementAt(2));
        }

        [Fact]
        public void SelectWhere_List_ReturnsExpectedValues()
        {
            List<int> source = new List<int> { 1, 2, 3, 4, 5 };
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Select(addSelector).Where2(evenPredicate);

            Assert.Equal(3, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
            Assert.Equal(6, result.ElementAt(2));
        }

        [Fact]
        public void SelectWhere_IReadOnlyCollection_ReturnsExpectedValues()
        {
            IReadOnlyCollection<int> source = new ReadOnlyCollection<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Select(addSelector).Where2(evenPredicate);

            Assert.Equal(3, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
            Assert.Equal(6, result.ElementAt(2));
        }

        [Fact]
        public void SelectWhere_ICollection_ReturnsExpectedValues()
        {
            ICollection<int> source = new LinkedList<int>(new List<int> { 1, 2, 3, 4, 5 });
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Select(addSelector).Where2(evenPredicate);

            Assert.Equal(3, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
            Assert.Equal(6, result.ElementAt(2));
        }

        [Fact]
        public void SelectWhere_IEnumerable_ReturnsExpectedValues()
        {
            IEnumerable<int> source = Enumerable.Range(1, 5);
            Func<int, bool> evenPredicate = (value) => value % 2 == 0;
            Func<int, int> addSelector = (value) => value + 1;

            IEnumerable<int> result = source.Select(addSelector).Where2(evenPredicate);

            Assert.Equal(3, result.Count());
            Assert.Equal(2, result.ElementAt(0));
            Assert.Equal(4, result.ElementAt(1));
            Assert.Equal(6, result.ElementAt(2));
        }
    }
}