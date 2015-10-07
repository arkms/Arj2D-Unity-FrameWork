using UnityEngine;

namespace Arj2D
{
    public static class PrimitivesGameObjects2D
    {
        public enum PrimitiveType2D : byte { Cube, Sphere, Capsule, Cylinder, Quad};

        public static GameObject CreatePrimitive2D(PrimitiveType2D _type)
        {
            GameObject go= null;
            Renderer render;
            switch(_type)
            {
                case PrimitiveType2D.Cube:
                    go= GameObject.CreatePrimitive(PrimitiveType.Cube);
                    GameObject.DestroyImmediate(go.GetComponent<BoxCollider>());
                    go.AddComponent<BoxCollider2D>();
                    break;
                case PrimitiveType2D.Sphere:
                    go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    GameObject.DestroyImmediate(go.GetComponent<SphereCollider>());
                    go.AddComponent<CircleCollider2D>();
                    break;
                case PrimitiveType2D.Capsule:
                    go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    GameObject.DestroyImmediate(go.GetComponent<CapsuleCollider>());
                    CircleCollider2D colCircle= go.AddComponent<CircleCollider2D>();
                    colCircle.offset = new Vector2(0f, -0.5f);
                    colCircle.radius = 0.5f;
                    colCircle= go.AddComponent<CircleCollider2D>();
                    colCircle.offset = new Vector2(0f, 0.5f);
                    colCircle.radius = 0.5f;
                    BoxCollider2D colBox = go.AddComponent<BoxCollider2D>();
                    colBox.size = new Vector2(1f, 1f);
                    break;
                case PrimitiveType2D.Cylinder:
                    go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GameObject.DestroyImmediate(go.GetComponent<CapsuleCollider>());
                    go.AddComponent<BoxCollider2D>();
                    break;
                case PrimitiveType2D.Quad:
                    go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    GameObject.DestroyImmediate(go.GetComponent<MeshCollider>());
                    go.AddComponent<BoxCollider2D>();
                    break;
            }


            render = go.GetComponent<Renderer>();
            render.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            render.receiveShadows = false;
            return go;
        }
    }
}