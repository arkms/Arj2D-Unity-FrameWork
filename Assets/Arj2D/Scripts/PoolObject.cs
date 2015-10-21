using UnityEngine;
using System.Collections.Generic;

namespace Arj2D
{
    public class PoolObject
    {
        public List<GameObject> Pool;
        private bool CanExpandSize;
        private GameObject Prefab;

        /// <summary>
        /// Create a pool of one GameObject, indepent of PoolManager
        /// </summary>
        /// <param name="_prefab">Prefab</param>
        /// <param name="_StartSize">Size to start</param>
        /// <param name="_CanExpandSize">Can create new instances of gameobject, if all are in use? </param>
        public void Init(GameObject _prefab, int _StartSize, bool _CanExpandSize= true)
        {
            if (Pool == null)
            {
                Prefab = _prefab;
                CanExpandSize = _CanExpandSize;
                Pool = new List<GameObject>();
                for (int i = 0; i < _StartSize; i++)
                {
                    Pool.Add(GameObject.Instantiate(_prefab) as GameObject);
                    Pool[i].SetActive(false);
                }
            }
        }

        /// <summary>
        /// Instantiate a GameObject
        /// </summary>
        /// <param name="_position">New position of GameObject</param>
        /// <returns>The Instantiate of GameObject</returns>
        public GameObject Spawn(Vector3 _position)
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                if (!Pool[i].activeSelf)
                {
                    Pool[i].SetActive(true);
                    Pool[i].transform.position = _position;
                    return Pool[i];
                }
            }

            if (CanExpandSize)
            {
                GameObject go = GameObject.Instantiate(Prefab) as GameObject;
                go.transform.position = _position;
                Pool.Add(go);
                return go;
            }

            return null;//is not anyone free
        }

        /// <summary>
        /// Instantiate a GameObject
        /// </summary>
        /// <param name="_position">New position of GameObject</param>
        /// <param name="_rotation">New rotation of GameObject</param>
        /// <returns>The Instantiate of GameObject</returns>
        public GameObject Spawn(Vector3 _position, Quaternion _rotation)
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                if (!Pool[i].activeSelf)
                {
                    Pool[i].SetActive(true);
                    Pool[i].transform.position = _position;
                    Pool[i].transform.rotation = _rotation;
                    return Pool[i];
                }
            }

            if (CanExpandSize)
            {
                GameObject go = GameObject.Instantiate(Prefab) as GameObject;
                go.transform.position = _position;
                go.transform.rotation = _rotation;
                Pool.Add(go);
                return go;
            }

            return null;//is not anyone free
        }

        /// <summary>
        /// Set if can expand or not if all gameobject in pools are in use
        /// </summary>
        /// <param name="_CanExpand">True or false</param>
        public void Set_Expand(bool _CanExpand)
        {
            CanExpandSize = _CanExpand;
        }
    }
}