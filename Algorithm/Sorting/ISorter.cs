using System;
using System.Collections.Generic;

namespace ubacs.Algorithm.Sorting
{
    public interface ISorter
    {
        void Sort<T>(IList<T> list);

        void Sort<T>(IList<T> list, IComparer<T> comparer);

        void Sort<T>(IList<T> list, int index, int count, IComparer<T> comparer);

        void Sort<T>(IList<T> list, Comparison<T> comparison);
    }
}
