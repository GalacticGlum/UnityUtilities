using UnityEngine;

namespace UnityUtilities.ObjectPool
{
    public class PoolEntry : MonoBehaviour
    {
        public Pool Pool { get; private set; }

        public static void Create(GameObject gameObject, Pool pool)
        {
            gameObject.AddComponent<PoolEntry>().Pool = pool;
        }
    }
}
