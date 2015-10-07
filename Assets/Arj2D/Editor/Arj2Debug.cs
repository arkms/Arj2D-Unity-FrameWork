using UnityEngine;
using UnityEditor;

namespace Arj2D
{
    public class Arj2Debug
    {

        [MenuItem("Arj2D/Debug/World Position")]
        public static void PrintGlobalPosition()
        {
            if (Selection.activeGameObject != null)
            {
                Debug.Log(Selection.activeGameObject.name + " is at " + Selection.activeGameObject.transform.position);
            }
        }

        [MenuItem("Arj2D/Debug/World Rotation")]
        public static void PrintGlobalRotation()
        {
            if (Selection.activeGameObject != null)
            {
                Debug.Log(Selection.activeGameObject.name + " is at " + Selection.activeGameObject.transform.eulerAngles);
            }
        }

        [MenuItem("Arj2D/Debug/Remove Shadows")]
        public static void RemoveShadows()
        {
            if (Selection.activeGameObject != null)
            {
                GameObject[] gos = Selection.gameObjects;
                foreach (GameObject go in gos)
                {
                    MeshRenderer mr = go.GetComponent<MeshRenderer>();
                    if (mr != null)
                    {
#if UNITY_5_1 || UNITY_5_2
                        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
#else
                        mr.shadowCastingMode = false;
#endif
                        mr.receiveShadows = false;
                    }
                }
                Debug.Log("Done removing shadows");
            }
        }

        [MenuItem("Arj2D/Debug/Center")]
        public static void Center()
        {
            if (Selection.activeGameObject != null)
            {
                Transform[] tras = Selection.activeGameObject.GetComponentsInChildren<Transform>();
                Vector3 Center = Vector3.zero;
                if (tras.Length != 0)
                {
                    foreach (Transform t in tras)
                    {
                        Center += t.position;
                    }
                    Debug.Log(Center / tras.Length);
                }
                else
                    Debug.Log("ZERO");
            }
        }
    }
}
