using UnityEngine;

//uncomment if you going to use Unity Connect
//#define debugm

namespace Arj2D
{
    public static class InputMobileManager
    {

        public static bool GetTouchDown(int _id = 0)
        {
#if UNITY_EDITOR && !debugm
            if (!UnityEditor.EditorApplication.isRemoteConnected)
                return Input.GetMouseButtonDown(0);
            else
                return Input.GetTouch(_id).phase == TouchPhase.Began;
#else
            return Input.GetTouch(_id).phase == TouchPhase.Began;
#endif
        }

        public static bool GetTouchUp(int _id = 0)
        {
#if UNITY_EDITOR && !debugm
            if (!UnityEditor.EditorApplication.isRemoteConnected)
                return Input.GetMouseButtonUp(0);
            else
                return Input.GetTouch(_id).phase == TouchPhase.Ended;
#else
            return Input.GetTouch(_id).phase == TouchPhase.Ended;
#endif
        }

        public static bool IsTouching()
        {
#if UNITY_EDITOR && !debugm
            if (!UnityEditor.EditorApplication.isRemoteConnected)
                return true;
            else
                return Input.touchCount > 0;
#else
             return Input.touchCount > 0;
#endif
        }

        public static int GetTouchNumber()
        {
#if UNITY_EDITOR && !debugm
            if (!UnityEditor.EditorApplication.isRemoteConnected)
                return 1;
            else
                return Input.touchCount;
#else
            return Input.touchCount;
#endif
        }

        public static Vector2 GetPosition(int _id = 0)
        {
#if UNITY_EDITOR && !debugm
            if (!UnityEditor.EditorApplication.isRemoteConnected)
                return Input.mousePosition;
            else
                return Input.GetTouch(_id).position;
#else
            return Input.GetTouch(_id).position;
#endif
        }

        public static bool GetBackButton()
        {
#if UNITY_EDITOR
            return Input.GetKeyDown(KeyCode.Backspace);
#else
            return Input.GetKeyUp(KeyCode.Escape);
#endif
        }

        public static RaycastHit2D Raycast2D(int _layer = Physics2D.DefaultRaycastLayers, float _distance = 0f)
        {
            Ray ray = Camera.main.ScreenPointToRay(GetPosition());
            return Physics2D.Raycast(ray.origin, ray.direction, _distance, _layer);
        }

        public static void Raycast2D(out RaycastHit2D _hit, int _layer = Physics2D.DefaultRaycastLayers, float _distance = 0f)
        {
            Ray ray = Camera.main.ScreenPointToRay(GetPosition());
            _hit = Physics2D.Raycast(ray.origin, ray.direction, _distance, _layer);
        }
    }
}

