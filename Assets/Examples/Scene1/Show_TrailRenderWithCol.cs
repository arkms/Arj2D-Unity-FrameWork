using UnityEngine;
using System.Collections;
using Arj2D;

public class Show_TrailRenderWithCol : MonoBehaviour2D
{
    int dir = 1;

	void Update ()
	{
        transform.X(dir * 5f * Time.deltaTime);
        if (dir > 0 && transform.GetX() >= 5)
        {
            dir = -1;
        }
        else if (dir < 0 && transform.GetX() <= -5)
        {
            dir = 1;
        }
	}
}