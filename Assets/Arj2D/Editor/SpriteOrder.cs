using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEditorInternal;
using System.Reflection;

public class SpriteOrder : EditorWindow
{
    List<Renderer> re = new List<Renderer>();
    List<Texture2D> Preview = new List<Texture2D>();
    Vector2 scrollbar;


    [MenuItem("Arj2D/SpriteOrder")]
    public static void Init()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(SpriteOrder), false, "SpriteOrder");
        window.minSize = new Vector2(380f, 300f);
        window.autoRepaintOnSceneChange = true;
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
            GUILayout.Label(re[i].gameObject.name, GUILayout.MaxWidth(35f));
            GUILayout.Label(Preview[i], GUILayout.MaxWidth(35f), GUILayout.MaxHeight(35f));
            GUILayout.Label("Layer ID: ", GUILayout.MaxWidth(58f));
            re[i].sortingLayerID = EditorGUILayout.Popup(re[i].sortingLayerID, GetSortingLayerNames(), GUILayout.MaxWidth(100f));
            GUILayout.Label("Sorting order: ", GUILayout.MaxWidth(85f));
            re[i].sortingOrder = EditorGUILayout.IntField(re[i].sortingOrder, GUILayout.MaxWidth(40f), GUILayout.MinWidth(40f));
            EditorGUILayout.EndHorizontal();
            AssetDatabase.Refresh();
        }
        EditorGUILayout.EndScrollView();
    }

    // Get the sorting layer names
    public string[] GetSortingLayerNames()
    {
        Type internalEditorUtilityType = typeof(InternalEditorUtility);
        PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
        return (string[])sortingLayersProperty.GetValue(null, new object[0]);
    }

    // Get the unique sorting layer IDs -- tossed this in for good measure
    public int[] GetSortingLayerUniqueIDs()
    {
        Type internalEditorUtilityType = typeof(InternalEditorUtility);
        PropertyInfo sortingLayerUniqueIDsProperty = internalEditorUtilityType.GetProperty("sortingLayerUniqueIDs", BindingFlags.Static | BindingFlags.NonPublic);
        return (int[])sortingLayerUniqueIDsProperty.GetValue(null, new object[0]);
    }
}
