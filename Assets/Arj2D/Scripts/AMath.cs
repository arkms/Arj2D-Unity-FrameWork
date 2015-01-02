using UnityEngine;

public static class AMath
{
    /// <summary>
    /// Cast from Vector3 to Vector2
    /// </summary>
    /// <param name="_vector3">Vector3 to cast to Vector2</param>
    /// <returns>return Vector2</returns>
    public static Vector2 vector2(Vector3 _vector3)
    {
        return new Vector2(_vector3.x, _vector3.y);
    }

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
    /// Flip one Sprite
    /// </summary>
    /// <param name="_trasform">Transfrom from sprite to Flip</param>
    public static void Flip(Transform _trasform)
    {
        Vector3 theScale = _trasform.localScale;
        theScale.x *= -1;
        _trasform.localScale = theScale;
    }
}
