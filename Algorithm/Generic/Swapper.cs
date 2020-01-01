using System;
using System.Collections.Generic;
using System.Text;

namespace ubacs.Algorithm.Generic
{
    public static class Swapper
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public static void SwapElements<T>(IList<T> list, int i, int j)
        {

            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "The parameter can not be null.");
            }
            if (i < 0 || i >= list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Index was out of range. Must be non-negative and less than the size of the collection.");
            }
            if (j < 0 || j >= list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(j), "Index was out of range. Must be non-negative and less than the size of the collection.");
            }

            T tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }
}
