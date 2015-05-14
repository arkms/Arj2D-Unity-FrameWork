using UnityEngine;

namespace Arj2D
{
    public static class AMath
    {
        /// <summary>
        /// Calculate the distance between two vector3, ignoring the Z
        /// </summary>
        /// <param name="_vA"></param>
        /// <param name="_vB"></param>
        /// <returns></returns>
        public static float Distance(Vector3 _vA, Vector3 _vB)
        {
            return (DistanceX(_vA, _vB) + DistanceY(_vA, _vB));
        }

        public static float DistanceX(Vector3 _vA, Vector3 _vB)
        {
            return Mathf.Abs(_vA.x - _vB.x);
        }

        public static float DistanceX(Vector2 _vA, Vector2 _vB)
        {
            return Mathf.Abs(_vA.x - _vB.x);
        }

        public static float DistanceX(Vector3 _vA, Vector2 _vB)
        {
            return Mathf.Abs(_vA.x - _vB.x);
        }

        public static float DistanceX(Vector2 _vA, Vector3 _vB)
        {
            return Mathf.Abs(_vA.x - _vB.x);
        }

        public static float DistanceY(Vector3 _vA, Vector3 _vB)
        {
            return Mathf.Abs(_vA.y - _vB.y);
        }

        public static Vector2 AngleToV2(float _angle)
        {
            _angle *= Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle));
        }

        public static Vector2 AngleToV2r(float _angle)
        {
            return new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle));
        }

        public static Vector2 AngleToV2(int _angle)
        {
            float angle = _angle * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }

        public static float V2ToAngle(Vector2 _v2)
        {
            return Mathf.Atan2(_v2.y, _v2.x);
        }

        /// <summary>
        /// Get the direction you need in X from origin to destiny
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_destiny"></param>
        /// <returns></returns>
        public static int DirectionX(Vector3 _origin, Vector3 _destiny)
        {
            if (_origin.x < _destiny.x)
                return 1;
            else if (_origin.x > _destiny.x)
                return -1;
            return 0;
        }

        /// <summary>
        /// Get the direction you need in X from origin to destiny
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_destiny"></param>
        /// <returns></returns>
        public static int DirectionX(float _origin, float _destiny)
        {
            if (_origin < _destiny)
                return 1;
            else if (_origin > _destiny)
                return -1;
            return 0;
        }

        /// <summary>
        /// Get the direction you need in Y from origin to destiny
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_destiny"></param>
        /// <returns></returns>
        public static int DirectionY(Vector3 _origin, Vector3 _destiny)
        {
            if (_origin.y < _destiny.y)
                return 1;
            else if (_origin.y > _destiny.y)
                return -1;
            return 0;
        }

        public static Vector3 Direction(Vector3 _origin, Vector3 _destiny)
        {
            // return new Vector3(DirX(_origin, _destiny), DirY(_origin, _destiny));
            return new Vector3((_destiny.x - _origin.x), (_destiny.y - _origin.y)).normalized;
        }

        public static Vector2 DirectionV2(Vector3 _origin, Vector3 _destiny)
        {
            //return new Vector2(DirX(_origin, _destiny), DirY(_origin, _destiny));
            return new Vector2((_destiny.x - _origin.x), (_destiny.y - _origin.y)).normalized;
        }

        /// <summary>
        /// Add line (Enter) every number of char in one string
        /// </summary>
        /// <param name="_text">String to fix</param>
        /// <param name="_limitRow">Number of char in envery row</param>
        /// <returns>Fixed _text</returns>
        public static string FixText(string _text, int _limitRow)
        {
            string tmp = _text;
            int i = _limitRow - 1;
            while (_text.Length - 1 > i)
            {
                tmp = tmp.Insert(i, System.Environment.NewLine);
                i += _limitRow;
            }
            return tmp;
        }

        /// <summary>
        /// Neutralizes the an angle.
        /// </summary>
        /// <returns>The neutralized angle.</returns>
        /// <param name="angle">The source angle.</param>
        public static float NeutralizeAngle(float _angle)
        {
            if (_angle < 0)
                return (_angle % 360.0f) * -1;
            else
                return _angle % 360.0f;
        }

        /// <summary>
        /// Calculates the CIE76 delta-e value: http://en.wikipedia.org/wiki/Color_difference#CIE76
        /// </summary>
        /// <param name="_colorA">Color A</param>
        /// <param name="_colorB">Color B</param>
        /// <returns>delta compare value</returns>
        public static float ColorCompare(Color _colorA, Color _colorB)
        {
            float differences = Compare_dif(_colorA.r, _colorB.r) + Compare_dif(_colorA.g, _colorB.g) + Compare_dif(_colorA.b, _colorB.b);
            return Mathf.Sqrt(differences);
        }
        private static float Compare_dif(float _a, float _b)
        {
            return (_a - _b) * (_a - _b);
        }

        /// <summary>
        /// Percentage between two colors
        /// </summary>
        /// <param name="_colorA">Color A</param>
        /// <param name="_colorB">Color B</param>
        /// <returns>Percentage (0 - 1)</returns>
        public static float ColorPercentage(Color _colorA, Color _colorB)
        {
            float R = _colorA.r / _colorB.r;
            float G = _colorA.g / _colorB.g;
            float B = _colorA.b / _colorB.b;
            float A = _colorA.a / _colorB.a;
            return (R + G + B + A) / 4.0f;
        }

        /// <summary>
        /// Fix a BoxCollider2D that encapsulate all childrens,, NOTE: Dont include the Father GameObject
        /// </summary>
        /// <param name="_go">GameObject with BoxCollider2D</param>
        public static void BoxColliderFit(GameObject _go)
        {
            if (!(_go.GetComponent<Collider2D>() is BoxCollider2D))
            {
                Debug.LogWarning("Add a BoxColldier2D first");
                return;
            }

            bool FirstBound = false;
            Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

            for (int i = 0; i < _go.transform.childCount; ++i)
            {
                Renderer childRenderer = _go.transform.GetChild(i).GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    if (FirstBound)
                    {
                        bounds.Encapsulate(childRenderer.bounds);
                    }
                    else
                    {
                        bounds = childRenderer.bounds;
                        FirstBound = true;
                    }
                }
            }

            BoxCollider2D collider = (BoxCollider2D)_go.GetComponent<Collider2D>();
#if UNITY_5_0
            collider.offset = bounds.center - _go.transform.position;
#else
            collider.center = bounds.center - _go.transform.position;
#endif

            collider.size = bounds.size;
        }

        /// <summary>
        /// Shuffle a list (BETA)
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="_list">Original list</param>
        /// <returns>New list suffle<</returns>
        public static System.Collections.Generic.List<T> ShuffleList<T>(System.Collections.Generic.List<T> _list)
        {
            System.Collections.Generic.List<T> newList = new System.Collections.Generic.List<T>();
            while (_list.Count > 0)
            {
                int index = Random.Range(0, _list.Count);
                newList.Add(_list[index]);
                _list.RemoveAt(index);
            }
            return newList;
        }
    }
}
