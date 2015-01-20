using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    public GameObject Pref;

	void Start ()
	{
        PoolManager.Init();
        PoolManager.AddToPool(Pref, 5);
        GameObject go= PoolManager.Spawn(0, Vector2.zero);
        PoolManager.Despawn(go);
	}

	void Update ()
	{
	}
}