using UnityEngine;

public static class UnityEngineExtensions
{
    //TRASNFORM
    public static void SetPositionX(this Transform _transform ,float _newX)
    {
        _transform.position = new Vector3(_newX, _transform.position.y, _transform.position.z);
    }
    public static void SetPositionY(this Transform _transform, float _newY)
    {
        _transform.position = new Vector3(_transform.position.x, _newY, _transform.position.z);
    }
    public static void SetPositionZ(this Transform _transform, float _newZ)
    {
        _transform.position = new Vector3(_transform.position.x, _transform.position.y, _newZ);
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
        Vector3 temp = _transform.position;
        temp.x += _offsetX;
        _transform.position = temp;
    }
    public static void ShiftPositionY(this Transform _transform, float _offsetY)
    {
        Vector3 temp = _transform.position;
        temp.y += _offsetY;
        _transform.position = temp;
    }
    public static void ShiftPositionZ(this Transform _transform, float _offsetZ)
    {
        Vector3 temp = _transform.position;
        temp.z += _offsetZ;
        _transform.position = temp;
    }
    /// <summary>
    /// Flip a transform, use for Flip Sprite
    /// </summary>
    public static void Flip(this Transform _transform)
    {
        Vector3 theScale = _transform.localScale;
        theScale.x *= -1;
        _transform.localScale = theScale;
    }
    /// <summary>
    /// Flip a transform, use for Flip Sprite
    /// </summary>
    public static void Flip(this Transform _transform, bool _facingRight)
    {
        Vector3 theScale = _transform.localScale;
        if (_facingRight)
            theScale.x *= 1;
        else
            theScale.x *= -1;
        _transform.localScale = theScale;
    }


    //GAMEOBJECT
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

    //TEXTURE2D
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

    //VECTOR3
    public static Vector2 ToVector2(this Vector3 _vector3)
    {
        return new Vector2(_vector3.x, _vector3.y);
    }
}