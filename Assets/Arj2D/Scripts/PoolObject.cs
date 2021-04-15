using UnityEngine;
using System.Collections.Generic;

namespace Arj2D
{
    public class PoolObject
    {
        private GameObject Prefab;
        private List<GameObject> Pool;
        private Transform transform_; //father transform

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

        private GameObject Expand()
        {
            GameObject go = GameObject.Instantiate(Prefab) as GameObject;
            Pool.Add(go);
            go.transform.parent = transform_;
            go.SetActive(false);
            go.name = Prefab.name + "_" + Pool.Count;
            return go;
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
            for (int i = 0; i < Pool.Count; i++)
            {
                if (!Pool[i].activeSelf)
                {
                    Pool[i].transform.localPosition = _pos;
                    Pool[i].transform.localRotation = _rotation;
                    Pool[i].SetActive(true);
                    return Pool[i];
                }
            }

            //Not anyone free,, lets create more
            GameObject go = Expand();
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
            for (int i = 0; i < Pool.Count; i++)
            {
                if (!Pool[i].activeSelf)
                {
                    Pool[i].transform.localPosition = _pos;
                    Pool[i].SetActive(true);
                    return Pool[i];
                }
            }

            //Not anyone free,, lets create more
            GameObject go = Expand();
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
            for (int i = 0; i < Pool.Count; i++)
            {
                if (!Pool[i].activeSelf)
                {
                    Pool[i].transform.localPosition = _pos;
                    Pool[i].SetActive(true);
                    return Pool[i];
                }
            }

            //Not anyone free,, lets create more
            GameObject go = Expand();
            go.transform.localPosition = _pos;
            go.SetActive(true);
            return go;
        }

        public GameObject Spawn(bool _autoActive = true)
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                if (!Pool[i].activeSelf)
                {
                    if (_autoActive)
                        Pool[i].SetActive(true);
                    return Pool[i];
                }
            }

            //Not anyone free,, lets create more
            GameObject go = Expand();
            if (_autoActive)
                go.SetActive(true);
            return go;
        }

        /// <summary>
        /// Disable all Gameobject in the Pool
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                Pool[i].SetActive(false);
            }
        }

        /// <summary>
        /// Clear and destroy in the Pool
        /// </summary>
        public void ClearAndDestroy(bool _releasePrefab = false)
        {
            if (_releasePrefab)
            {
                Prefab = null;
                GameObject.Destroy(transform_.gameObject);
            }
            else
            {
                for (int i = 0; i < Pool.Count; i++)
                {
                    GameObject.Destroy(Pool[i]);
                    Pool[i] = null;
                }
            }
            Pool.Clear();
        }
    }
}