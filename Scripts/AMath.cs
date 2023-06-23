﻿using UnityEngine;

namespace Arj2D
{
    public static class AMath
    {
        public const float PI2 = Mathf.PI * 2f;
        public const float TAU = Mathf.PI * 2f;

        public static bool CompareFloat(float _a, float _b, float _margen = 0.001f)
        {
            if (_a == _b)
            {
                // Shortcut, handles infinities
                return true;
            }

            float diff = Mathf.Abs(_a - _b);
            return diff < _margen;
        }

        /// <summary>
        /// Like Mathf.Sign, but return 0f with 0 and not 1f and can set a deadzone
        /// </summary>
        /// <param name="_value">Value to check sign</param>
        /// <param name="_deadZone">Offset with to considerer with 0</param>
        /// <returns></returns>
        public static float Sign(float _value, float _deadZone = 0f)
        {
            return _value > _deadZone ? 1f : (_value < -_deadZone ? -1f : 0f);
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

        public static bool IsBetween(float _value, float _minInclusive, float _maxInclusive)
        {
            return !(_value < _minInclusive) && !(_value > _maxInclusive);
        }

        public static bool IsEven(int _value) => _value % 2 == 0;

        public static bool IsOdd(int _value) => !IsEven(_value);

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
            return Mathf.Atan2(_v2.y, _v2.x) * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Direction in Vector2 to Angle in RAD
        /// </summary>
        /// <param name="_v2">Vector Direction</param>
        /// <returns></returns>
        public static float V2ToAngleRad(Vector2 _v2)
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
        
        public static Vector2 DirectionV2(Transform _origin, Vector2 _destiny)
        {
            return new Vector2((_destiny.x - _origin.position.x), (_destiny.y - _origin.position.y)).normalized;
        }

        public static float GetAngle(Transform _origin, Transform _target)
        {
            return GetAngle(_origin, _target, _origin.forward);
        }

        public static float GetAngle(Transform _origin, Transform _target, Vector3 _forward)
        {
            Vector3 targetDir = _target.position - _origin.position;
            return Vector3.Angle(targetDir, _forward);
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
        /// <param name="_angle">The source angle.</param>
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
        /// <param name="_angle">The source angle.</param>
        public static float NeutralizeAngle(float _angle)
        {
            if (_angle < 0.0f)
                return (_angle % PI2) * -1;
            else
                return _angle % PI2;
        }
        
        public static float ClampAngle(float _angle, float _min, float _max)
        {
            if (_angle < 90 || _angle > 270)
            {       // if angle in the critic region...
                if (_angle > 180) _angle -= 360;  // convert all angles to -180..+180
                if (_max > 180) _max -= 360;
                if (_min > 180) _min -= 360;
            }
            _angle = Mathf.Clamp(_angle, _min, _max);
            if (_angle < 0) _angle += 360;  // if angle negative, convert to 0..360
            return _angle;
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
        /// Clamp Integer
        /// </summary>
        /// <param name="_value">Current value</param>
        /// <param name="_min">Minimum value</param>
        /// <param name="_max">Maximun value</param>
        /// <returns>Value clamped</returns>
        public static int Clamp(int _value, int _min, int _max)
        {
            if(_value < _min)
                return _min;
            if (_value > _max)
                return _max;
            return _value;
        }

        /// <summary>
        /// Limit a valie dont be bigger than max
        /// </summary>
        /// <param name="_value">value</param>
        /// <param name="_max">biggest value possible</param>
        /// <returns></returns>
        public static float ClampMax(float _value, float _max)
        {
            return _value < _max ? _value : _max;
        }

        /// <summary>
        /// Limit a value dont be lesser than min
        /// </summary>
        /// <param name="_value">value</param>
        /// <param name="_min">losser value possible</param>
        /// <returns></returns>
        public static float ClampMin(float _value, float _min)
        {
            return _value > _min ? _value : _min;
        }

        /// <summary>
        /// Return points around a positions
        /// </summary>
        /// <returns>The around position.</returns>
        /// <param name="_center">Center where point going to generate</param>
        /// <param name="_radius">Radio or distance from center</param>
        /// <param name="_numberPoints">Number of points to generate</param>
        /// <param name="_addAngularOffset">Offset add to the rotation</param>
        public static Vector2[] PointsAroundPosition(Vector3 _center, float _radius, int _numberPoints, float _addAngularOffset = 0f)
        {
            Vector2[] Points = new Vector2[_numberPoints];
            float rot = _addAngularOffset;
            float rateRot = TAU / _numberPoints;
            for (int i = _numberPoints; i-- != 0;)
            {
                Points[i].x = _radius * Mathf.Cos(rot) + _center.x;
                Points[i].y = _radius * Mathf.Sin(rot) + _center.y;
                rot += rateRot;
            }
            return Points;
        }

        ///Based in https://en.wikipedia.org/wiki/Point_in_polygon
        /// <summary>
        /// Check if point is inside a polygon
        /// </summary>
        /// <param name="_point">Point to test</param>
        /// <param name="_polygonVertices">Vertex of polygon</param>
        /// <returns></returns>
        public static bool PointInsidePolygon(Vector2 _pointTest, Vector2[] _polygonVertices)
        {
            int nCounter = 0;
            int nPoints = _polygonVertices.Length;
            Vector2 p1, p2;
            p1 = _polygonVertices[0];
            for (int i = 1; i < nPoints; i++)
            {
                p2 = _polygonVertices[i % nPoints];
                if (_pointTest.y > Mathf.Min(p1.y, p2.y))
                {
                    if (_pointTest.y <= Mathf.Max(p1.y, p2.y))
                    {
                        if (_pointTest.x <= Mathf.Max(p1.x, p2.x))
                        {
                            if (p1.y != p2.y)
                            {
                                float xInters = (_pointTest.y - p1.y) * (p2.x - p1.x) / (p2.y - p1.y) + p1.x;
                                if ((p1.x == p2.x) || (_pointTest.x <= xInters))
                                {
                                    nCounter++;
                                }
                            }
                        }
                    }
                }
                p1 = p2;
            }
            if ((nCounter % 2) == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Return [0-1] from value takin _min 0 and _max 1
        /// </summary>
        /// <param name="_value">Value to return normalize it</param>
        /// <param name="_min">Min taking like 0</param>
        /// <param name="_max">Max taking lie 1</param>
        /// <returns>Return Normalize value</returns>
        public static float Normalize(float _value, float _min, float _max)
        {
            return (_value - _min) / (_max - _min);
        }

        /// <summary>
        /// Return the point closest to the line made with Vector A and Vector B from a point in world
        /// </summary>
        /// <param name="_vA">Vector A</param>
        /// <param name="_vB">Vector B</param>
        /// <param name="_vP">Point from seach closest point in line</param>
        /// <returns></returns>
        public static Vector3 ClosestPointOnLine(Vector3 _vA, Vector3 _vB, Vector3 _vP)
        {
            var vVector1 = _vP - _vA;
            var vVector2 = (_vB - _vA).normalized;

            var d = Vector3.Distance(_vA, _vB);
            var t = Vector3.Dot(vVector2, vVector1);

            if (t <= 0)
                return _vA;

            if (t >= d)
                return _vB;

            Vector3 vVector3 = vVector2 * t;

            Vector3 vClosestPoint = _vA + vVector3;

            return vClosestPoint;
        }
    }
}