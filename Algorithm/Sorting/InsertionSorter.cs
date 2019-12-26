using System;
using System.Collections.Generic;

namespace ubacs.Algorithm.Sorting
{
    public class InsertionSorter : Sorter
    {
        protected override void SortImpl<T>(IList<T> list, int index, int count, Comparison<T> comparison)
        {
            for (int i = index + 1; i < index + count; i++)
            {
                T tmp = list[i];
                int j = i - 1;
                while (j >= index && comparison(tmp, list[j]) < 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = tmp;
            }
        }
    }
}
