using UnityEngine;
using System.Collections;

public class TimeOwn : MonoBehaviour
{
    private static float lastInterval;
    private static float Delta;
    public static float delta
    {
        get
        {
            return Delta;
        }
    }

    private static bool IsInit = false;

    /// <summary>
    /// Call only if you want a own time manager in world for deltaTime
    /// </summary>
    public static void Init()
    {
        if (!IsInit)
        {
            GameObject go = new GameObject("TimeOwn");
            go.isStatic = true;
            DontDestroyOnLoad(go);
            lastInterval = Time.realtimeSinceStartup;
            IsInit = true;
        }
    }

	void Update ()
	{
        float timeNow = Time.realtimeSinceStartup;
        Delta = timeNow - lastInterval;
        lastInterval = timeNow;
	}

    public void Destroy()
    {
        Destroy(gameObject);
        IsInit = false;
    }
}