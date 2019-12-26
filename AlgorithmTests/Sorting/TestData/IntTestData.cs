using System;
using System.Collections.Generic;
using System.Linq;

using ubacs.AlgorithmTests.Helper;

namespace ubacs.AlgorithmTests.Sorting
{
    internal class IntTestData : ISortTestData<int>
    {
        public List<List<int>> Lists { get; }

        public List<IComparer<int>> Comparers { get; }

        public IntTestData()
        {
            Lists = new List<List<int>>()
            {
                new List<int>(),
                GenerateList(1, int.MinValue, int.MaxValue),
                GenerateList(2, int.MinValue, int.MaxValue),
                new List<int>() { -3, -2, -1, 0, 1, 2, 3 },
                new List<int>() { 3, 2, 1, 0, -1, -2, -3 },
                GenerateList(20, -1, 2),
                GenerateList(100, int.MinValue, int.MaxValue)
            };

            Comparers = new List<IComparer<int>>()
            {
                Comparer<int>.Default,
                new ReverseComparer<int>(Comparer<int>.Default),
                new OddLowerIntComparer(),
                new EvenLowerIntComparer()
            };
        }

        private static List<int> GenerateList(int count, int lowerBound, int upperBound)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(RandomProvider.Instance.Random.Next(lowerBound, upperBound));
                list.Add(5);
            }
            return list;
        }
    }
}
