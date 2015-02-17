using UnityEngine;
using System.Collections;

public class Use_PoolManager : MonoBehaviour
{
    public GameObject go_object;
    private int go_objectID;

    private float Time_ToGenerate;

	void Start ()
	{
        PoolManager.Init();
        go_objectID= PoolManager.AddToPool(go_object, 5);

        Time_ToGenerate = Time.time;
	}

	void Update ()
	{
        if (Time_ToGenerate <= Time.time)
        {
            Time_ToGenerate = Time.time + Random.Range(0.5f, 1f);

            float posX = Random.Range(-9f, 9f);
            PoolManager.Spawn(go_objectID, new Vector2(posX, 5f));
        }
	}
}