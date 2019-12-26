using System;
using System.Collections.Generic;
using System.Text;

using ubacs.AlgorithmTests.Helper;

namespace ubacs.AlgorithmTests.Sorting
{
    internal class MutableComparableTestData : ISortTestData<MutableComparableReferenceType<int>>
    {
        public List<List<MutableComparableReferenceType<int>>> Lists { get; }

        public List<IComparer<MutableComparableReferenceType<int>>> Comparers { get; }

        public MutableComparableTestData()
        {
            Lists = new List<List<MutableComparableReferenceType<int>>>
            {
                new List<MutableComparableReferenceType<int>>(),
                RandomMutableComparableList(1, int.MinValue, int.MaxValue),
                RandomMutableComparableList(2, int.MinValue, int.MaxValue),
                RandomMutableComparableList(100, -10, 10)
            };

            Comparers = new List<IComparer<MutableComparableReferenceType<int>>>()
            {
                Comparer<MutableComparableReferenceType<int>>.Default,
                new ReverseComparer<MutableComparableReferenceType<int>>(Comparer<MutableComparableReferenceType<int>>.Default),

            };
        }

        private static List<MutableComparableReferenceType<int>> RandomMutableComparableList(int count, int lowerBound, int upperBound)
        {
            List<MutableComparableReferenceType<int>> list = new List<MutableComparableReferenceType<int>>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new MutableComparableReferenceType<int>(RandomProvider.Instance.Random.Next(lowerBound, upperBound)));
            }
            return list;
        }
    }
}
