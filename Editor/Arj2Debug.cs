using UnityEngine;
using UnityEditor;

namespace Arj2D
{
    public static class Arj2Debug
    {
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
        [MenuItem("Arj2D/Debug/Select Player and Focus #&p")]
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

        // Set a Image pivot same as the sprite a version
        [MenuItem("Arj2D/UI/ImageSetSpritePivot")]
        public static void ImageSetSpritePivot()
        {
            if (Selection.activeGameObject)
            {
                GameObject go = Selection.activeGameObject;
                UnityEngine.UI.Image img = go.GetComponent<UnityEngine.UI.Image>();
                if (img)
                {
                    Undo.RecordObject(img.rectTransform, "Image pivot");
                    Vector2 size = img.rectTransform.sizeDelta;
                    size *= img.pixelsPerUnit;
                    Vector2 pixelPivot = img.sprite.pivot;
                    Vector2 percentPivot = new Vector2(pixelPivot.x / size.x, pixelPivot.y / size.y);
                    img.rectTransform.pivot = percentPivot;
                }
                else
                {
                    Debug.LogWarning("You need select a Image");
                }
            }
            else
            {
                Debug.LogWarning("You need select a Image");
            }

        }
    }
}
