using System;
using System.Collections.Generic;
using System.Text;

using ubacs.AlgorithmTests.Helper;

namespace ubacs.AlgorithmTests.Sorting
{
    internal class ComparableKeyValuePairTestData : ISortTestData<ComparableKeyValuePair<string, int>>
    {
        public List<List<ComparableKeyValuePair<string, int>>> Lists { get; }

        public List<IComparer<ComparableKeyValuePair<string, int>>> Comparers { get; }

        public ComparableKeyValuePairTestData()
        {
            string[] keys = { "A", "B" };
            int[] values = { 1, 2, 3, 4, 5 };
            List<ComparableKeyValuePair<string, int>> list = new List<ComparableKeyValuePair<string, int>>();
            for (int i = keys.Length - 1; i >= 0; i--)
            {
                for (int j = values.Length - 1; j >= 0; j--)
                {
                    list.Add(new ComparableKeyValuePair<string, int>(keys[i], values[j]));
                }
            }

            Lists = new List<List<ComparableKeyValuePair<string, int>>>()
            {
                list
            };

            Comparers = new List<IComparer<ComparableKeyValuePair<string, int>>>()
            {
                Comparer<ComparableKeyValuePair<string, int>>.Default
            };
        }
    }
}
