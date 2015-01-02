using UnityEngine;

//[AddComponentMenu("MonoBehaviour2D")]
public class MonoBehaviour2D : MonoBehaviour
{
    private Animator anim;
    protected Animator animator
    {
        get
        {
            if (anim)
                return anim;
            else
            {
                anim = this.GetComponent<Animator>();
                return anim;
            }
        }
    }

    private Collider2D col2d;
    protected new Collider2D collider2D
    {
        get
        {
            if (col2d)
                return col2d;
            else
            {
                col2d = this.GetComponent<Collider2D>();
                return col2d;
            }
        }
    }

    private GameObject go;
    protected new GameObject gameObject
    {
        get
        {
            if (go)
                return go;
            else
            {
                go = this.GetComponent<Transform>().gameObject;
                return go;
            }
        }
    }

    private Rigidbody2D rb2d;
    protected new Rigidbody2D rigidbody2D
    {
        get
        {
            if (rb2d)
            {
                return rb2d;
            }
            else
            {
                rb2d = this.GetComponent<Rigidbody2D>();
                return rb2d;
            }
        }
    }

    private SpriteRenderer sr;
    protected SpriteRenderer spriteRender
    {
        get
        {
            if (sr)
            {
                return sr;
            }
            else
            {
                sr = this.GetComponent<SpriteRenderer>();
                return sr;
            }
        }
    }


    private Transform trasfor;
    protected new Transform transform
    {
        get
        {
            if (trasfor)
            {
                return trasfor;
            }
            else
            {
                trasfor = this.GetComponent<Transform>();
                return trasfor;
            }
        }
    }    
}