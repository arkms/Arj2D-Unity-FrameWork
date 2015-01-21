Arj2D-FrameWork
===============

Note:
My english is not perfect,i try to do my best, please help me to improve the documentation!

Information:
-----
Unity 2D FrameWork Version 0.8

A free Unity 2D FrameWork that extend and bring more utilities for work in 2D in Unity.
Suggestions and any questions are welcome, leave it issues.

**Features:**
---------
*Editor:
  -Arj2Debug.cs: Can give in editor real position, rotation of GameObject when is not the father or center of GameObject.
  -Atlas2Prefab.cs: A Texture2D set in MultipleSprite, convert all Sprite in prefabs.
  -ChangeSpriteMaterial.cs: Change all material in all SpriteRender in GameObject and childrens.
  -Force2DSound.cs: Force all new sound in project be in 2D.
  -QuadToSpriteSize: Can rezise a select GameObject (Sprite or Quad) to fill all screen of the main camera in orto or perspective mode.
  -SpriteOrder.cs: EditorWindow that help to manager all SpriteOrder (sortingLayerID and sortingOrder) of all SpriteRender in Scene.
  -SpriteShadow.cs: EditorWindow that show all Sprite in Scene and can enable or disable cast and recive shadow (Need spriteShadow Shader).
  
*Physics Material:
  -Plataform.
  -PlataformEnd.
  -Player.
  
-Scripts:
  -Amath.cs: Functions for work in 2D, like convert Vector3 to Vector2, get directions, distances, flip one sprite, etc.
  -Arj2drandom.cs: Get Random color, positions or probability like a coin and other things.
  -BlowFish.cs (include PlayerPrefsX): Save and load with Encryption. (BETA).
  -MonoBehaviour2D.cs: Monobehaviour optimized for 2D in Unity, with this you don't need cache Componets.
  -UnityEngineExtension.cs: Add Functions to Transform, GameObejct, Texture2D, Vector3, Render and SpriteRender.
  *-Singletons:
    -AudioManager.cs: Audio manager that you call without reference. Example of use AudioManager.Init() and later AudioManager.Play(audioclip),, its all.
    -PoolManager.cs: Pool manager that you only need init one time in the first scene, call AddToPool and finally only can Spawn or Despawn,, neither need reference for use.
    -TimeOwn.cs: A timer that works independet of Time.time,, include his TimeOwn.delta,,, only init when you need it.

*Shaders:
  -Sprite_Shadow: Sprite Shader that can cast and recive Shadows
  -SpriteShader: Shader for quads and planes show a texture like Sprite
  
*Utility (Scripts that you only need to add to a GameObject and done):
  -CameraResize.cs: Preseverse aspect ratio of you game.
  -DontGoThroughThings.cs: A Script that helps rigibody dont through other colliders (BETA).
  -PointForceComponent.cs: A simulator of object with atraction force.
  -TrailRenderWith2DCollider: The name say everthing. You only need add this script to one GameObject.
  -WindComponent.cs: Create a Wind zone for Physics2D.
  
  
This project is released under the Simplified BSD License. Copyright 2012 Samsung R&D Institute Russia.
