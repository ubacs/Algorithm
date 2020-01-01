using System;
using System.Collections.Generic;

using static ubacs.Algorithm.Generic.Swapper;

namespace ubacs.Algorithm.Sorting
{
    public class QuickSorter : Sorter
    {
        protected override void SortImpl<T>(IList<T> list, int index, int count, Comparison<T> comparison)
        {
            if (count < 2)
            {
                return;
            }

            int start = index;
            int end = index + count - 1;
            int p = Partition(list, start, end, comparison);

            SortImpl(list, start, p - start, comparison);
            SortImpl(list, p + 1, end - p, comparison);
        }

        private int Partition<T>(IList<T> list, int start, int end, Comparison<T> comparison)
        {
            int pivot = start + (end - start) / 2;
            SwapElements(list, start, pivot);
            pivot = start;

            int i = start + 1;
            int j = end;
            while (i <= j)
            {
                while (i <= j && comparison(list[i], list[pivot]) <= 0)
                {
                    i++;
                }
                while (i <= j && comparison(list[j], list[pivot]) >= 0)
                {
                    j--;
                }
                if (i < j)
                {
                    SwapElements(list, i, j);
                }
            }

            if (j != pivot)
            {
                SwapElements(list, pivot, j);
            }
            
            return j;
        }
    }
}
