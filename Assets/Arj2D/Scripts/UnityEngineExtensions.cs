using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arj2D
{
    public static class UnityEngineExtensions
    {
        #region TRASNFORM
        public static void PosX(this Transform _transform, float _newX)
        {
            _transform.position = new Vector3(_newX, _transform.position.y, _transform.position.z);
        }
        public static void PosY(this Transform _transform, float _newY)
        {
            _transform.position = new Vector3(_transform.position.x, _newY, _transform.position.z);
        }
        public static void PosZ(this Transform _transform, float _newZ)
        {
            _transform.position = new Vector3(_transform.position.x, _transform.position.y, _newZ);
        }
        public static void SetPos(this Transform _transform, float _posX, float _posY, float _posZ = 0.0f)
        {
            _transform.position = new Vector3(_posX, _posY, _posZ);
        }
        public static void SetPosXY(this Transform _transform, float _posX, float _posY)
        {
            _transform.position = new Vector3(_posX, _posY, _transform.position.z);
        }
        public static float GetX(this Transform _transform)
        {
            return _transform.position.x;
        }
        public static float GetY(this Transform _transform)
        {
            return _transform.position.y;
        }
        public static float GetZ(this Transform _transform)
        {
            return _transform.position.z;
        }
        public static void ShiftX(this Transform _transform, float _offsetX)
        {
            _transform.position = new Vector3(_transform.position.x + _offsetX, _transform.position.y, _transform.position.z);
        }
        public static void ShiftY(this Transform _transform, float _offsetY)
        {
            _transform.position = new Vector3(_transform.position.x, _transform.position.y + _offsetY, _transform.position.z);
        }
        public static void ShiftZ(this Transform _transform, float _offsetZ)
        {
            _transform.position = new Vector3(_transform.position.x, _transform.position.y, _transform.position.z + _offsetZ);
        }
        public static void Move(this Transform _transform, Vector2 _offset)
        {
            _transform.position = new Vector3(_transform.position.x + _offset.x, _transform.position.y + _offset.y, _transform.position.z);
        }
        public static void Move(this Transform _transform, Vector3 _offset)
        {
            _transform.position = _transform.position + _offset;
        }
        public static void Move(this Transform _transform, float _offsetX, float _offsetY)
        {
            _transform.position = new Vector3(_transform.position.x + _offsetX, _transform.position.y + _offsetY, _transform.position.z);
        }
        public static void Move(this Transform _transform, float _offsetX, float _offsetY, float _offsetZ)
        {
            _transform.position = new Vector3(_transform.position.x + _offsetX, _transform.position.y + _offsetY, _transform.position.z + _offsetZ);
        }
        public static void SetPosLocalX(this Transform _transform, float _newX)
        {
            Vector3 localPos = _transform.localPosition;
            localPos.x = _newX;
            _transform.localPosition = localPos;
        }
        public static void SetPosLocalY(this Transform _transform, float _newY)
        {
            Vector3 localPos = _transform.localPosition;
            localPos.y = _newY;
            _transform.localPosition = localPos;
        }
        public static void SetPosLocalZ(this Transform _transform, float _newZ)
        {
            Vector3 localPos = _transform.localPosition;
            localPos.z = _newZ;
            _transform.localPosition = localPos;
        }
        public static void SetLocalPos(this Transform _transform, float _posX, float _posY, float _posZ = 0.0f)
        {
            _transform.localPosition = new Vector3(_posX, _posY, _posZ);
        }
        public static void SetLocalPosXY(this Transform _transform, float _posX, float _posY)
        {
            _transform.localPosition = new Vector3(_posX, _posY, _transform.localPosition.z);
        }
        public static float GetLocalX(this Transform _transform)
        {
            return _transform.localPosition.x;
        }
        public static float GetLocalY(this Transform _transform)
        {
            return _transform.localPosition.y;
        }
        public static float GetLocalZ(this Transform _transform)
        {
            return _transform.localPosition.z;
        }
        public static void MoveLocal(this Transform _transform, Vector2 _offset)
        {
            _transform.localPosition = new Vector3(_transform.localPosition.x + _offset.x, _transform.localPosition.y + _offset.y, _transform.localPosition.z);
        }
        public static void MoveLocal(this Transform _transform, Vector3 _offset)
        {
            _transform.localPosition = _transform.localPosition + _offset;
        }
        public static void MoveLocal(this Transform _transform, float _offsetX, float _offsetY)
        {
            _transform.localPosition = new Vector3(_transform.localPosition.x + _offsetX, _transform.localPosition.y + _offsetY, _transform.localPosition.z);
        }
        public static void MoveLocal(this Transform _transform, float _offsetX, float _offsetY, float _offsetZ)
        {
            _transform.localPosition = new Vector3(_transform.localPosition.x + _offsetX, _transform.localPosition.y + _offsetY, _transform.localPosition.z + _offsetZ);
        }
        /// <summary>
        /// Flip a transform in X, flip from current scale
        /// </summary>
        public static void FlipX(this Transform _transform)
        {
            _transform.localScale = new Vector3(_transform.localScale.x * -1f, _transform.localScale.y, _transform.localScale.z);
        }
        /// <summary>
        /// Flip a transform in Y
        /// </summary>
        public static void FlipY(this Transform _transform, bool _facingRight)
        {
            Vector3 theScale = _transform.localScale;
            if (_facingRight)
                theScale.y = Mathf.Abs(theScale.y);
            else
                theScale.y = -Mathf.Abs(theScale.y);
            _transform.localScale = theScale;
        }
        /// <summary>
        /// Flip a transform in Y, flip from current scale
        /// </summary>
        public static void FlipY(this Transform _transform)
        {
            _transform.localScale = new Vector3(_transform.localScale.x, _transform.localScale.y * -1f, _transform.localScale.z);
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
            _transform.localScale = Vector3.one;
        }
        public static void LookAt2D(this Transform _transform, Transform _target, float _offset = 0f)
        {
            Vector3 relative = _transform.InverseTransformPoint(_target.position);
            float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg - _offset;
            _transform.Rotate(0, 0, -angle, Space.Self);
        }
        public static void LookAt2D(this Transform _transform, Vector3 _pos, float _offset)
        {
            Vector3 relative = _transform.InverseTransformPoint(_pos);
            float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg - _offset;
            _transform.Rotate(0, 0, -angle, Space.Self);
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
        public static T[] GetComponentsOnlyInChildren<T>(this GameObject _gameObject, bool _includeInactive = true) where T : Component
        {
            T[] tmp = _gameObject.GetComponentsInChildren<T>(_includeInactive);
            if (tmp[0].gameObject.GetInstanceID() == _gameObject.GetInstanceID())
            {
                System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>(tmp);
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
        /// Find the first GameObject with a name,, starting in a father and search in each children of children until first GameObject with the name. Include disable gameobjects
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

        /// <summary>
        /// Return the full path in the Hierachy of the GameObject.
        /// </summary>
        /// <param name="_gameObject">GameObject to find Hierachy</param>
        /// <returns>String of path of GameObject,, example "Father/OneGameObject/GameObject"</returns>
        public static string GetFullPath(this GameObject _gameObject)
        {
            System.Collections.Generic.List<string> path = new System.Collections.Generic.List<string>();

            Transform current = _gameObject.transform;
            path.Add(current.name);

            while (current.parent != null)
            {
                path.Insert(0, current.parent.name);
                current = current.parent;
            }

            return string.Join("/", path.ToArray());
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
        public static Vector3 ToVector3(this Vector2 _vector2, float _z = 0f)
        {
            return new Vector3(_vector2.x, _vector2.y, _z);
        }
        public static Vector2 RotateRad(this Vector2 _vector2, float _rad)
        {
            float c = Mathf.Cos(_rad);
            float s = Mathf.Sin(_rad);
            return new Vector2(_vector2.x * c - _vector2.y * s, _vector2.y = _vector2.x * s + _vector2.y * c);
        }
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            float s = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float c = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = v.x;
            float ty = v.y;
            v.x = (c * tx) - (s * ty);
            v.y = (s * tx) + (c * ty);
            return v;
        }
        /// <summary>
        /// Return Vector2( X value, 0f)
        /// </summary>
        /// <param name="_vector2"></param>
        /// <returns></returns>
        public static Vector2 OnlyX(this Vector2 _vector2)
        {
            return new Vector2(_vector2.x, 0f);
        }
        /// <summary>
        /// Return Vector2( 0f, Y value)
        /// </summary>
        /// <param name="_vector2"></param>
        /// <returns></returns>
        public static Vector2 OnlyY(this Vector2 _vector2)
        {
            return new Vector2(0f, _vector2.y);
        }
        #endregion

        #region VECTOR3
        public static Vector2 ToVector2(this Vector3 _vector3)
        {
            return new Vector2(_vector3.x, _vector3.y);
        }
        /// <summary>
        /// Return new Vector3( X value, 0f, 0f)
        /// </summary>
        /// <param name="_vector3"></param>
        /// <returns></returns>
        public static Vector3 OnlyX(this Vector3 _vector3)
        {
            return new Vector3(_vector3.x, 0f, 0f);
        }
        /// <summary>
        /// Return new Vector3( 0f, y value, 0f)
        /// </summary>
        /// <param name="_vector3"></param>
        /// <returns></returns>
        public static Vector3 OnlyY(this Vector3 _vector3)
        {
            return new Vector3(0f, _vector3.y, 0f);
        }
        /// <summary>
        /// Return new Vector3( 0f, 0f, z value)
        /// </summary>
        /// <param name="_vector3"></param>
        /// <returns></returns>
        public static Vector3 OnlyZ(this Vector3 _vector3)
        {
            return new Vector3(0f, 0f, _vector3.z);
        }
        #endregion

        #region COLOR
        /// <summary>
        /// Returns inverted color with the same alpha
        /// </summary>
        public static Color Inverted(this Color _color)
        {
            Color result = Color.white - _color;
            result.a = _color.a;
            return result;
        }

        /// <summary>
        /// Returns new color with modified red channel
        /// </summary>
        public static Color SetR(this Color _color, float _r)
        {
            return new Color(_r, _color.g, _color.b, _color.a);
        }

        /// <summary>
        /// Returns new color with modified green channel
        /// </summary>
        public static Color SetG(this Color _color, float _g)
        {
            return new Color(_color.r, _g, _color.b, _color.a);
        }

        /// <summary>
        /// Returns new color with modified blue channel
        /// </summary>
        public static Color SetB(this Color _color, float _b)
        {
            return new Color(_color.r, _color.g, _b, _color.a);
        }

        /// <summary>
        /// Returns new color with modified alpha channel
        /// </summary>
        public static Color SetA(this Color _color, float _a)
        {
            return new Color(_color.r, _color.g, _color.b, _a);
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

        #region CANVAS
        //SET IT TO anchoredPosition 
        public static Vector2 WorldToCanvasPosition(this Canvas canvas, Vector3 _worldPosition, Camera _camera = null)
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }
            Vector3 viewport_position = _camera.WorldToViewportPoint(_worldPosition);
            RectTransform canvas_rect = canvas.GetComponent<RectTransform>();
            return new Vector2((viewport_position.x * canvas_rect.sizeDelta.x) - (canvas_rect.sizeDelta.x * 0.5f), (viewport_position.y * canvas_rect.sizeDelta.y) - (canvas_rect.sizeDelta.y * 0.5f));
        }
        #endregion

        #region RectTrasnform
        public static Vector3 ToWolrdPosition(this RectTransform _recTransform)
        {
            return _recTransform.TransformPoint(_recTransform.rect.center);
        }
        #endregion

        #region ARRAYS
        /// <summary>
        /// Check if array is null or empty
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="_array">Array to test</param>
        /// <returns>if is null or empty return true, otherwise return false</returns>
        public static bool IsNullOrEmpty<T>(this T[] _array)
        {
            if (_array == null)
                return true;

            if (_array.Length == 0)
                return true;

            return false;
        }
        #endregion

        #region LIST_DICTIONARY

        public static bool IsEmpty<T>(this IEnumerable<T> collection)
            => !collection.Any();

        public static IEnumerable<T> Subsequence<T>(this IEnumerable<T> collection, int startIndex, int length)
        {
            return collection.Skip(startIndex).Take(length);
        }

        /// <summary>
        /// Removes all entries from a dictionary with the specified value.
        /// </summary>
        public static void RemoveAllEntriesWithValue<T1, T2>(this IDictionary<T1, T2> dictionary, T2 value)
        {
            foreach (var matchingEntry in dictionary.Where(kvp => kvp.Value.Equals(value)).ToArray())
                dictionary.Remove(matchingEntry.Key);
        }

        public static T[] Duplicate<T>(this T[] sourceArray)
        {
            if (sourceArray == null)
                return null;


            var duplicateArray = new T[sourceArray.Length];
            Array.Copy(sourceArray, duplicateArray, sourceArray.Length);

            return duplicateArray;
        }

        public static T[] Duplicate<T>(this IReadOnlyList<T> sourceList)
        {
            if (sourceList == null)
                return null;


            var duplicateArray = new T[sourceList.Count];
            for (int i = 0; i < sourceList.Count; i++)
                duplicateArray[i] = sourceList[i];

            return duplicateArray;
        }
        #endregion
    }
}