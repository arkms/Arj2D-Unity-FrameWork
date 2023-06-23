using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arj2D
{
    public class TimerManager : MonoBehaviour
    {
        static TimerManager Instance;

        List<Timer> timers = new List<Timer>();

        private void Update()
        {
            foreach (Timer t in timers)
                t.Update(Time.deltaTime);
        }

        public static void SetupTimer(Timer t)
        {
            if(!Instance.timers.Contains(t))
                Instance.timers.Add (t);
        }

        public static void RemoveTimer (Timer t)
        {
            Instance.timers.Remove(t);
        }
        
        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            GameObject go = new GameObject("Timer Manager");
            Instance= go.AddComponent<TimerManager>();
            DontDestroyOnLoad(Instance);
        }
    }
}

