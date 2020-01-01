using System;
using System.Collections.Generic;
using System.Text;

using ubacs.Algorithm.Common;

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
                throw new ArgumentNullException(nameof(list), Messages.ArgumentNullExceptionMessage);
            }
            if (i < 0 || i >= list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(i), Messages.ArgumentOutOfRangeException);
            }
            if (j < 0 || j >= list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(j), Messages.ArgumentOutOfRangeException);
            }

            T tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }
}
