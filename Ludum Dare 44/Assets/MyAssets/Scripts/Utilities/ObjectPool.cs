using System.Collections.Generic;
using UnityEngine;

namespace AdrianKovatana
{
    public class ObjectPool : MonoBehaviour
    {
        public PooledObject prefab;
        public int startUpPoolSize;

        private List<PooledObject> _availableObjects = new List<PooledObject>();

        private void Awake()
        {
            PooledObject obj;
            for(int i = 0; i < startUpPoolSize; i++)
            {
                obj = Instantiate(prefab);
                obj.transform.SetParent(transform, false);
                obj.Pool = this;
                AddObject(obj);
            }
        }

        public PooledObject GetObject()
        {
            PooledObject obj;
            int lastAvailableIndex = _availableObjects.Count - 1;
            if(lastAvailableIndex >= 0)
            {
                obj = _availableObjects[lastAvailableIndex];
                _availableObjects.RemoveAt(lastAvailableIndex);
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj = Instantiate(prefab);
                obj.transform.SetParent(transform, false);
                obj.Pool = this;
            }
            return obj;
        }

        public void AddObject(PooledObject obj)
        {
            obj.gameObject.SetActive(false);
            _availableObjects.Add(obj);
        }

        public static ObjectPool GetPool(PooledObject prefab)
        {
            GameObject obj;
            ObjectPool pool;

            // attempt to find the pool of the prefab
            obj = GameObject.Find(prefab.name + " Pool");

            if(obj)
            {
                pool = obj.GetComponent<ObjectPool>();
                if(pool)
                {
                    return pool;
                }
            }

            // no pool was found, create it
            obj = new GameObject(prefab.name + " Pool");
            pool = obj.AddComponent<ObjectPool>();
            pool.prefab = prefab;
            return pool;
        }
    }
}
