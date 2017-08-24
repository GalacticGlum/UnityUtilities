using System.Collections.Generic;
using UnityEngine;

namespace UnityUtilities.ObjectPool
{
    public class Pool
    {
        private int idCount = 1;
        private readonly GameObject prefab;
        private readonly Stack<GameObject> inactiveObjects;

        public Pool(GameObject prefab, int size)
        {
            this.prefab = prefab;
            inactiveObjects = new Stack<GameObject>(size);
        }

        public GameObject Spawn(Vector3 position, Quaternion rotation)
        {
            GameObject instance;
            if (inactiveObjects.Count == 0)
            {
                instance = Object.Instantiate(prefab, position, rotation);
                instance.name = prefab.name + " (" + idCount++ + " )";
                PoolEntry.Create(instance, this);
            }
            else
            {
                instance = inactiveObjects.Pop();
                if (instance == null)
                {
                    Spawn(position, rotation);
                }
            }

            if (instance == null)
            {
                Debug.Log("GameObject \"instance\" was null.");
                return null;
            }

            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.SetActive(true);

            return instance;
        }

        public void Destroy(GameObject instance)
        {
            instance.SetActive(false);
            inactiveObjects.Push(instance);
        }
    }
}

