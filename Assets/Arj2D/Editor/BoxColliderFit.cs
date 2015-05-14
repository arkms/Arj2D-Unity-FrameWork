using UnityEditor;
using UnityEngine;

namespace Arj2D
{
    public class BoxColliderFit
    {
        [MenuItem("Arj2D/BoxColliderFit to Children")]
        public static void BoxCollider_Fit()
        {
            GameObject go = Selection.activeGameObject;
            if (!(go.GetComponent<Collider2D>() is BoxCollider2D))
            {
                Debug.LogWarning("Add a BoxColldier2D first");
                return;
            }

            bool FirstBound = false;
            Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

            for (int i = 0; i < go.transform.childCount; ++i)
            {
                Renderer childRenderer = go.transform.GetChild(i).GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    if (FirstBound)
                    {
                        bounds.Encapsulate(childRenderer.bounds);
                    }
                    else
                    {
                        bounds = childRenderer.bounds;
                        FirstBound = true;
                    }
                }
            }

            BoxCollider2D collider = (BoxCollider2D)go.GetComponent<Collider2D>();
#if UNITY_5_0
            collider.offset = bounds.center - go.transform.position;
#else
            collider.center = bounds.center - go.transform.position;
#endif
            collider.size = bounds.size;
        }
    }
}