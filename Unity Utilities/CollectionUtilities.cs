using System.Collections.Generic;
using System.Linq;

namespace UnityUtilities
{
    public class CollectionUtilities
    {
        public static KeyValuePair<T1, T2>[] GetKeyValuePairs<T1, T2>(Dictionary<T1, T2> dictionary) => dictionary.ToArray();
    }
}
