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
        /// <param name="_vA">Posistion of GameObjec1</param>
        /// <param name="_vB">Posistion of GameObjec1</param>
        /// <returns>distance in 2D</returns>
        public static float Distance2D(Vector3 _vA, Vector3 _vB)
        {
            return (DistanceX(_vA, _vB) + DistanceY(_vA, _vB));
        }

        /// <summary>
        /// Calculate the distance between two vector3, ignoring the Z
        /// </summary>
        /// <param name="_vA">Transform of Gameobjec1</param>
        /// <param name="_vB">Transform of Gameobjec2</param>
        /// <returns>Distance in 2D</returns>
        public static float Distance2D(Transform _vA, Transform _vB)
        {
            return (DistanceX(_vA.position, _vB.position) + DistanceY(_vA.position, _vB.position));
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

        public static float DistanceX(Transform _vA, Transform _vB)
        {
            return Mathf.Abs(_vA.position.x - _vB.position.x);
        }

        public static float DistanceY(Vector3 _vA, Vector3 _vB)
        {
            return Mathf.Abs(_vA.y - _vB.y);
        }

        public static float DistanceY(Vector2 _vA, Vector2 _vB)
        {
            return Mathf.Abs(_vA.y - _vB.y);
        }

        public static float DistanceY(Vector3 _vA, Vector2 _vB)
        {
            return Mathf.Abs(_vA.y - _vB.y);
        }

        public static float DistanceY(Vector2 _vA, Vector3 _vB)
        {
            return Mathf.Abs(_vA.y - _vB.y);
        }

        public static float DistanceY(Transform _vA, Transform _vB)
        {
            return Mathf.Abs(_vA.position.y - _vB.position.y);
        }

        /// <summary>
        /// Angle to Vector2
        /// </summary>
        /// <param name="_angle"></param>
        /// <returns>Direction of Angle</returns>
        public static Vector2 AngleToV2(float _angle)
        {
            _angle *= Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle));
        }

        /// <summary>
        /// Angle in RAD to Vector2
        /// </summary>
        /// <param name="_angle">Angle in RAD</param>
        /// <returns>Direction of Angle</returns>
        public static Vector2 AngleRadToV2(float _angle)
        {
            return new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle));
        }

        /// <summary>
        /// Angle to Vector2
        /// </summary>
        /// <param name="_angle">Angle</param>
        /// <returns>Direction of Angle</returns>
        public static Vector2 AngleToV2(int _angle)
        {
            float angle = _angle * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }

        /// <summary>
        /// Direction in Vector2 to Angle
        /// </summary>
        /// <param name="_v2">Direction</param>
        /// <returns>Angle</returns>
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
        public static float DirectionX(Vector3 _origin, Vector3 _destiny)
        {
            if (_origin.x < _destiny.x)
                return 1f;
            else if (_origin.x > _destiny.x)
                return -1f;
            return 0f;
        }

        /// <summary>
        /// Get the direction you need in X from origin to destiny
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_destiny"></param>
        /// <returns></returns>
        public static float DirectionX(Transform _origin, Transform _destiny)
        {
            if (_origin.position.x < _destiny.position.x)
                return 1f;
            else if (_origin.position.x > _destiny.position.x)
                return -1f;
            return 0f;
        }

        /// <summary>
        /// Get the direction you need in X from origin to destiny
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_destiny"></param>
        /// <returns></returns>
        public static float DirectionX(float _origin, float _destiny)
        {
            if (_origin < _destiny)
                return 1f;
            else if (_origin > _destiny)
                return -1f;
            return 0f;
        }

        /// <summary>
        /// Get the direction you need in Y from origin to destiny
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_destiny"></param>
        /// <returns></returns>
        public static float DirectionY(Vector3 _origin, Vector3 _destiny)
        {
            if (_origin.y < _destiny.y)
                return 1f;
            else if (_origin.y > _destiny.y)
                return -1f;
            return 0f;
        }

        /// <summary>
        /// Get the direction you need in Y from origin to destiny
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_destiny"></param>
        /// <returns></returns>
        public static float DirectionY(float _origin, float _destiny)
        {
            if (_origin < _destiny)
                return 1f;
            else if (_origin > _destiny)
                return -1f;
            return 0f;
        }

        /// <summary>
        /// Get the direction you need in Y from origin to destiny
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_destiny"></param>
        /// <returns></returns>
        public static float DirectionY(Transform _origin, Transform _destiny)
        {
            if (_origin.position.y < _destiny.position.y)
                return 1f;
            else if (_origin.position.y > _destiny.position.y)
                return -1f;
            return 0f;
        }

        public static Vector3 Direction(Vector3 _origin, Vector3 _destiny)
        {
            return new Vector3((_destiny.x - _origin.x), (_destiny.y - _origin.y)).normalized;
        }

        public static Vector3 Direction(Transform _origin, Transform _destiny)
        {
            return new Vector3((_destiny.position.x - _origin.position.x), (_destiny.position.y - _origin.position.y)).normalized;
        }

        public static Vector2 DirectionV2(Vector3 _origin, Vector3 _destiny)
        {
            return new Vector2((_destiny.x - _origin.x), (_destiny.y - _origin.y)).normalized;
        }

        public static Vector2 DirectionV2(Transform _origin, Transform _destiny)
        {
            return new Vector2((_destiny.position.x - _origin.position.x), (_destiny.position.y - _origin.position.y)).normalized;
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
        /// Make one texture fill with one color
        /// </summary>
        /// <param name="_width">Width of texture</param>
        /// <param name="_height">Height of texture</param>
        /// <param name="_color">Color to fill all texture</param>
        /// <returns>Final texture</returns>
        public static Texture2D MakeTextureOneColor(int _width, int _height, Color _color)
        {
            Color[] pix = new Color[_width * _height];

            for (int i = 0; i < pix.Length; i++)
                pix[i] = _color;

            Texture2D result = new Texture2D(_width, _height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }

        /// <summary>
        /// Check if a point in the world is inside in the camera view
        /// </summary>
        /// <param name="cam">Camera to check</param>
        /// <param name="point">Point in the world</param>
        /// <returns></returns>
        public static bool InfiniteCameraCanSeePoint(Camera cam, Vector2 point)
        {
            Vector3 viewportPoint = cam.WorldToViewportPoint(point);
            return (viewportPoint.x >= 0f && viewportPoint.x <= 1f && viewportPoint.y >= 0f && viewportPoint.y <= 1f);
        }

        /// <summary>
        /// Limit a valie dont be bigger than max
        /// </summary>
        /// <param name="_value">value</param>
        /// <param name="_max">biggest value possible</param>
        /// <returns></returns>
        public static float ClampMax(float _value, float _max)
		{
			return _value<_max ? _value : _max;
        }

        /// <summary>
        /// Limit a value dont be lesser than min
        /// </summary>
        /// <param name="_value">value</param>
        /// <param name="_min">losser value possible</param>
        /// <returns></returns>
        public static float ClampMin(float _value, float _min)
		{
			return _value>_min ? _value : _min;
		}
    }
}
