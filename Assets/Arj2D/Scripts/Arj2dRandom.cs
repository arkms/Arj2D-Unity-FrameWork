using UnityEngine;
using System.Collections;

public static class Arj2dRandom
{
    public static Color ColorRGB()
    {
        return new Color(Random.value, Random.value, Random.value);
    }

    public static Color ColorAlpha()
    {
        return new Color(Random.value, Random.value, Random.value, Random.value);
    }

    public static Color ColorAlpha(float _alpha)
    {
        return new Color(Random.value, Random.value, Random.value, _alpha);
    }

    public static Vector3 Position(Vector3 _topleft, Vector3 _botright)
    {
        return new Vector3(Random.Range(_topleft.x, _botright.x), Random.Range(_topleft.y, _botright.y), Random.Range(_topleft.z, _botright.z));
    }

    public static Vector3 PositionXZ(Vector3 _topleft, Vector3 _botright, float _height)
    {
        return new Vector3(Random.Range(_topleft.x, _botright.x), _height, Random.Range(_topleft.z, _botright.z));
    }

    public static Vector3 PositionXY(Vector3 _topleft, Vector3 _botright, float _depth)
    {
        return new Vector3(Random.Range(_topleft.x, _botright.x), Random.Range(_topleft.y, _botright.y), _depth);
    }


    /// <summary>
    /// Return true or false with 50% of probability
    /// </summary>
    /// <returns></returns>
    public static bool Coin()
    {
        return Random.Range(0, 2) == 1;
    }

    /// <summary>
    /// Make a probability of something be true
    /// </summary>
    /// <param name="_proTrue">Probability of get true</param>
    /// <returns></returns>
    public static bool Probability(int _proTrue)
    {
        if (_proTrue > 100)
        {
            _proTrue = 100;
        }
        return Random.Range(0, 101) <= _proTrue;
    }

    /// <summary>
    /// Got random dirrection. Example, if you want make a enemy start with random dirrecion in X,, new Vector3(Sign(), 0.0f, 0.0f);
    /// </summary>
    /// <returns></returns>
    public static int Sign()
    {
        return (Random.Range(0, 2) == 1) ? 1 : -1;
    }

    /// <summary>
    /// Got random dirrection. Example, if you want make a enemy start with random dirrecion in X,, new Vector3(Sign(), 0.0f, 0.0f);
    /// </summary>
    /// <returns></returns>
    public static float Signf()
    {
        return (Random.Range(0, 2) == 1) ? 1f : -1f;
    }
}
