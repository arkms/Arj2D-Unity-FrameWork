using UnityEngine;

namespace Arj2D
{
    public static class AMath
    {
        public const float PI2 = Mathf.PI * 2f;
        public const float TAU = Mathf.PI * 2f;

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
        /// Get in RAD the angle from a transform with direction to a point in word, can be from -Pi to PI (-180° to 180). Taking transform.right how forward
        /// </summary>
        /// <param name="_direction">Transform of object we want know the angles between his forward and destiny</param>
        /// <param name="_destiny">Object look at</param>
        /// <returns>Angle in RAD</returns>
        public static float Angle_Relative(Transform _direction, Transform _destiny)
        {
            Vector3 ObjDirection = _destiny.position - _direction.position;
            ObjDirection.Normalize();

            return Vector3.Cross(_direction.right, ObjDirection).z;
        }

        /// <summary>
        /// Get in RAD the angle from a transform with direction to a point in word, can be from -Pi to PI (-180° to 180).
        /// </summary>
        /// <param name="_direction">Transform of object we want know the angles between his forward and destiny</param>
        /// <param name="_destiny">Object look at</param>
        /// <param name="_forward">Forward of your GameObject, use if is not transform.right</param>
        /// <returns>Angle in RAD</returns>
        public static float Angle_Relative(Transform _direction, Transform _destiny, Vector3 _forward)
        {
            Vector3 ObjDirection = _destiny.position - _direction.position;
            ObjDirection.Normalize();

            return Vector3.Cross(_forward, ObjDirection).z;
        }

        /// <summary>
        /// Get in RAD the angle from a transform with direction to a point in word, but only get the angle always positive. Taking transform.right how forward
        /// </summary>
        /// <param name="_direction">Transform of object we want know the angles between his forward and destiny</param>
        /// <param name="_destiny">Object look at</param>
        /// <returns>Angle in RAD always positive</returns>
        public static float Angle_RelativeAbs(Transform _direction, Transform _destiny)
        {
            Vector3 ObjDirection = _destiny.position - _direction.position;
            ObjDirection.Normalize();

            float dot = Vector3.Dot(ObjDirection, _direction.right);
            return Mathf.Acos(dot);
        }

        /// <summary>
        /// Get in RAD the angle from a transform with direction to a point in word, but only get the angle always positive.
        /// </summary>
        /// <param name="_direction">Transform of object we want know the angles between his forward and destiny</param>
        /// <param name="_destiny">Object look at</param>
        /// <param name="_forward">Forward of your GameObject, use if is not transform.right</param>
        /// <returns>Angle in RAD always positive</returns>
        public static float Angle_RelativeAbs(Transform _direction, Transform _destiny, Vector3 _forward)
        {
            Vector3 ObjDirection = _destiny.position - _direction.position;
            ObjDirection.Normalize();

            float dot = Vector3.Dot(ObjDirection, _forward);
            return Mathf.Acos(dot);
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
        /// Neutralizes the an angle in Grad
        /// </summary>
        /// <returns>The neutralized angle.</returns>
        /// <param name="angle">The source angle.</param>
        public static float NeutralizeAngleInGrad(float _angle)
        {
            if (_angle < 0.0f)
                return (_angle % 360.0f) * -1;
            else
                return _angle % 360.0f;
        }

        /// <summary>
        /// Neutralizes the an angle.
        /// </summary>
        /// <returns>The neutralized angle.</returns>
        /// <param name="angle">The source angle.</param>
        public static float NeutralizeAngle(float _angle)
        {
            if (_angle < 0.0f)
                return (_angle % PI2) * -1;
            else
                return _angle % PI2;
        }

        /// <summary>
        /// A Lerp function but for Vector3
        /// </summary>
        /// <param name="_start">Start position</param>
        /// <param name="_end">End position</param>
        /// <param name="_percent">Percent, value between 0 - 1</param>
        /// <returns></returns>
        public static Vector3 LerpV3(Vector3 _start, Vector3 _end, float _percent)
        {
            return (_start + _percent*(_end - _start));
        }

        /// <summary>
        /// This is similar to Lerp, but travels the torque-minimal path. which means it travels along the straightest path the rounded surface of a sphere
        /// </summary>
        /// <param name="start">Start Position</param>
        /// <param name="end">End Position</param>
        /// <param name="percent">Percent, value between 0 - 1</param>
        /// <returns>Vector3 result of Slerp</returns>
        public static Vector3 Slerp(Vector3 _start, Vector3 _end, float _percent)
        {
            //Taked from https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/#more-506
            // Dot product - the cosine of the angle between 2 vectors.
            float dot = Vector3.Dot(_start, _end);
            // Clamp it to be in the range of Acos()
            // This may be unnecessary, but floating point
            // precision can be a fickle mistress.
            Mathf.Clamp(dot, -1.0f, 1.0f);
            // Acos(dot) returns the angle between start and end,
            // And multiplying that by percent returns the angle between
            // start and the final result.
            float theta = Mathf.Acos(dot) * _percent;
            Vector3 RelativeVec = _end - _start * dot;
            RelativeVec.Normalize();     // Orthonormal basis
            // The final result.
            return ((_start * Mathf.Cos(theta)) + (RelativeVec * Mathf.Sin(theta)));
        }

        /// <summary>
        /// Faster option to Slerp, but little less accurate. Does not maintain a constant velocity.
        /// </summary>
        /// <param name="_start">Start position</param>
        /// <param name="_end">End position</param>
        /// <param name="_percent">Percent, value between 0 - 1</param>
        /// <returns></returns>
        public static Vector3 Nlerp(Vector3 _start, Vector3 _end, float _percent)
        {
            //Taked from https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/#more-506
            return LerpV3(_start, _end, _percent).normalized;
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
            collider.offset = bounds.center - _go.transform.position;
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
