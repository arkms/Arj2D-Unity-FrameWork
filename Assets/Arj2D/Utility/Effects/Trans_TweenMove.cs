using UnityEngine;
using System.Collections;

namespace Arj2D
{
    /// <summary>
    /// Make a GameObject a Tween move between startpoint and relative position
    /// </summary>
    public class Trans_TweenMove : MonoBehaviour
    {
        public float pulsePerSecond= 1f;
        public Vector3 Shift;

        private Transform transform_;
        private float TimePulse = 0;
        private Vector3 StartPos;
        private Vector3 EndPos;

        void Awake()
        {
            transform_ = base.transform;

            StartPos = transform_.position;
            EndPos = transform_.position + Shift;
        }

        void Update()
        {
            TimePulse += Time.deltaTime;
            float t = Mathf.Sin(Mathf.PI * TimePulse * pulsePerSecond);
            t*=t;
            transform_.localPosition = Vector3.Lerp(StartPos, EndPos, t); ;
        }
    }
}