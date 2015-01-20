using UnityEngine;
//using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraResize : MonoBehaviour
{
    public float DesignAspectWidth= 16f;
    public float DesignAspectHeight= 9f;

    [Tooltip("If it is true, force full screen with aspect ratio, if it is false, it going to use as much of the screen unscaled")]
    public bool ForceAspect = true;

    void Awake()
    {
        UpdateAspect();
    }

    /// <summary>
    /// Call if you change DesignAspectWidth, DesignAspectHeight or/and ForceAspect
    /// </summary>
    public void UpdateAspect()
    {
        if (ForceAspect)
        {
            this.camera.aspect = DesignAspectWidth / DesignAspectHeight;
        }
        else
        {
            Resize();
        }
    }

    private void Resize()
    {
        //Aspect ratio
        float targetaspect = DesignAspectWidth / DesignAspectHeight;

        //check actual aspectratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        //check actual vs wish aspect
        float scaleheight = windowaspect / targetaspect;

        if (scaleheight < 1.0f) //portrait
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
        
            camera.rect = rect;
        }
        else //lanscape
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        //Create background in black
        CreateBackGround();
    }

    private void CreateBackGround()
    {
        Camera cam = new GameObject().AddComponent<Camera>();
        cam.gameObject.isStatic = true;
        cam.depth = -10;
        cam.cullingMask = 0;
        cam.farClipPlane = 1f;
        cam.orthographic = true;
        cam.backgroundColor = Color.black;
        cam.gameObject.name = "BackGround_Camera";
    }
}