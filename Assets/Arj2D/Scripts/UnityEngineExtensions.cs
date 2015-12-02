using UnityEngine;

namespace Arj2D
{
    public static class UnityEngineExtensions
    {
        #region TRASNFORM
        public static void SetPositionX(this Transform _transform, float _newX)
        {
            _transform.position = new Vector3(_newX, _transform.position.y, _transform.position.z);
        }
        public static void SetPositionY(this Transform _transform, float _newY)
        {
            _transform.position = new Vector3(_transform.position.x, _newY, _transform.position.z);
        }
        public static void SetPositionZ(this Transform _transform, float _newZ)
        {
            _transform.position= new Vector3(_transform.position.x, _transform.position.y, _newZ);
        }
        public static void SetPosition(this Transform _transform, float _posX, float _posY, float _posZ=0.0f)
        {
            _transform.position= new Vector3(_posX, _posY, _posZ);
        }
        public static float GetPositionX(this Transform _transform)
        {
            return _transform.position.x;
        }
        public static float GetPositionY(this Transform _transform)
        {
            return _transform.position.y;
        }
        public static float GetPositionZ(this Transform _transform)
        {
            return _transform.position.z;
        }
        public static void ShiftPositionX(this Transform _transform, float _offsetX)
        {
            _transform.position = new Vector3(_transform.position.x + _offsetX, _transform.position.y, _transform.position.z);
        }
        public static void ShiftPositionY(this Transform _transform, float _offsetY)
        {
            _transform.position= new Vector3(0f, _transform.position.y + _offsetY, 0f);
        }
        public static void ShiftPositionZ(this Transform _transform, float _offsetZ)
        {
            _transform.position= new Vector3(0f, 0f, _transform.position.z + _offsetZ);
        }
        public static void Move(this Transform _transform, Vector2 _offset)
        {
            _transform.position= new Vector3(_transform.position.x + _offset.x, _transform.position.y + _offset.y, _transform.position.z);
        }
        public static void Move(this Transform _transform, Vector3 _offset)
        {
            _transform.position= new Vector3(_transform.position.x + _offset.x, _transform.position.y + _offset.y, _transform.position.z + _offset.z);
        }
        public static void Move(this Transform _transform, float _offsetX, float _offsetY)
        {
            _transform.position= new Vector3(_transform.position.x + _offsetX, _transform.position.y + _offsetY, _transform.position.z);
        }
        public static void Move(this Transform _transform, float _offsetX, float _offsetY, float _offsetZ)
        {
            _transform.position= new Vector3(_transform.position.x + _offsetX, _transform.position.y + _offsetY, _transform.position.z + _offsetZ);
        }
        /// <summary>
        /// Flip a transform, use for Flip Sprite
        /// </summary>
        public static void Flip(this Transform _transform)
        {
            _transform.localScale = new Vector3(_transform.localScale.x * -1f, _transform.localScale.y, _transform.localScale.z);
        }
        /// <summary>
        /// Flip a transform, use for Flip Sprite
        /// </summary>
        public static void Flip(this Transform _transform, bool _facingRight)
        {
            Vector3 theScale = _transform.localScale;
            if (_facingRight)
                theScale.x = Mathf.Abs(theScale.x);
            else
                theScale.x = -Mathf.Abs(theScale.x);
            _transform.localScale = theScale;
        }
        /// <summary>
        /// Reset only position and rotation. Scale is not affected
        /// </summary>
        public static void ResetTransform(this Transform _transform)
        {
            _transform.position = Vector3.zero;
            _transform.rotation = Quaternion.identity;
        }
        /// <summary>
        /// Reset position, rotation and scale.
        /// </summary>
        public static void ResetTransformAll(this Transform _transform)
        {
            _transform.position = Vector3.zero;
            _transform.rotation = Quaternion.identity;
            _transform.localScale = Vector3.zero;
        }
        #endregion

        #region GAMEOBJECT
        public static int GetCollisionMask(this GameObject _gameObject, int _layer = -1)
        {
            if (_layer == -1)
                _layer = _gameObject.layer;

            int mask = 0;
            for (int i = 0; i < 32; i++)
                mask |= (Physics2D.GetIgnoreLayerCollision(_layer, i) ? 0 : 1) << i;

            return mask;
        }
        public static bool IsInLayerMask(this GameObject _gameObject, LayerMask _layerMask)
        {
            int objLayerMask = (1 << _gameObject.layer);
            return (_layerMask.value & objLayerMask) > 0;
        }
        public static T[] GetComponentsOnlyInChildren<T>(this GameObject _gameObject, bool _includeInactive= true) where T : Component
        {
            T[] tmp = _gameObject.GetComponentsInChildren<T>(_includeInactive);
            if(tmp[0].gameObject.GetInstanceID() == _gameObject.GetInstanceID())
            {
                System.Collections.Generic.List<T> list= new System.Collections.Generic.List<T>(tmp);
                list.RemoveAt(0);
                return list.ToArray();
            }
            return tmp;
        }
        /// <summary>
        /// Try to get a component, if the gameobject dont have that component, add it
        /// </summary>
        /// <typeparam name="T">Component</typeparam>
        /// <param name="_gameObject">Self GameObject</param>
        /// <param name="_component">Component</param>
        /// <returns>the component or new component</returns>
        public static T GetOrAddComponent<T>(this GameObject _gameObject) where T : Component
        {
            T component = _gameObject.GetComponent<T>();
            if (component == null)
            {
                component = _gameObject.AddComponent<T>();
            }
            return component;
        }

        /// <summary>
        /// Find the first GameObject with a name,, starting in a father and search in each children of children until first GameObject with the name
        /// </summary>
        /// <param name="_gameObject">GameObject where start</param>
        /// <param name="name">Name of GameObject to find</param>
        /// <returns>GameObject with the name, searching</returns>
        public static GameObject FindGameObjectByNameRecursive(this GameObject _gameObject, string name)
        {
            if (_gameObject.name == name)
            {
                return _gameObject;
            }
            //first find it in children
            Transform found = _gameObject.transform.Find(name);
            if (found != null)
            {
                return found.gameObject;
            }

            //if not, find it inside each child
            int children = _gameObject.transform.childCount;
            for (int i = 0; i < children; ++i)
            {
                GameObject go = FindGameObjectByNameRecursive(_gameObject.transform.GetChild(i).gameObject, name);
                if (go != null)
                {
                    return go;
                }
            }

            return null;
        }


        #endregion

        #region TEXTURE2D
        public static Texture2D FlipHorizontally(this Texture2D _texture)
        {
            Color[] image = _texture.GetPixels();
            Color[] newImage = new Color[image.Length];

            int width = _texture.width;
            int height = _texture.height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    newImage[y * width + (x - width - 1)] = image[y * width + x];
                }
            }

            Texture2D result = new Texture2D(width, height);
            result.SetPixels(newImage);
            result.Apply();
            return result;
        }

        public static Texture2D FlipVertically(this Texture2D _texture)
        {
            Color[] image = _texture.GetPixels();
            Color[] newImage = new Color[image.Length];

            int width = _texture.width;
            int height = _texture.height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    newImage[(height - y - 1) * width + x] = image[y * width + x];
                }
            }

            Texture2D result = new Texture2D(width, height);
            result.SetPixels(newImage);
            result.Apply();
            return result;
        }
        #endregion

        #region VECTOR2
        public static Vector3 ToVector3(this Vector2 _vector2)
        {
            return new Vector3(_vector2.x, _vector2.y);
        }
        #endregion

        #region VECTOR3
        public static Vector2 ToVector2(this Vector3 _vector3)
        {
            return new Vector2(_vector3.x, _vector3.y);
        }
        #endregion

        #region RENDERER
        public static bool IsVisibleInCamera(this Renderer _renderer, Camera camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, _renderer.bounds);
        }
        #endregion

        #region SPRITERENDER
        public static bool IsVisibleInCamera(this SpriteRenderer _spriteRenderer, Camera _camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
            return GeometryUtility.TestPlanesAABB(planes, _spriteRenderer.bounds);
        }
        #endregion
    }
}