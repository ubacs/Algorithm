using System;
using System.Collections.Generic;
using System.Linq;

using ubacs.Algorithm.Common;

namespace ubacs.Algorithm.Sorting
{
    public abstract class Sorter : ISorter
    {
        public void Sort<T>(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), Messages.ArgumentNullExceptionMessage);
            }

            //This check is added for consistency.
            //Omitting it would mean that sorting elements that are not IComparable will work as long as comparer.Compare is not called (eg. the list has one element),
            //but throw otherwise.
            //TODO: Wouldn't it be better to constraint the method?
            if (!typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)))
            {
                throw new ArgumentException($"{typeof(T)} does not implement {typeof(IComparable<T>)}.");
            }

            Comparer<T> comparer = Comparer<T>.Default;
            SortImpl(list, 0, list.Count, comparer.Compare);
        }

        public void Sort<T>(IList<T> list, IComparer<T> comparer)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), Messages.ArgumentNullExceptionMessage);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer), Messages.ArgumentNullExceptionMessage);
            }

            SortImpl(list, 0, list.Count, comparer.Compare);
        }

        public void Sort<T>(IList<T> list, int index, int count, IComparer<T> comparer)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), Messages.ArgumentNullExceptionMessage);
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), Messages.ArgumentOutOfRangeException);
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Messages.ArgumentOutOfRangeException);
            }

            if (index + count > list.Count)
            {
                throw new ArgumentException($"The sum of {nameof(index)} and {nameof(count)} can not be higher than the number of elements in {nameof(list)}.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer), Messages.ArgumentNullExceptionMessage);
            }

            SortImpl(list, index, count, comparer.Compare);
        }

        public void Sort<T>(IList<T> list, Comparison<T> comparison)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), Messages.ArgumentNullExceptionMessage);
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison), Messages.ArgumentNullExceptionMessage);
            }

            SortImpl(list, 0, list.Count, comparison);
        }

        protected abstract void SortImpl<T>(IList<T> list, int index, int count, Comparison<T> comparison);
    }
}
