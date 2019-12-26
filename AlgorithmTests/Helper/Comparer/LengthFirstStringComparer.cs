using System;
using System.Collections.Generic;
using System.Text;

namespace ubacs.AlgorithmTests.Helper
{
    internal class LengthFirstStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null)
            {
                return y == null ? 0 : -1;
            }

            if (y == null)
            {
                return 1;
            }

            if (x.Length == y.Length)
            {
                return x.CompareTo(y);
            }

            return x.Length - y.Length;
        }
    }
}
