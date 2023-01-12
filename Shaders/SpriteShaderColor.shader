Shader "Arj2D/SpriteShaderColor"
{
	// Custom sprite shader - no lighting, on/off alpha
	Properties
	{
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
	}

	SubShader
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	//    LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha 
		Lighting Off

		Pass
		{
			//CGPROGRAM
			SetTexture [_MainTex] { combine texture }

			SetTexture [_MainTex]
			{
				ConstantColor [_Color]
				Combine texture * constant
			}
		}
	}
}
