using UnityEngine;
using System.Collections.Generic;

// Note: The gameobject is never activate by any spawn, is better activate when you finish all your setup you need. You can use Spawned from IPoolObject.cs

namespace Arj2D
{
    public class PoolObject
    {
        private GameObject prefab;
        private Queue<PoolObjectStruct> pool;
        private Transform parentTranform; //father transform

        /// <summary>
        /// Add Prefab to Pool
        /// </summary>
        /// <param name="_prefab">Prefab</param>
        /// <param name="_size">Inicial number of prefab</param>
        public void Init(GameObject _prefab, int _size = 3)
        {
            if (pool != null) // Security
                return;
            
            if (parentTranform == null)
            {
                GameObject go = new GameObject(_prefab.name + "_Pool");
                parentTranform = go.transform;
            }
            prefab = _prefab;
            pool = new Queue<PoolObjectStruct>(_size);
            for (int i = 0; i < _size; i++)
            {
                Expand();
            }
        }

        /// <summary>
        /// Is initialize the pool?
        /// </summary>
        /// <returns>true or false if pool initialize</returns>
        public bool IsInit()
        {
            return pool != null;
        }

        // --------------------------------------------
        /// <summary>
        /// Spawn new object
        /// </summary>
        /// <param name="_pos">Position</param>
        /// <param name="_rotation">Rotation</param>
        /// <returns>GameObject create</returns>
        public GameObject Spawn(Vector3 _pos, Quaternion _rotation)
        {
            //Not anyone free,, lets create more
            PoolObjectStruct go = GetNextGameObject();
            go.gameObject.transform.SetLocalPositionAndRotation(_pos, _rotation);
            go.iPoolScript.Spawned();
            return go.gameObject;
        }

        /// <summary>
        /// Spawn new object
        /// </summary>
        /// <param name="_pos">Position</param>
        /// <returns>GameObject create</returns>
        public GameObject Spawn(Vector3 _pos)
        {
            PoolObjectStruct go = GetNextGameObject();
            go.gameObject.transform.localPosition = _pos;
            go.iPoolScript.Spawned();
            return go.gameObject;
        }

        /// <summary>
        /// Spawn new object, using vector2
        /// </summary>
        /// <param name="_pos">Position</param>
        /// <param name="_rotation">Rotation</param>
        /// <returns>GameObject create</returns>
        public GameObject Spawn(Vector2 _pos)
        {
            PoolObjectStruct go = GetNextGameObject();
            go.gameObject.transform.localPosition = _pos;
            go.iPoolScript.Spawned();
            return go.gameObject;
        }

        /// <summary>
        /// Clear all reference from pool.
        /// </summary>
        public void Clear()
        {
            pool.Clear();
        }

        /// <summary>
        /// Clear and destroy in the Pool
        /// </summary>
        public void ClearAndDestroy()
        {
            foreach (PoolObjectStruct go in pool)
            {
                Object.Destroy(go.gameObject);
            }

            pool.Clear();
        }

        public void ReturnGameObjectToPool(GameObject _go, IPoolObject _iPool)
        {
            _go.SetActive(false);
            pool.Enqueue(new PoolObjectStruct()
            {
                gameObject = _go,
                iPoolScript = _iPool
            });
        }

        private PoolObjectStruct Expand()
        {
            GameObject go = Object.Instantiate(prefab, parentTranform);
            IPoolObject iPool = go.GetComponent<IPoolObject>();
            
            PoolObjectStruct poolObject = new PoolObjectStruct()
            {
                gameObject = go,
                iPoolScript = iPool
            };
            
            pool.Enqueue(poolObject);
            go.name = $"{prefab.name}_{parentTranform.childCount}";
            iPool.poolContainer = this;
            go.SetActive(false);
            
            return poolObject;
        }

        PoolObjectStruct GetNextGameObject()
        {
            return pool.Count > 0 ? pool.Dequeue() : Expand();
        }

        struct PoolObjectStruct
        {
            public GameObject gameObject;
            public IPoolObject iPoolScript;
        }
    }
}