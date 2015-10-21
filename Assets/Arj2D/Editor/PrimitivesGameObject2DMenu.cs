using UnityEngine;
using UnityEditor;

namespace Arj2D
{
    public class PrimitivesGameObject2DMenu
    {

        [MenuItem("GameObject/2D Object/Cube", false, 21)]
        public static void Cube()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Cube).transform.position= GetViewCenter();
        }

        [MenuItem("GameObject/2D Object/Sphere", false, 22)]
        public static void Sphere()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Sphere).transform.position = GetViewCenter();
        }

        [MenuItem("GameObject/2D Object/Capsule", false, 23)]
        public static void Capsule()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Capsule).transform.position = GetViewCenter();
        }

        [MenuItem("GameObject/2D Object/Cylinder", false, 24)]
        public static void Cylinder()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Cylinder).transform.position = GetViewCenter();
        }

        [MenuItem("GameObject/2D Object/Quad", false, 25)]
        public static void Quad()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Quad).transform.position = GetViewCenter();
        }

        static Vector3 GetViewCenter()
        {
            Vector3 tmp = SceneView.lastActiveSceneView.camera.transform.position;
            tmp.z = 0.0f;
            return tmp;
        }
    }
}