using UnityEngine;
using UnityEditor;

namespace Arj2D
{
    public class Arj2Debug
    {
        //Remove all shadow in MeshRenderes selected
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
                        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                        //Change to this line for UNITY 4.x
                        //mr.shadowCastingMode = false;
                        mr.receiveShadows = false;
                    }
                }
                Debug.Log("Done removing shadows");
            }
        }

        //Get center position of all childrens
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

        [MenuItem("Arj2D/Debug/DeleteAllSaveData")]
        public static void DeleteAllSaveData()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Save data borrado");
        }

        [MenuItem("Arj2D/Debug/CountTotalGameObjects")]
        public static void CountTotalGameObject()
        {
            int length = GameObject.FindObjectsOfType<Transform>().Length;
            Debug.Log("Hay " + length + " en escena");
        }

        //Select and focus in select scene
        [MenuItem("Arj2D/Debug/Select Player and Focus #_p")]
        public static void SelectPlayerandFocus()
        {
            if (Selection.activeGameObject == null)
            {
                GameObject go = GameObject.FindGameObjectWithTag("Player");
                if (go != null)
                {
                    Selection.activeGameObject = go;
                    SceneView.lastActiveSceneView.FrameSelected();
                }
                else
                {
                    Debug.LogWarning("There is not any GameObject with 'Player' TAG");
                }
            }
        }
    }
}
