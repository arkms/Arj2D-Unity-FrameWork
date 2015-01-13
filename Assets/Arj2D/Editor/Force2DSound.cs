using UnityEditor;
using UnityEngine;

namespace Arj2D
{
    public class Force2DSound : AssetPostprocessor
    {
        public void OnPreprocessAudio()
        {
            AudioImporter ai = assetImporter as AudioImporter;
            ai.threeD = false;
        }
    }
}