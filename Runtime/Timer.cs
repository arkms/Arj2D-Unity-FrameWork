using System;

namespace Arj2D
{
    public class Timer
    {
        public event Action OnTimerEnd;
        public event Action OnTimerUpdate;
        
        float timeLeft = 0f;
        float duration;
        
        TimerState state = TimerState.PAUSED;

        public float Duration => duration;

        public float TimeLeft
        {
            get { return timeLeft; }
            private set
            {
                if (state == TimerState.UPDATING)
                {
                    if (value > 0f)
                    {
                        timeLeft = value;
                    }
                    else if (value <= 0f)
                    {
                        timeLeft = 0f;
                        state = TimerState.FINISHED;
                        OnTimerEnd?.Invoke();
                        TimerManager.RemoveTimer(this);
                    }
                }
            }
        }
        
        public Timer(float _duration)
        {
            TimerManager.SetupTimer(this);
            duration = _duration;
        }
        
        public Timer(float _endTime, Action _function) : this(_endTime)
        {
            OnTimerEnd += _function;
        }

        public void Pause()
        {
            state = TimerState.PAUSED;
        }
        
        public bool IsFinished()
        {
            return state == TimerState.FINISHED;
        }
        
        public bool IsStarted()
        {
            return state == TimerState.UPDATING;
        }

        public bool IsPause()
        {
            return state == TimerState.PAUSED;
        }
        
        public Timer Play()
        {
            state = TimerState.UPDATING;
            TimerManager.SetupTimer(this);
            return this;
        }
        
        public void Reset()
        {
            timeLeft =duration;
        }
        
        public void ResetPlay()
        {
            Reset();
            Play();
        }

        public void Update(float _delta)
        {
            if (state != TimerState.UPDATING)
                return;
            
            OnTimerUpdate?.Invoke();
            TimeLeft -= _delta;
        }

        public float GetPercentage()
        {
            return TimeLeft / Duration;
        }

        public float GetPercentageLeft()
        {
            return 1f - (TimeLeft / Duration);
        }

        public TimeSpan GetInTimeSpan()
        {
            return TimeSpan.FromSeconds(timeLeft);
        }
    }

    public enum TimerState
    {
        PAUSED,
        FINISHED,
        UPDATING
    };
}