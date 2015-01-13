using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Arj2D
{
    public class SpriteShadows : EditorWindow
    {
        List<Renderer> re = new List<Renderer>();
        List<Texture2D> Preview = new List<Texture2D>();
        Vector2 scrollbar;

        [MenuItem("Arj2D/SpriteUtil/SpriteShadows")]
        public static void Init()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(SpriteShadows), false, "SpriteShadows");
            window.minSize = new Vector2(200f, 300f);
        }

        void OnEnable()
        {
            if (re.Count == 0)
            {
                SpriteRenderer[] srs = (SpriteRenderer[])FindObjectsOfType(typeof(SpriteRenderer));
                foreach (SpriteRenderer sr in srs)
                {
                    Renderer tmpRe = sr.GetComponent<Renderer>();
                    re.Add(tmpRe);
                    Preview.Add(AssetPreview.GetAssetPreview(sr.sprite));
                }
            }
        }

        void OnGUI()
        {
            scrollbar = EditorGUILayout.BeginScrollView(scrollbar);
            for (int i = 0; i < re.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(re[i].gameObject.name, GUILayout.MinWidth(80f), GUILayout.MaxWidth(80f));
                GUILayout.Label(Preview[i], GUILayout.MaxWidth(35f), GUILayout.MaxHeight(35f));
                GUILayout.Space(20f);
                re[i].castShadows = GUILayout.Toggle(re[i].castShadows, "Cast", GUILayout.MaxWidth(50f));
                re[i].receiveShadows = GUILayout.Toggle(re[i].receiveShadows, "receive", GUILayout.MaxWidth(60f));
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();
        }
    }
}
