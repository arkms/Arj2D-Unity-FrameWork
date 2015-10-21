using UnityEngine;
using System.Collections;
using Arj2D;

public class autodestroy : MonoBehaviour2D
{
    [System.NonSerialized]
    public int IDinPool;

    void Start()
    {
        IDinPool = PoolManager.GetPoolManagerID(gameObject);
    }

    void Update()
    {
        if (!spriteRender.IsVisibleInCamera(Camera.main))
        {
            gameObject.SetActive(false);
        }
    }
}