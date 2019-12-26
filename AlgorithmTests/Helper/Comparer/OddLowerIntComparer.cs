using System;
using System.Collections.Generic;
using System.Text;

namespace ubacs.AlgorithmTests.Helper
{
    internal class OddLowerIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if ((x & 1) == (y & 1))
            {
                return x.CompareTo(y);
            }

            return (x & 1) == 1 ? -1 : 1;
        }
    }
}
