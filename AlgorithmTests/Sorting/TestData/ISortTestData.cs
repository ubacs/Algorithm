using System;
using System.Collections.Generic;
using System.Text;

namespace ubacs.AlgorithmTests.Sorting
{
    interface ISortTestData<T>
    {
        List<List<T>> Lists { get; }

        List<IComparer<T>> Comparers { get; }
    }
}
