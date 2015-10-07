using UnityEngine;
using UnityEditor;

namespace Arj2D
{
    public class PrimitivesGameObject2DMenu
    {

        [MenuItem("GameObject/2D Object/Cube", false, 21)]
        public static void Cube()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Cube);
        }

        [MenuItem("GameObject/2D Object/Sphere", false, 22)]
        public static void Sphere()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Sphere);
        }

        [MenuItem("GameObject/2D Object/Capsule", false, 23)]
        public static void Capsule()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Capsule);
        }

        [MenuItem("GameObject/2D Object/Cylinder", false, 24)]
        public static void Cylinder()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Cylinder);
        }

        [MenuItem("GameObject/2D Object/Quad", false, 25)]
        public static void Quad()
        {
            PrimitivesGameObjects2D.CreatePrimitive2D(PrimitivesGameObjects2D.PrimitiveType2D.Quad);
        }
    }
}