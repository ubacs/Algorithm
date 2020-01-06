using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

using ubacs.Algorithm.Sorting;
using ubacs.AlgorithmTests.Helper;

namespace ubacs.AlgorithmTests.Sorting
{
    public abstract class StableSorterTests<TSorter> : SorterTests<TSorter> where TSorter : Sorter, new()
    {
        [Theory]
        [MemberData(nameof(TestCases<ComparableKeyValuePair<string, int>>.Data), MemberType = typeof(TestCases<ComparableKeyValuePair<string, int>>))]
        public void Sort_IList_Stable<T>(IList<T> list)
        {
            List<T> expected = list.OrderBy(item => item).ToList();
            TSorter Sorter = new TSorter();
            Sorter.Sort(list);

            Assert.Equal(expected, list);
        }

        [Theory]
        [MemberData(nameof(TestCases<ComparableKeyValuePair<string, int>>.DataWithComparer), MemberType = typeof(TestCases<ComparableKeyValuePair<string, int>>))]
        public void Sort_IList_IComparer_Stable<T>(IList<T> list, IComparer<T> comparer)
        {
            List<T> expected = list.OrderBy(item => item).ToList();
            TSorter Sorter = new TSorter();
            Sorter.Sort(list, comparer);
            
            Assert.Equal(expected, list);
        }

        //TODO: add tests for the remaining methods
    }
}
