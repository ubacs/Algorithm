using System;
using System.Collections.Generic;
using System.Text;

using ubacs.AlgorithmTests.Helper;

namespace ubacs.AlgorithmTests.Sorting
{
    internal class StringTestData : ISortTestData<string>
    {
        public List<List<string>> Lists { get;  }

        public List<IComparer<string>> Comparers { get;  }

        public StringTestData()
        {
            Lists = new List<List<string>>()
            {
                new List<string>(),
                new List<string>() { "abc" },
                new List<string>() { "abc", "bca" },
                new List<string>() { "a", "b", "A", "B" },
                new List<string>() { "a", "aa", "ab", "ac", "b", "ba", "bb", "bc", "c", "ca", "cb", "cc" },
                new List<string>() { "cc", "cb", "ca", "c", "bc", "bb", "ba", "b", "ac", "ab", "aa", "a" },
                RandomStringList(10),
                RandomStringList(100)
            };

            Comparers = new List<IComparer<string>>()
            {
                Comparer<string>.Default,
                new ReverseComparer<string>(Comparer<string>.Default),
                new LengthFirstStringComparer()
            };
        }

        private static List<string> RandomStringList(int count)
        {
            List<string> referenceStrings = new List<string>() { "a", "b", "c", "aa", "ab", "ac", "ba", "bb", "bc", "ca", "cb", "cc" };

            List<string> list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list.Add(referenceStrings[RandomProvider.Instance.Random.Next(0, referenceStrings.Count)]);
            }
            return list;
        }
    }
}
