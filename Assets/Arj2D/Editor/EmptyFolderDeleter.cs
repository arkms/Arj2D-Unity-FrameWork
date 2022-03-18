using System.IO;
using UnityEditor;

namespace Arj2D
{
    public static class EmptyFolderDeleter
    {
        [MenuItem("Arj2D/Tools/Delete Empty Folder")]
        private static void Delete()
        {
            DoDelete("Assets");
            UnityEngine.Debug.Log("Empty folders finish");
            AssetDatabase.Refresh();
        }

        private static void DoDelete(string path)
        {
            foreach (var dir in Directory.GetDirectories(path))
            {
                DoDelete(dir);

                var files = Directory.GetFiles(dir);

                if (files.Length != 0) continue;

                var dirs = Directory.GetDirectories(dir);

                if (dirs.Length != 0) continue;

                AssetDatabase.DeleteAsset(dir);
            }
        }
    }
}

