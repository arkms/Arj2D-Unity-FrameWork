using UnityEngine;
using System.Collections;

public class scr_backgroundTexture : MonoBehaviour
{
    public Color Back_Color;

	void Start ()
	{
        //Same of Arj2D/Resize/Quad2Screen_Orto
        float height = 2.0f * Camera.main.orthographicSize;
        float width = height * Screen.width / Screen.height;
        transform.localScale = new Vector3(width, height, 1);
        //end

        Texture2D background_texture = Arj2D.AMath.MakeTextureOneColor((int)height, (int)width, Back_Color);
        GetComponent<Renderer>().material.mainTexture = background_texture;
	}
}