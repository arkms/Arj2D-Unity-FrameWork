using UnityEngine;

namespace Arj2D
{
    /// <summary>
    /// Make Sprite change between two colors
    /// </summary>
    public class Sprite_ColorPulse : MonoBehaviour
    {
        public float pulsePerSecond = 1f;
        public Color StartColor = Color.white;
        public Color EndColor = Color.white;

        private SpriteRenderer sr;
        private float TimePulse;
        private Color DefaultColor;

        void Awake()
        {
            sr = this.GetComponent<SpriteRenderer>();
            DefaultColor = sr.color;
        }

        void Start()
        {
            TimePulse = 0;
            sr.color = StartColor;
        }

        void Update()
        {
            //calculate
            TimePulse += Time.deltaTime;
            float t = Mathf.Sin(Mathf.PI * TimePulse * pulsePerSecond);
            t *= t;
            //assign
            sr.color = Color.Lerp(StartColor, EndColor, t);
        }

        //reset
        void OnDisable()
        {
            sr.color = DefaultColor;
        }
    }
}