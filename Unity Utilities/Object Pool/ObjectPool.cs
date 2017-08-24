using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityUtilities.ObjectPool
{
    public static class ObjectPool
    {
        private static bool hasInitialized;

        private const uint initialPoolSize = 3;
        private static Dictionary<GameObject, Pool> pools;

        private static void Initialize(GameObject prefab = null, uint size = initialPoolSize)
        {
            if (hasInitialized == false)
            {
                SceneManager.activeSceneChanged += OnActiveSceneChanged;
                hasInitialized = true;
            }

            if (pools == null)
            {
                pools = new Dictionary<GameObject, Pool>();
            }

            if (prefab != null && pools.ContainsKey(prefab) == false)
            {
                pools[prefab] = new Pool(prefab, (int) size);
            }
        }

        public static void Warm(GameObject prefab, uint size = 1)
        {
            Initialize(prefab, size);

            GameObject[] instances = new GameObject[size];
            for (int i = 0; i < size; i++)
            {
                instances[i] = Spawn(prefab, Vector3.zero, Quaternion.identity);
                Destroy(instances[i]);
            }
        }

        public static IEnumerator WarmAsync(GameObject prefab, uint size = 1, int rate = 100)
        {
            Initialize(prefab, size);
            GameObject[] instances = new GameObject[size];
            for (int i = 0; i < size; i++)
            {
                instances[i] = Spawn(prefab, Vector3.zero, Quaternion.identity);
                Destroy(instances[i]);

                if (i % rate == 0)
                {
                    yield return null;
                }
            }
        }

        public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            Initialize(prefab);

            return pools[prefab].Spawn(position, rotation);
        }

        public static void Destroy(GameObject instance)
        {
            PoolEntry poolEntry = instance.GetComponent<PoolEntry>();
            if (poolEntry == null)
            {
                Object.Destroy(instance);
            }
            else
            {
                poolEntry.Pool.Destroy(instance);
            }
        }

        private static void OnActiveSceneChanged(Scene oldScene, Scene currentScene)
        {
            pools = null;
        }
    }
}

