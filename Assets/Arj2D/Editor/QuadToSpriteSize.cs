using UnityEngine;
using UnityEditor;

public class QuadToSpriteSize
{
    [MenuItem("Arj2D/Resize/QuadResize2Texture")]
    static void QuadResize()
    {
        GameObject go = Selection.activeGameObject;
        if (go)
        {
            Texture text = go.renderer.sharedMaterial.mainTexture;
            if (text)
            {
                go.transform.localScale = new Vector3(text.width/100f, text.height/100f, 1f);
            }
            else
                Debug.Log("No Texture");
        }
        else
            Debug.Log("No GameObject Selected");
    }

    [MenuItem("Arj2D/Resize/Quad2Screen_Orto")]
    static void QuadFixToScreen()
    {
        GameObject go = Selection.activeGameObject;
        if (go)
        {
            float height = 2.0f * Camera.main.orthographicSize;
            float width = height * Screen.width / Screen.height;
            go.transform.localScale = new Vector3(width, height, 1);
        }
    }

    [MenuItem("Arj2D/Resize/Quad2Screen_Perspective")]
    static void QuadFixToScreen2()
    {
        GameObject go = Selection.activeGameObject;
        if (go)
        {
            float height = 2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * Vector3.Distance(Camera.main.transform.position, go.transform.position);
            float width = height * Screen.width / Screen.height;
            go.transform.localScale = new Vector3(width, height, 1);
        }
    }

    [MenuItem("Arj2D/Resize/Sprite2Screen_Orto")]
    static void SpriteFixToScreen()
    {
        GameObject go = Selection.activeGameObject;
        if (go)
        {
            SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
            float width = sr.sprite.bounds.size.x;
            float height = sr.sprite.bounds.size.y;
            Camera cam = Camera.main;
            float worldScreenHeight = cam.orthographicSize * 2.0f;
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            go.transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1f);
            go.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, go.transform.position.z);
        }
    }
}
