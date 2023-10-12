#define AUTOUPDATE //remove if you dont want automatic check any change     <----------------------------------------

using UnityEngine;

 #if AUTOUPDATE
[ExecuteInEditMode]
#endif
public class TextureTilingController : MonoBehaviour
{
    public float textureToMeshY = 2f; // Use this to contrain texture to a certain size

    private Texture texture_;
    private Transform transform_;
    private Renderer renderer_;

    #if AUTOUPDATE
        private float prevTextureToMeshZ = -1f;
        private Vector3 prevScale = Vector3.one;
    
    void Update()
    {
        #if UNITY_EDITOR
        //cache
        if (transform_ == null)
        {
            transform_ = base.transform;
            renderer_ = GetComponent<Renderer>();
            texture_ = renderer_.sharedMaterial.mainTexture;
        }
        #endif

        // If something has changed
        if (transform_.lossyScale != prevScale || !Mathf.Approximately(this.textureToMeshY, prevTextureToMeshZ))
        {
            this.UpdateTiling();
            // Maintain previous state variables
            this.prevScale = transform_.lossyScale;
            this.prevTextureToMeshZ = this.textureToMeshY;
        }
    }
#endif

    void Awake()
    {
        transform_ = base.transform;
        renderer_ = GetComponent<Renderer>();
        texture_ = renderer_.sharedMaterial.mainTexture;

        #if AUTOUPDATE
            this.prevScale = gameObject.transform.lossyScale;
            this.prevTextureToMeshZ = this.textureToMeshY;
        #endif

        this.UpdateTiling();
    }

    [ContextMenu("UpdateTiling")]
    public void UpdateTiling()
    {
        // A Unity plane is 10 units x 10 units
        float planeSizeX = 10f;
        float planeSizeZ = 10f;

        // Figure out texture-to-mesh width based on user set texture-to-mesh height
        float textureToMeshX = ((float)this.texture_.width / this.texture_.height) * this.textureToMeshY;

        renderer_.sharedMaterial.mainTextureScale = new Vector2(planeSizeX * transform_.lossyScale.x / textureToMeshX, planeSizeZ * transform_.lossyScale.y / textureToMeshY);
    }
}