using System;
using System.Collections.Generic;
using System.Linq;

namespace ubacs.Algorithm.Sorting
{
    public abstract class Sorter : ISorter
    {
        private static readonly string _parameterNullErrorMessage = "The parameter can not be null.";
        private static readonly string _parameterNegativeErrorMessage = "The parameter can not be negative.";

        public void Sort<T>(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), _parameterNullErrorMessage);
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
                throw new ArgumentNullException(nameof(list), _parameterNullErrorMessage);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer), _parameterNullErrorMessage);
            }

            SortImpl(list, 0, list.Count, comparer.Compare);
        }

        public void Sort<T>(IList<T> list, int index, int count, IComparer<T> comparer)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), _parameterNullErrorMessage);
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), _parameterNegativeErrorMessage);
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), _parameterNegativeErrorMessage);
            }

            if (index + count > list.Count)
            {
                throw new ArgumentException($"The sum of {nameof(index)} and {nameof(count)} can not be higher than the number of elements in {nameof(list)}.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer), _parameterNullErrorMessage);
            }

            SortImpl(list, index, count, comparer.Compare);
        }

        public void Sort<T>(IList<T> list, Comparison<T> comparison)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), _parameterNullErrorMessage);
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison), _parameterNullErrorMessage);
            }

            SortImpl(list, 0, list.Count, comparison);
        }

        protected abstract void SortImpl<T>(IList<T> list, int index, int count, Comparison<T> comparison);
    }
}
