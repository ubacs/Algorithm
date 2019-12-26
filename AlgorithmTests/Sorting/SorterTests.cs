using System;
using System.Collections.Generic;
using Xunit;

using ubacs.Algorithm.Sorting;
using ubacs.AlgorithmTests.Helper;

namespace ubacs.AlgorithmTests.Sorting
{
    public abstract class SorterTests<TSorter> where TSorter : Sorter, new()
    {

        [Fact]
        public void Sort_IList_ThrowsOnNullParameter()
        {
            List<int> list = null;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(list));
        }

        [Fact]
        public void Sort_IList_ThrowsOnNotIComparable()
        {
            List<NotIComparable> list = new List<NotIComparable>()
            {
                new NotIComparable()
            };

            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentException>(() => sorter.Sort(list));
        }

        [Theory]
        [MemberData(nameof(TestCases<int>.Data), MemberType = typeof(TestCases<int>))]
        [MemberData(nameof(TestCases<string>.Data), MemberType = typeof(TestCases<string>))]
        [MemberData(nameof(TestCases<MutableComparableReferenceType<int>>.Data), MemberType = typeof(TestCases<MutableComparableReferenceType<int>>))]
        public void Sort_IList_CorrectSorting<T>(IList<T> list)
        {
            List<T> expected = new List<T>(list);
            expected.Sort();

            TSorter sorter = new TSorter();
            sorter.Sort(list);
            Assert.Equal(expected, list);
        }

        [Fact]
        public void Sort_IList_IComparer_ThrowsOnNullList()
        {
            List<int> list = null;
            Comparer<int> comparer = Comparer<int>.Default;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(list, comparer));
        }

        [Fact]
        public void Sort_IList_IComparer_ThrowsOnNullComparer()
        {
            List<int> list = new List<int>();
            Comparer<int> comparer = null;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(list, comparer));
        }

        [Theory]
        [MemberData(nameof(TestCases<int>.DataWithComparer), MemberType = typeof(TestCases<int>))]
        [MemberData(nameof(TestCases<string>.DataWithComparer), MemberType = typeof(TestCases<string>))]
        [MemberData(nameof(TestCases<MutableComparableReferenceType<int>>.DataWithComparer), MemberType = typeof(TestCases<MutableComparableReferenceType<int>>))]
        public void Sort_IList_IComparer_CorrectSorting<T>(IList<T> list, IComparer<T> comparer)
        {
            List<T> expected = new List<T>(list);
            expected.Sort(comparer);

            TSorter sorter = new TSorter();
            sorter.Sort(list, comparer);
            Assert.Equal(expected, list);
        }

        [Fact]
        public void Sort_IList_Int_Int_IComparer_ThrowsOnNullList()
        {
            List<int> list = null;
            int index = 2;
            int count = 5;
            Comparer<int> comparer = Comparer<int>.Default;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(list, index, count, comparer));
        }

        [Fact]
        public void Sort_IList_Int_Int_IComparer_ThrowsOnNegativeIndex()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3 };
            int index = -1;
            int count = 2;
            Comparer<int> comparer = Comparer<int>.Default;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentOutOfRangeException>(() => sorter.Sort(list, index, count, comparer));
        }

        [Fact]
        public void Sort_IList_Int_Int_IComparer_ThrowsOnNegativeCount()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3 };
            int index = 2;
            int count = -3;
            Comparer<int> comparer = Comparer<int>.Default;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentOutOfRangeException>(() => sorter.Sort(list, index, count, comparer));
        }

        [Theory]
        [InlineData(3, 2, 2)]
        [InlineData(3, 0, 4)]
        [InlineData(3, 4, 0)]
        public void Sort_IList_Int_Int_IComparer_ThrowsOnOutOfRange(int size, int index, int count)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }
            Comparer<int> comparer = Comparer<int>.Default;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentException>(() => sorter.Sort(list, index, count, comparer));
        }

        [Fact]
        public void Sort_IList_Int_Int_IComparer_ThrowsOnNullComparer()
        {
            List<int> list = new List<int> { 123 };
            int index = 0;
            int count = 1;
            Comparer<int> comparer = null;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(list, index, count, comparer));
        }

        [Theory]
        [MemberData(nameof(TestCases<int>.DataWithIndexCountComparer), MemberType = typeof(TestCases<int>))]
        [MemberData(nameof(TestCases<string>.DataWithIndexCountComparer), MemberType = typeof(TestCases<string>))]
        [MemberData(nameof(TestCases<MutableComparableReferenceType<int>>.DataWithIndexCountComparer), MemberType = typeof(TestCases<MutableComparableReferenceType<int>>))]
        public void Sort_IList_Int_Int_IComparer_CorrectSorting<T>(IList<T> list, int index, int count, IComparer<T> comparer)
        {
            List<T> expected = new List<T>(list);
            expected.Sort(index, count, comparer);

            TSorter sorter = new TSorter();
            sorter.Sort(list, index, count, comparer);
            Assert.Equal(expected, list);
        }

        [Fact]
        public void Sort_IList_Comparison_ThrowsOnNullList()
        {
            List<int> list = null;
            Comparison<int> comparison = (a, b) => 1;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(list, comparison));
        }

        [Fact]
        public void Sort_IList_Comparison_ThrowsOnNullComparison()
        {
            List<int> list = new List<int>();
            Comparison<int> comparison = null;
            TSorter sorter = new TSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(list, comparison));
        }


        [Theory]
        [MemberData(nameof(TestCases<int>.DataWithComparison), MemberType = typeof(TestCases<int>))]
        [MemberData(nameof(TestCases<string>.DataWithComparison), MemberType = typeof(TestCases<string>))]
        [MemberData(nameof(TestCases<MutableComparableReferenceType<int>>.DataWithComparison), MemberType = typeof(TestCases<MutableComparableReferenceType<int>>))]
        public void Sort_IList_Comparison_CorrectSorting<T>(IList<T> list, Comparison<T> comparison)
        {
            List<T> expected = new List<T>(list);
            expected.Sort(comparison);

            TSorter sorter = new TSorter();
            sorter.Sort(list, comparison);
            Assert.Equal(expected, list);
        }
    }
}
