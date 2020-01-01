using System;
using System.Collections.Generic;

using static ubacs.Algorithm.Generic.Swapper;

namespace ubacs.Algorithm.Sorting
{
    public class SelectionSorter : Sorter
    {
        protected override void SortImpl<T>(IList<T> list, int index, int count, Comparison<T> comparison)
        {
            for (int i = index + count - 1; i > index; i--)
            {
                int maxIndex = index;
                for (int j = index + 1; j <= i; j++)
                {
                    if (comparison(list[maxIndex], list[j]) < 0)
                    {
                        maxIndex = j;
                    }
                }

                SwapElements(list, i, maxIndex);
            }
        }
    }
}
