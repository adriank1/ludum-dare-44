using UnityEngine;

namespace AdrianKovatana
{
    public class PooledObject : MonoBehaviour
    {
        public ObjectPool Pool { get; set; }

        private void Awake()
        {
            OnAwake();
        }

        protected void OnAwake()
        {
            //Pool = GetComponentInParent<ObjectPool>();
            //if(Pool == null)
            //{
            //    Debug.LogWarning(name + "does not have a parent pool");
            //}
        }

        public void ReturnToPool()
        {
            if(Pool)
            {
                Pool.AddObject(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ReturnToPool(bool resetTransform)
        {
            if(Pool)
            {
                if(resetTransform)
                    transform.position = Vector3.zero;
                Pool.AddObject(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public T GetPooledInstance<T>() where T : PooledObject
        {
            if(!Pool)
            {
                Pool = ObjectPool.GetPool(this);
            }
            return (T)Pool.GetObject();
        }
    }
}
