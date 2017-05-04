using UnityEngine;
using UnityEditor;

namespace Arj2D
{
    public class GameObjects2D_Editor
    {
        [MenuItem("GameObject/2D Object/Camera2D", false, 101)]
        public static void Camera2D()
        {
            GameObject Gocam = new GameObject("Camera2D");
            Gocam.transform.position = new Vector3(0f, 0f, -10f);
            Gocam.tag = "MainCamera";
            Camera cam = Gocam.AddComponent<Camera>();
            cam.orthographic = true;
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.farClipPlane = 50;
        }
    }
}