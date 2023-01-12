using UnityEngine;
using System.Collections.Generic;

namespace Arj2D
{
    public class PoolManager : MonoBehaviour
{
    static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = new PoolManager();
            }

            return instance;
        }
    }

    Dictionary<GameObject, PoolObject> pools = new Dictionary<GameObject, PoolObject>();

    /// <summary>
    /// Add Prefab to PoolManager,, ONLY call one to for each prefab, or use AddToPool_Secure
    /// </summary>
    /// <param name="_prefab">Prefab</param>
    /// <param name="_size">Inicial number of prefab</param>
    /// <returns>Return ID in poolManager,, Recommend cache it</returns>
    public void AddToPool(GameObject _prefab, int _size = 3)
    {
        if (pools.ContainsKey(_prefab)) return;
        
        PoolObject newPool = new PoolObject();
        newPool.Init(_prefab, _size);
        pools.Add(_prefab, newPool);
    }

    /// <summary>
    /// Remove Prefab of PoolManager
    /// </summary>
    /// <param name="_prefab">Prefab for remove</param>
    public void RemoveFromPool(GameObject _prefab)
    {
        if (!pools.ContainsKey(_prefab)) return;

        PoolObject po = pools[_prefab];
        
        po.ClearAndDestroy();
        pools.Remove(_prefab);
    }

    /// <summary>
    /// Is initialize the prefab in pool
    /// </summary>
    /// <returns>true or false if poolmanager initialize</returns>
    public bool IsInit(GameObject _prefab)
    {
        return pools.ContainsKey(_prefab);
    }

    // --------------------------------------------
    /// <summary>
    /// Spawn new object
    /// </summary>
    /// <param name="_prefab">Id of Prefab in PoolManager</param>
    /// <param name="_pos">Position</param>
    /// <param name="_rotation">Rotation</param>
    /// <param name="_autoTurnOn">Call SetActive(_autoTurnOn)</param>
    /// <returns>GameObject create</returns>
    public GameObject Spawn(GameObject _prefab, Vector3 _pos, Quaternion _rotation, bool _autoTurnOn= true)
    {
        return pools[_prefab].Spawn(_pos, _rotation, _autoTurnOn);
    }

    /// <summary>
    /// Spawn new object using Vector2
    /// </summary>
    /// <param name="_prefab">Id of Prefab in PoolManager</param>
    /// <param name="_pos">Position</param>
    /// /// <param name="_autoTurnOn">Call SetActive(_autoTurnOn)</param>
    /// <returns>GameObject create</returns>
    public GameObject Spawn(GameObject _prefab, Vector2 _pos, bool _autoTurnOn= true)
    {
        return pools[_prefab].Spawn(_pos, _autoTurnOn);
    }

    /// <summary>
    /// Disable all Gameobject only of specific Prefab
    /// </summary>
    /// <param name="_prefab">ID of Prefab in PoolManager</param>
    public void Clear(GameObject _prefab)
    {
        if (!pools.ContainsKey(_prefab)) return;
        
        pools[_prefab].Clear();
    }

    /// <summary>
    /// Clear and destroy in poolmanager all GameObject of one Prefab
    /// </summary>
    /// <param name="_prefab">ID of Prefab in PoolManager</param>
    public void ClearAndDestroy(GameObject _prefab)
    {
        if (!pools.ContainsKey(_prefab)) return;
        
        pools[_prefab].ClearAndDestroy();
    }

    /// <summary>
    /// Disable all GameObject in PoolManger
    /// </summary>
    public void ClearAll()
    {
        foreach (var po in pools)
        {
            po.Value.Clear();
        }
    }

    /// <summary>
    /// Disable  all GameObject in PoolManger and realease prefab reference
    /// </summary>
    public void ClearAndDestroyAll()
    {
        foreach (var po in pools)
        {
            po.Value.ClearAndDestroy();
        }
    }
}
}
