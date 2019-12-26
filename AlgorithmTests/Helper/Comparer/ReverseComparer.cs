using System;
using System.Collections.Generic;
using System.Text;

namespace ubacs.AlgorithmTests.Helper
{
    internal class ReverseComparer<T> : IComparer<T>
    {
        public IComparer<T> Base { get; }

        public ReverseComparer(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer), "The parameter can not be null.");
            }
            Base = comparer;
        }

        public int Compare(T x, T y)
        {
            return Base.Compare(y, x);
        }
    }
}
