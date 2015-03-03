using UnityEngine;

/// <summary>
/// Integer Vector 2D
/// </summary>
[System.Serializable] //Make can save in Editor
public class Vector2i
{
    public int x;
    public int y;

    public Vector2i()
    {}

    public Vector2i(int _x, int _y)
    {
        this.x = _x;
        this.y = _y;
    }

    public Vector2i(Vector2 _v)
    {
        this.x = (int)_v.x;
        this.y = (int)_v.y;
    }

    public int this[int idx]
    {
        get { return idx == 0 ? this.x : this.y; }
        set
        {
            switch (idx)
            {
                case 0:
                    this.x = value;
                    break;
                default:
                    this.y = value;
                    break;
            }
        }
    }

    public Vector2 toVector2()
    {
        return new Vector2(this.x, this.y);
    }

    public float magnitude
    {
        get
        {
            return Mathf.Sqrt(this.x * this.x + this.y * this.y);
        }
    }

    public override int GetHashCode()
    {
        return this.x ^ this.y;
    }

    public override string ToString()
    {
        return "Vector2i {" + this.x + ", " + this.y + "}";
    }

    public static Vector2i operator +(Vector2i v1, Vector2i v2)
    {
        return new Vector2i(v1.x + v2.x, v1.y + v2.y);
    }
    public static Vector2 operator +(Vector2i v1, Vector2 v2)
    {
        return new Vector3(v1.x + v2.x, v1.y + v2.y);
    }
    public static Vector2 operator +(Vector2 v1, Vector2i v2)
    {
        return new Vector3(v1.x + v2.x, v1.y + v2.y);
    }

    public static Vector2i operator -(Vector2i v1, Vector2i v2)
    {
        return new Vector2i(v1.x + v2.x, v1.y - v2.y);
    }
    public static Vector2 operator -(Vector2i v1, Vector2 v2)
    {
        return new Vector3(v1.x - v2.x, v1.y - v2.y);
    }
    public static Vector2 operator -(Vector2 v1, Vector2i v2)
    {
        return new Vector3(v1.x - v2.x, v1.y - v2.y);
    }
        
    public static Vector2i operator *(Vector2i v, int i)
    {
        return new Vector2i(v.x * i, v.y * i);
    }
    public static Vector2 operator *(Vector2i v, float f)
    {
        return new Vector2(v.x * f, v.y * f);
    }
    public static Vector2i operator *(int i, Vector2i v)
    {
        return new Vector2i(i * v.x, i * v.y);
    }
    public static Vector2 operator *(float f, Vector2i v)
    {
        return new Vector2(f * v.x, f * v.y);
    }

    public static bool operator ==(Vector2i a, Vector2i b)
    {
        if (System.Object.ReferenceEquals(a, b))
        {
            return true;
        }

        if (((object)a == null) || ((object)b == null))
        {
            return false;
        }

        return a.x == b.x && a.y == b.y;
    }

    public override bool Equals(System.Object obj)
    {
        if (obj == null)
        {
            return false;
        }

        Vector2i p = obj as Vector2i;
        if ((System.Object)p == null)
        {
            return false;
        }

        return (this.x == p.x) && (this.y == p.y);
    }

    public bool Equals(Vector2i p)
    {
        if ((object)p == null)
        {
            return false;
        }

        return (this.x == p.x) && (this.y == p.y);
    }

    public static bool operator !=(Vector2i a, Vector2i b)
    {
        return !(a == b);
    }
}