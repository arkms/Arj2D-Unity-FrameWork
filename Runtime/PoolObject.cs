using UnityEngine;
using System.Collections.Generic;

namespace Arj2D
{
    public class PoolObject
    {
        private GameObject Prefab;
        private List<GameObject> Pool;
        private Transform transform_; //father transform

        private int lastIndexUsed = -1;

        /// <summary>
        /// Add Prefab to Pool
        /// </summary>
        /// <param name="_prefab">Prefab</param>
        /// <param name="_size">Inicial number of prefab</param>
        public void Init(GameObject _prefab, int _size = 3)
        {
            if (transform_ == null)
            {
                GameObject go = new GameObject(_prefab.name + "_Pool");
                transform_ = go.transform;

                Prefab = _prefab;
                Pool = new List<GameObject>();
            }
            if (Pool.Count < _size)
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
            return transform_ != null;
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
            go.SetActive(true);
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
            go.SetActive(true);
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
            go.SetActive(true);
            return go;
        }

        public GameObject Spawn(bool _autoActive = true)
        {
            GameObject go = GetNextGameObject();
            if (_autoActive)
                go.SetActive(true);
            return go;
        }

        private int activeGameObjects;
        public int CountActive()
        {
            activeGameObjects = 0;
            int poolSize = Pool.Count;

            for (int i = 0; i < poolSize; i++)
            {
                if (Pool[i].activeSelf == true)
                {
                    activeGameObjects++;
                }
            }
            return activeGameObjects;
        }
        

        /// <summary>
        /// Disable all Gameobject in the Pool
        /// </summary>
        public void Clear()
        {
            foreach (var go in Pool)
            {
                go.SetActive(false);
            }

            lastIndexUsed = -1;
        }

        /// <summary>
        /// Clear and destroy in the Pool
        /// </summary>
        public void ClearAndDestroy()
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                GameObject.Destroy(Pool[i]);
                Pool[i] = null;
            }

            lastIndexUsed = -1;
            Pool.Clear();
        }

        private GameObject Expand()
        {
            GameObject go = GameObject.Instantiate(Prefab, transform_);
            Pool.Add(go);
            go.SetActive(false);
            go.name = $"{Prefab.name}_{Pool.Count}";
            return go;
        }

        GameObject GetNextGameObject()
        {
            int poolCount = Pool.Count;
            if (poolCount > 0)
            {
                int i = lastIndexUsed;
                do
                {
                    i++;
                    if (i >= poolCount)
                    {
                        i = 0;
                    }

                    if (!Pool[i].activeSelf)
                    {
                        lastIndexUsed = i;
                        return Pool[i];
                    }


                } while (i != lastIndexUsed);

                lastIndexUsed = poolCount;
            }

            return Expand();
        }
    }
}