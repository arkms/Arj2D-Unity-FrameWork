Arj2D-FrameWork
===============

Note:
My english is not perfect,i try to do my best, please help me to improve the documentation!

Information:
-----
Unity 2D FrameWork Version 0.9.0.3

A free Unity 2D FrameWork that extends and brings more utilities for working in a 2D enviroment for Unity.
Suggestions and any questions are welcome, leave it issues.

**Features:**
---------
* Editor:
  - Arj2Debug.cs: Gives the real position on the editor, rotation of GameObject when is not the father or center of GameObject.
  - Atlas2Prefab.cs: A Texture2D set in MultipleSprite, converts all Sprites to prefabs.
  - ChangeSpriteMaterial.cs: Change all materials in all SpriteRenders in GameObjects and children.
  - DisableAutoMipMaps.cs: Sets default to false in mipmap in all new sprites/texures.
  - Force2DSound.cs: Force all new sounds in project to be 2D.
  - QuadToSpriteSize: Can resize a selected GameObject (Sprite or Quad) to fill the whole screen of the main camera in ortographic or perspective mode.
  - SpriteOrder.cs: EditorWindow that helps manage all SpriteOrder (sortingLayerID and sortingOrder) of every SpriteRender on Scene.
  - SpriteShadow.cs: EditorWindow that shows all Sprites on Scene and can enable or disable cast and receive shadows (Need spriteShadow Shader).
  - TiledMapping.cs: A a simple tile editor inside Unity to create maps in 2D. An update to select a prefab folder coming.
  
* Physics Material:
  - Plataform.
  - PlataformEnd.
  - Player.
  
* Scripts:
  - Amath.cs: Math functions to work in 2D, like converting Vector3 to Vector2, get directions, distances, flipping a sprite, etc.
  - Arj2drandom.cs: Gets Random color, positions or probability like a coin among other things.
  - BlowFish.cs (includes PlayerPrefsX): Save and load with Encryption.
  - MersenneTwister.cs: An Algoritm for better randomness, can be used on procedural content.
  - MonoBehaviour2D.cs: MonoBehaviour optimized for 2D in Unity, with this you don't need cache Components.
  - UnityEngineExtension.cs: Adds Functions to Transform, GameObject, Texture2D, Vector3, Render and SpriteRender.
  - Singleton(Folder)
    - AudioManager.cs: An Audio manager that you call without reference. Example of use AudioManager.Init() and later AudioManager.Play(audioclip),that's all.
    - PoolManager.cs: Pool manager that you only need to initialize one time on the first scene, call AddToPool and finally only can Spawn or Despawn, neither need reference for use.
    - TimeOwn.cs: A timer that works independently from Time.time, includes its own TimeOwn.delta, Intitialize it only when you need it.

* Shaders:
  - SpriteShader: Shader for quads and planes show a texture like Sprites
  
* Utility (Scripts that you just need to add to a GameObject):
  - Effects:
    - Sprite_ColorPulse.cs: Make a Sprite change between two colors, like blinking.
    - Trans_TweenMove.cs: Make a GameObject move from A to B in a loop.
  - CameraResize.cs: Preserves the aspect ratio of your game.
  - DebugCollider2D.cs: Script that shows all triggers and colliders of a gameobject for fast debugging.
  - DontGoThroughThings.cs: A Script that helps the rigidbody stops going through other colliders (BETA).
  - PointForceComponent.cs: A simulator of an object with atraction force.
  - TextureTillingController.cs: A script that makes a Quad or a Plane have tiling and can be updated when scaling it.
  - TrailRenderWith2DCollider: Self Explanatory. You just need to add this script to a GameObject.
  - WindComponent.cs: Creates a Wind zone for Physics2D.
  
  
This project is released under the Simplified BSD License. Copyright 2012 Samsung R&D Institute Russia.
