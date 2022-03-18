using UnityEngine;

namespace Arj2D
{
    public class DebugCollider2D : MonoBehaviour
    {
        public bool PrintCollisionStay = false;
        public bool PrintTriggerStay = false;
        private GameObject gameobject_;

        void Awake()
        {
            gameobject_ = base.gameObject;
        }

        void OnCollisionEnter2D(Collision2D _col)
        {
            Debug.Log(gameobject_.name + " CollisionEnter with " + _col.gameObject.name, this);
        }

        void OnCollisionExit2D(Collision2D _col)
        {
            Debug.Log(gameobject_.name + " CollisionExit with " + _col.gameObject.name, this);
        }

        void OnCollisionStay2D(Collision2D _col)
        {
            if (PrintCollisionStay)
                Debug.Log(gameobject_.name + " CollisionStay with " + _col.gameObject.name, this);
        }

        void OnTriggerEnter2D(Collider2D _col)
        {
            Debug.Log(gameobject_.name + " triggerEnter with " + _col.gameObject.name, this);
        }

        void OnTriggerExit2D(Collider2D _col)
        {
            Debug.Log(gameobject_.name + " triggerExit with " + _col.gameObject.name, this);
        }

        void OnTriggerStay2D(Collider2D _col)
        {
            if (PrintTriggerStay)
                Debug.Log(gameobject_.name + " triggerStay with " + _col.gameObject.name, this);
        }
    }
}