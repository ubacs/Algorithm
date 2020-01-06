using System;
using System.Collections.Generic;
using System.Linq;

using ubacs.AlgorithmTests.Helper;

namespace ubacs.AlgorithmTests.Sorting
{
    internal static class TestCases<T>
    {
        private static ISortTestData<T> SortTestData { get; }

        private static Random Random { get; } = RandomProvider.Instance.Random;

        static TestCases()
        {
            if (typeof(T) == typeof(int))
            {
                SortTestData = (ISortTestData<T>)new IntTestData();
            }
            else if (typeof(T) == typeof(string))
            {
                SortTestData = (ISortTestData<T>)new StringTestData();
            }
            else if (typeof(T) == typeof(ComparableKeyValuePair<string, int>))
            {
                SortTestData = (ISortTestData<T>)new ComparableKeyValuePairTestData();
            }
            else if (typeof(T) == typeof(MutableComparableReferenceType<int>))
            {
                SortTestData = (ISortTestData<T>)new MutableComparableTestData();
            }
        }

        public static IEnumerable<object[]> Data
        {
            get
            {
                foreach (List<T> list in SortTestData.Lists)
                {
                    yield return new object[] { new List<T>(list) };
                }
            }
        }

        public static IEnumerable<object[]> DataWithComparer
        {
            get
            {
                foreach (List<T> list in SortTestData.Lists)
                {
                    foreach (IComparer<T> comparer in SortTestData.Comparers)
                    {
                        yield return new object[] { new List<T>(list), comparer };
                    }
                }
            }
        }

        public static IEnumerable<object[]> DataWithIndexCountComparer
        {
            get
            {
                foreach (List<T> list in SortTestData.Lists)
                {
                    int index = Random.Next(0, list.Count);
                    int count = Random.Next(0, list.Count - index + 1);
                    foreach (IComparer<T> comparer in SortTestData.Comparers)
                    {
                        yield return new object[] { new List<T>(list), index, count, comparer };
                    }
                }
            }
        }

        public static IEnumerable<object[]> DataWithComparison
        {
            get
            {
                foreach (List<T> list in SortTestData.Lists)
                {
                    foreach (IComparer<T> comparer in SortTestData.Comparers)
                    {
                        Comparison<T> comparison = comparer.Compare;
                        yield return new object[] { new List<T>(list), comparison };
                    }
                }
            }
        }
    }
}
