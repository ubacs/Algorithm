using System;
using System.Collections.Generic;
using System.Text;

namespace ubacs.AlgorithmTests.Helper
{
    internal class MutableComparableReferenceType<T> : IComparable<MutableComparableReferenceType<T>>
        where T : IComparable<T>
    {
        public T Value { get; set; }

        public MutableComparableReferenceType(T value)
        {
            Value = value;
        }

        public int CompareTo(MutableComparableReferenceType<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
