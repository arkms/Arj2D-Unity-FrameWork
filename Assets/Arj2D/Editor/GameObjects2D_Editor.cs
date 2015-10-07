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

        [MenuItem("Arj2D/Debug/Add Capsule Collider 2D")]
        public static void AddCapsuleCollider2D()
        {
            if (Selection.activeGameObject != null)
            {
                GameObject go = Selection.activeGameObject;
                CircleCollider2D colCircle = go.AddComponent<CircleCollider2D>();
                colCircle.offset = new Vector2(0f, -0.5f);
                colCircle.radius = 0.5f;
                colCircle = go.AddComponent<CircleCollider2D>();
                colCircle.offset = new Vector2(0f, 0.5f);
                colCircle.radius = 0.5f;
                BoxCollider2D colBox = go.AddComponent<BoxCollider2D>();
                colBox.size = new Vector2(1f, 1f);
            }            
        }
    }
}