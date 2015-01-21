using UnityEngine;
using UnityEditor;
using System.IO;

public class Atlas2Prefab : EditorWindow
{
    private Texture2D Atlas;

    [MenuItem("Arj2D/Texture2D/Atlas2Prefab")]
    public static void Init()
    {
        EditorWindow.GetWindow(typeof(Atlas2Prefab), true, "Atlas to Prefab");
    }

    void OnGUI()
    {
        Atlas = (Texture2D)EditorGUILayout.ObjectField("Atlas", Atlas, typeof(Texture2D), false);

        if (Atlas)
        {
            if (GUILayout.Button("Convert"))
            {
                ConvertAtlas2Prefabs();
            }
        }
    }

    void ConvertAtlas2Prefabs()
    {
        //WE TAKE SPRITES
        string path= AssetDatabase.GetAssetPath(Atlas);
        Object[] atlasAssets = AssetDatabase.LoadAllAssetsAtPath(path);
        
        //create folder
        if (Directory.Exists(GetFolder(path) + "/Prefab_" + Atlas.name))
        {
            if (EditorUtility.DisplayDialog("Are you sure?", "All prefabs going to be remplaced, you wanna continue?", "Yes", "No"))
            {
                path = GetFolder(path) + "/Prefab_" + Atlas.name + "/";
            }
            else
                return;
        }
        else
        {
            AssetDatabase.CreateFolder(path, "Prefab_" + Atlas.name);
            path = GetFolder(path) + "/Prefab_" + Atlas.name + "/";
        }

        //create Prefabs}
        float progressActual = 0;
        foreach (Object asset in atlasAssets)
        {
            EditorUtility.DisplayProgressBar("Converting", "Converting Sprites to Prefabs", progressActual / atlasAssets.LongLength);
            if (AssetDatabase.IsSubAsset(asset))
            {
                Object obj = PrefabUtility.CreateEmptyPrefab(path + asset.name + ".prefab");
                GameObject go = new GameObject();
                SpriteRenderer sptmp = go.AddComponent<SpriteRenderer>();
                sptmp.sprite = (Sprite)asset;
                PrefabUtility.ReplacePrefab(go, obj, ReplacePrefabOptions.ConnectToPrefab);
                DestroyImmediate(go);
            }
            progressActual++;
        }
        if (progressActual != 0)
            EditorUtility.ClearProgressBar();

        this.Close();
    }

    string GetFolder(string _path)
    {
        return _path.Remove(_path.LastIndexOf("/"));
    }
}
