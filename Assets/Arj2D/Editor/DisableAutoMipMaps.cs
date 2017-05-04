using UnityEditor;

public class DisableAutoMipMaps : AssetPostprocessor
{
    public void OnPreprocessTexture()
    {
        TextureImporter texture = assetImporter as TextureImporter;
        texture.mipmapEnabled = false;
    }
}