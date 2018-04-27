using UnityEditor;

//Taked from: https://github.com/baba-s/unity-shortcut-key-plus/blob/master/Assets/UnityShortcutKeyPlus/Editor/RunUnity.cs
namespace Arj2D
{
    public class ShortCutKeys
    {
        private const string ITEM_NAME_RUN = "Edit/Plus/Run _F5";
        private const string ITEM_NAME_PAUSE = "Edit/Plus/Run _F6";
        private const string ITEM_NAME_STOP = "Edit/Plus/Stop #_F5";

        [MenuItem(ITEM_NAME_RUN)]
        private static void Run()
        {
            EditorApplication.isPlaying = true;
        }

        [MenuItem(ITEM_NAME_RUN, true)]
        private static bool CanRun()
        {
            return !EditorApplication.isPlaying;
        }

        [MenuItem(ITEM_NAME_PAUSE)]
        private static void Pause()
        {
            EditorApplication.isPaused = !EditorApplication.isPaused;
        }

        [MenuItem(ITEM_NAME_STOP)]
        private static void Stop()
        {
            EditorApplication.isPlaying = false;
        }

        [MenuItem(ITEM_NAME_STOP, true)]
        private static bool CanStop()
        {
            return EditorApplication.isPlaying;
        }
    }

}
