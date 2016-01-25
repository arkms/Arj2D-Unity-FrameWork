using UnityEngine;
using System.Collections.Generic;

namespace Arj2D
{
    public class PoolObject
    {
        private List<GameObject> Prefabs;
        private List<List<GameObject>> Pool;
        private Transform transform_; //father transform

        /// <summary>
        /// Add Prefab to PoolManager, in secure mode, that if the prefab already is in poolmanager, dont create other one
        /// </summary>
        /// <param name="_prefab">Prefab</param>
        /// <param name="_size">Inicial number of prefab</param>
        /// <returns>Return ID in poolManager,, Recommend cache it</returns>
        public int AddToPool_Secure(GameObject _prefab, int _size = 3)
        {
            if (IsPrefabInPool(_prefab))
            {
                Prefabs.Add(_prefab);
                List<GameObject> pooladd = new List<GameObject>();
                Pool.Add(pooladd);
                int ID = Prefabs.Count - 1;

                for (int i = 0; i < _size; i++)
                {
                    Expand(ID);
                }
                return ID;
            }
            return GetPoolManagerIDByPreafab(_prefab);
        }

        /// <summary>
        /// Add Prefab to PoolManager,, ONLY call one to for each prefab, or use AddToPool_Secure
        /// </summary>
        /// <param name="_prefab">Prefab</param>
        /// <param name="_size">Inicial number of prefab</param>
        /// <returns>Return ID in poolManager,, Recommend cache it</returns>
        public int AddToPool(GameObject _prefab, int _size = 3)
        {
            Prefabs.Add(_prefab);
            List<GameObject> pooladd = new List<GameObject>();
            Pool.Add(pooladd);
            int ID = Prefabs.Count - 1;

            for (int i = 0; i < _size; i++)
            {
                Expand(ID);
            }
            return ID;
        }

        /// <summary>
        /// Remove Prefab of PoolManager
        /// </summary>
        /// <param name="_prefab">Prefab for remove</param>
        public void RemoveFromPool(GameObject _prefab)
        {
            int index = Prefabs.IndexOf(_prefab);
            if (index != -1)
            {
                Prefabs[index] = null;
                for (int i = 0; i < Pool[index].Count; i++)
                {
                    GameObject.Destroy(Pool[index][i]);
                }
                Pool.RemoveAt(index);
            }
        }

        /// <summary>
        /// Initialize PoolManager,, dont worry it cant be initialize more of one time
        /// </summary>
        public void Init(string _name)
        {
            if (transform_ == null)
            {
                GameObject go = new GameObject(_name + "_Pool");
                transform_ = go.GetComponent<Transform>();
                Pool = new List<List<GameObject>>();
                Prefabs = new List<GameObject>();
            }
        }

        /// <summary>
        /// Is initialize the poolmanager?
        /// </summary>
        /// <returns>true or false if poolmanager initialize</returns>
        public bool IsInit()
        {
            return (transform_ != null) ? true : false;
        }

        private GameObject Expand(int _id)
        {
            GameObject go = GameObject.Instantiate(Prefabs[_id]) as GameObject;
            Pool[_id].Add(go);
            go.transform.parent = transform_;
            go.SetActive(false);
            go.name = Prefabs[_id].name + "_" + Pool[_id].Count;
            return go;
        }

        // --------------------------------------------
        /// <summary>
        /// Spawn new object
        /// </summary>
        /// <param name="_id">Id of Prefab in PoolManager</param>
        /// <param name="_pos">Position</param>
        /// <param name="_rotation">Rotation</param>
        /// <returns>GameObject create</returns>
        public GameObject Spawn(int _id, Vector3 _pos, Quaternion _rotation)
        {
            for (int i = 0; i < Pool[_id].Count; i++)
            {
                if (!Pool[_id][i].activeSelf)
                {
                    Pool[_id][i].SetActive(true);
                    Pool[_id][i].transform.localPosition = _pos;
                    Pool[_id][i].transform.localRotation = _rotation;
                    return Pool[_id][i];
                }
            }

            //Not anyone free,, lets create more
            GameObject go = Expand(_id);
            go.transform.localPosition = _pos;
            go.transform.localRotation = _rotation;
            return go;
        }

        /// <summary>
        /// Spawn new object, using vector2
        /// </summary>
        /// <param name="_id">Id of Prefab in PoolManager</param>
        /// <param name="_pos">Position</param>
        /// <param name="_rotation">Rotation</param>
        /// <returns>GameObject create</returns>
        public GameObject Spawn(int _id, Vector2 _pos)
        {
            for (int i = 0; i < Pool[_id].Count; i++)
            {
                if (!Pool[_id][i].activeSelf)
                {
                    Pool[_id][i].SetActive(true);
                    Pool[_id][i].transform.localPosition = _pos;
                    return Pool[_id][i];
                }
            }

            //Not anyone free,, lets create more
            GameObject go = Expand(_id);
            go.transform.localPosition = _pos;
            return go;
        }

        public GameObject Spawn(int _id)
        {
            for (int i = 0; i < Pool[_id].Count; i++)
            {
                if (!Pool[_id][i].activeSelf)
                {
                    Pool[_id][i].SetActive(true);
                    return Pool[_id][i];
                }
            }

            //Not anyone free,, lets create more
            GameObject go = Expand(_id);
            return go;
        }

        /// <summary>
        /// Get ID of Prefab of GameObject in Prefab,, caution use Prefabs with exactly same name
        /// </summary>
        /// <param name="_go">GameObject to try get prefab</param>
        /// <returns>ID of Prefab or -1 if cant find it. Its better cached it</returns>
        public int GetPoolManagerID(GameObject _go)
        {
            for (int i = 0; i < Prefabs.Count; i++)
            {
                if (Prefabs[i] == _go)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Disable all Gameobject only of specific Prefab
        /// </summary>
        /// <param name="_id">ID of Prefab in PoolManager</param>
        public void Clear(int _id)
        {
            for (int i = 0; i < Pool[_id].Count; i++)
            {
                Pool[_id][i].SetActive(false);
            }
        }

        /// <summary>
        /// Disable all Gameobject only of specific Prefab,, is better use Clear(int _id)
        /// </summary>
        /// <param name="_prefab">Prefab to clear</param>
        public void Clear(GameObject _prefab)
        {
            int index = GetPoolManagerIDByPreafab(_prefab);
            for (int i = 0; i < Pool[index].Count; i++)
            {
                Pool[index][i].SetActive(false);
            }
        }

        /// <summary>
        /// Clear and destroy in poolmanager all GameObject of one Prefab
        /// </summary>
        /// <param name="_id">ID of Prefab in PoolManager</param>
        public void ClearAndDestroy(int _id)
        {
            for (int i = 0; i < Pool[_id].Count; i++)
            {
                GameObject.Destroy(Pool[_id][i]);
                Pool[_id][i] = null;
            }
        }

        /// <summary>
        /// Prefab to clear ande destryoy
        /// </summary>
        /// <param name="_prefab"></param>
        public void ClearAndDestroy(GameObject _prefab)
        {
            int index = GetPoolManagerIDByPreafab(_prefab);
            for (int i = 0; i < Pool[index].Count; i++)
            {
                GameObject.Destroy(Pool[index][i]);
                Pool[index][i] = null;
            }
        }

        /// <summary>
        /// Disable all GameObject in PoolManger
        /// </summary>
        public void ClearAll()
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                for (int j = 0; j < Pool[i].Count; j++)
                {
                    Pool[i][j].SetActive(false);
                }
            }
        }

        /// <summary>
        /// Disable  all GameObject in PoolManger and realease prefab reference
        /// </summary>
        public void DestroyAll()
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                for (int j = 0; j < Pool[i].Count; j++)
                {
                    GameObject.Destroy(Pool[i][j]);
                    Pool[i][j] = null;
                }
            }
        }

        /// <summary>
        /// Destroy all gameobject and release prefab reference
        /// </summary>
        /// <param name="_id"></param>
        public void ReleaseAt(int _id)
        {
            for (int i = 0; i < Pool[_id].Count; i++)
            {
                GameObject.Destroy(Pool[_id][i]);
                Pool[_id][i] = null;
            }
            Pool[_id].Clear();
            Prefabs.RemoveAt(_id);
        }

        /// <summary>
        /// Destroy all Pool and realese prefabs
        /// </summary>
        public void ReleaseAll()
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                for (int j = 0; j < Pool[i].Count; j++)
                {
                    GameObject.Destroy(Pool[i][j]);
                    Pool[i][j] = null;
                }
                Pool[i].Clear();
                Prefabs.RemoveAt(i);
            }
        }

        /// <summary>
        /// Get ID of Prefab In PoolManager
        /// </summary>
        /// <param name="_prefab">Prefab to find</param>
        /// <returns>ID of Prefab or -1 if cant find it. Its better cached it</returns>
        public int GetPoolManagerIDByPreafab(GameObject _prefab)
        {
            for (int i = 0; i < Prefabs.Count; i++)
            {
                if (Prefabs[i] == _prefab)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Find if a Prefab is in Prefab list
        /// </summary>
        /// <param name="_prefab">Prefab to check</param>
        /// <returns>true if is in or false its not</returns>
        public bool IsPrefabInPool(GameObject _prefab)
        {
            return Prefabs.Contains(_prefab);
        }
    }
}