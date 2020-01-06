using System;
using System.Collections.Generic;
using System.Text;

namespace ubacs.AlgorithmTests.Helper
{
    internal class ComparableKeyValuePair<TKey, TValue> : IComparable<ComparableKeyValuePair<TKey, TValue>> where TKey : IComparable<TKey>
    {
        private KeyValuePair<TKey, TValue> Pair { get; }

        public TKey Key => Pair.Key;

        public TValue Value => Pair.Value;
        
        public ComparableKeyValuePair(TKey key, TValue value)
        {
            Pair = new KeyValuePair<TKey, TValue>(key, value);
        }

        public int CompareTo(ComparableKeyValuePair<TKey, TValue> other)
        {
            if (other == null)
            {
                return 1;
            }
            return Key.CompareTo(other.Key);
        }
    }
}
