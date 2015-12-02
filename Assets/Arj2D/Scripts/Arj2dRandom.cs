using UnityEngine;
using System.Collections;

namespace Arj2D
{
    public static class Arj2dRandom
    {
        public static Color ColorRGB()
        {
            return new Color(Random.value, Random.value, Random.value, 1f);
        }

        public static Color ColorAlpha()
        {
            return new Color(Random.value, Random.value, Random.value, Random.value);
        }

        public static Color ColorAlpha(float _alpha)
        {
            return new Color(Random.value, Random.value, Random.value, _alpha);
        }


        /// <summary>
        /// This algorithm computes a palette by computing a small random offset from a given colour
        /// </summary>
        /// <param name="_color">Original color for start</param>
        /// <param name="_offset">From 0.0f to 1f,, try</param>
        /// <returns>new color offset from _color</returns>
        public static Color ColorOffset(Color _color, float _offset)
        {
            float value = (_color.r + _color.g + _color.b)/3;
            float newValue = value + 2 * Random.value * _offset - _offset;
            float valueRatio = newValue / value;
            Color newColor = new Color();
            newColor.r = _color.r * valueRatio;
            newColor.g = _color.g * valueRatio;
            newColor.b = _color.b * valueRatio;
            newColor.a = 1f;
            return newColor;
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
