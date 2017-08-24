using System;
using System.Collections.Generic;

namespace UnityUtilities.Generic
{
    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        private readonly int equal;

        public DuplicateKeyComparer(bool equalValueFlush = false)
        {
            equal = equalValueFlush ? -1 : 1;
        }

        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);
            return result == 0 ? equal : result;
        }
    }
}
