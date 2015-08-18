using UnityEditor;
using UnityEngine;

namespace Arj2D
{
    public class Force2DSound : AssetPostprocessor
    {
#if !UNITY_5
        public void OnPreprocessAudio()
        {
            AudioImporter ai = assetImporter as AudioImporter;
            ai.threeD = false;
        }
#endif
    }
}