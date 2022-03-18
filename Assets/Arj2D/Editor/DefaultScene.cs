using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Arj2D
{
    public class DefaultScene : EditorWindow
    {
        void OnGUI()
        {
            EditorSceneManager.playModeStartScene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("Start Scene"), EditorSceneManager.playModeStartScene, typeof(SceneAsset), false);
        }

        [MenuItem("Arj2D/Default Scene")]
        static void Open()
        {
            GetWindow<DefaultScene>();
        }
    }
    /* Uncomment if you want autoassing always the same scene. How ever, you will not able to test your current level
    [InitializeOnLoad]
    public class Startup
    {
        static Startup()
        {
            SceneAsset myWantedStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/Scenes/First.unity");
            if (myWantedStartScene != null)
                EditorSceneManager.playModeStartScene = myWantedStartScene;
            else
                Debug.Log("First scene doesn't exist");
        }
    }*/
}
