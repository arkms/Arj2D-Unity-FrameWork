using UnityEngine;
//using System;
using System.Collections.Generic;
using Arj2D;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance = null;
    public static PoolManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static List<GameObject> Prefabs;
    private static List<List<GameObject>> Pool;
    private static Transform transform_; //father transform

    /// <summary>
    /// Add Prefab to PoolManager, in secure mode, that if the prefab already is in poolmanager, dont create other one
    /// </summary>
    /// <param name="_prefab">Prefab</param>
    /// <param name="_size">Inicial number of prefab</param>
    /// <returns>Return ID in poolManager,, Recommend cache it</returns>
    public static int AddToPool_Secure(GameObject _prefab, int _size = 3)
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
    public static int AddToPool(GameObject _prefab, int _size = 3)
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
    public static void RemoveFromPool(GameObject _prefab)
    {
        int index = Prefabs.IndexOf(_prefab);
        if (index != -1)
        {
            Prefabs[index] = null;
            for (int i = 0; i < Pool[index].Count; i++)
            {
                Destroy(Pool[index][i]);
            }
            Pool[index] = null;
        }
    }

    /// <summary>
    /// Initialize PoolManager,, dont worry it cant be initialize more of one time
    /// </summary>
    public static void Init()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("PoolManager");
            DontDestroyOnLoad(go);
            instance = go.AddComponent<PoolManager>();
            transform_ = go.GetComponent<Transform>();
            Pool = new List<List<GameObject>>();
            Prefabs = new List<GameObject>();
        }
    }

    /// <summary>
    /// Is initialize the poolmanager?
    /// </summary>
    /// <returns>true or false if poolmanager initialize</returns>
    public static bool IsInit()
    {
        return (instance != null) ? true : false;
    }

    private static GameObject Expand(int _id)
    {
        GameObject go = GameObject.Instantiate(Prefabs[_id]) as GameObject; ;
        Pool[_id].Add(go);
        go.transform.parent = transform_;
        go.SetActive(false);
        go.name = Prefabs[_id].name + "_" + Pool[_id].Count;
        //go.SendMessage("SetIDinPool", _id, SendMessageOptions.DontRequireReceiver);
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
    public static GameObject Spawn(int _id, Vector3 _pos, Quaternion _rotation)
    {
        for (int i = 0; i < Pool[_id].Count; i++)
        {
            if (!Pool[_id][i].activeSelf)
            {
                Pool[_id][i].SetActive(true);
                Pool[_id][i].transform.position = _pos;
                Pool[_id][i].transform.rotation = _rotation;
                return Pool[_id][i];
            }
        }

        //Not anyone free,, lets create more
        GameObject go = Expand(_id);
        go.transform.position = _pos;
        go.transform.rotation = _rotation;
        return go;
    }

    /// <summary>
    /// Spawn new object, using vector2
    /// </summary>
    /// <param name="_id">Id of Prefab in PoolManager</param>
    /// <param name="_pos">Position</param>
    /// <param name="_rotation">Rotation</param>
    /// <returns>GameObject create</returns>
    public static GameObject Spawn(int _id, Vector2 _pos)
    {
        for (int i = 0; i < Pool[_id].Count; i++)
        {
            if (!Pool[_id][i].activeSelf)
            {
                Pool[_id][i].SetActive(true);
                Pool[_id][i].transform.position = _pos;
                return Pool[_id][i];
            }
        }

        //Not anyone free,, lets create more
        GameObject go = Expand(_id);
        go.transform.position = _pos;
        return go;
    }

    /// <summary>
    /// Get ID of Prefab of GameObject in Prefab,, caution use Prefabs with exactly same name
    /// </summary>
    /// <param name="_go">GameObject to try get prefab</param>
    /// <returns>ID of Prefab or -1 if cant find it. Its better cached it</returns>
    public static int GetPoolManagerID(GameObject _go)
    {
        string name = _go.name.Remove(_go.name.IndexOf('_'));
        for (int i = 0; i < Prefabs.Count; i++)
        {
            if (Prefabs[i].name == name)
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
    public static void Clear(int _id)
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
    public static void Clear(GameObject _prefab)
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
    public static void ClearAndDestroy(int _id)
    {
        for (int i = 0; i < Pool[_id].Count; i++)
        {
            Destroy(Pool[_id][i]);
            Pool[_id][i] = null;
        }
    }

    /// <summary>
    /// Prefab to clear ande destryoy
    /// </summary>
    /// <param name="_prefab"></param>
    public static void ClearAndDestroy(GameObject _prefab)
    {
        int index = GetPoolManagerIDByPreafab(_prefab);
        for (int i = 0; i < Pool[index].Count; i++)
        {
            Destroy(Pool[index][i]);
            Pool[index][i] = null;
        }
    }

    /// <summary>
    /// Disable all GameObject in PoolManger
    /// </summary>
    public static void ClearAll()
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
    public static void DestroyAll()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            for (int j = 0; j < Pool[i].Count; j++)
            {
                Destroy(Pool[i][j]);
                Pool[i][j] = null;
            }
        }
    }

    /// <summary>
    /// Get ID of Prefab In PoolManager
    /// </summary>
    /// <param name="_prefab">Prefab to find</param>
    /// <returns>ID of Prefab or -1 if cant find it. Its better cached it</returns>
    public static int GetPoolManagerIDByPreafab(GameObject _prefab)
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
    public static bool IsPrefabInPool(GameObject _prefab)
    {
        return Prefabs.Contains(_prefab);
    }
}
