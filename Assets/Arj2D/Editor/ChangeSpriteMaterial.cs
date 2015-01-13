using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Arj2D
{
    public class ChangeSpriteMaterial : EditorWindow
    {
        Material new_mat;
        GameObject go;

        [MenuItem("Arj2D/SpriteUtil/ChangeSpriteMAterial")]
        public static void Init()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(ChangeSpriteMaterial), true, "ChageSpriteMaterial");
            window.maxSize = new Vector2(215f, 90f);
            window.minSize = window.maxSize;
        }

        /*void OnEnable()
        {
        }*/

        void OnGUI()
        {
            GUILayout.Label("Change Render in one GameObject and childrens with one new Material");
            new_mat = (Material)EditorGUILayout.ObjectField(new_mat, typeof(Material), false);
            go = (GameObject)EditorGUILayout.ObjectField(go, typeof(GameObject), true);
            if (GUILayout.Button("ChangeSprite"))
            {
                if (new_mat == null || go == null)
                {
                    Debug.LogError("Assign new material and/or GameObject");
                }
                Undo.RegisterCreatedObjectUndo(go, "CambioMaterial");
                SpriteRenderer[] srs = go.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sr in srs)
                {
                    sr.material = new_mat;
                }
            }
        }
    }
}