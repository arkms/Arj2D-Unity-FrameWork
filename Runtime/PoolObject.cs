using UnityEngine;
using System.Collections.Generic;

// Note: The gameobject is never activate by any spawn, is better activate when you finish all your setup you need.

namespace Arj2D
{
    public class PoolObject
    {
        private GameObject prefab;
        private Queue<GameObject> pool;
        private Transform parentTranform; //father transform

        /// <summary>
        /// Add Prefab to Pool
        /// </summary>
        /// <param name="_prefab">Prefab</param>
        /// <param name="_size">Inicial number of prefab</param>
        public void Init(GameObject _prefab, int _size = 3)
        {
            if (parentTranform == null)
            {
                GameObject go = new GameObject(_prefab.name + "_Pool");
                parentTranform = go.transform;

                prefab = _prefab;
                pool = new Queue<GameObject>(_size);
            }
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
            GameObject go = GetNextGameObject();
            go.transform.localPosition = _pos;
            go.transform.localRotation = _rotation;
            return go;
        }

        /// <summary>
        /// Spawn new object
        /// </summary>
        /// <param name="_pos">Position</param>
        /// <returns>GameObject create</returns>
        public GameObject Spawn(Vector3 _pos)
        {
            GameObject go = GetNextGameObject();
            go.transform.localPosition = _pos;
            return go;
        }

        /// <summary>
        /// Spawn new object, using vector2
        /// </summary>
        /// <param name="_pos">Position</param>
        /// <param name="_rotation">Rotation</param>
        /// <returns>GameObject create</returns>
        public GameObject Spawn(Vector2 _pos)
        {
            GameObject go = GetNextGameObject();
            go.transform.localPosition = _pos;
            return go;
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
            foreach (GameObject go in pool)
            {
                Object.Destroy(go);
            }

            pool.Clear();
        }

        public void ReturnGameObjectToPool(GameObject _go)
        {
            _go.SetActive(false);
            pool.Enqueue(_go);
        }

        private GameObject Expand()
        {
            GameObject go = Object.Instantiate(prefab, parentTranform);
            pool.Enqueue(go);
            go.name = $"{prefab.name}_{parentTranform.childCount}";
            go.GetComponent<IPoolObject>().poolContainer = this;
            go.SetActive(false);
            return go;
        }

        GameObject GetNextGameObject()
        {
            return pool.Count > 0 ? pool.Dequeue() : Expand();
        }
    }
}