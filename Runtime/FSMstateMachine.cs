using System;
using System.Collections.Generic;

namespace Arj2D
{
    public class FSMstateMachineActions<T>
    {
        public abstract class FSMAction
        {
            public Action Enter;
            public Action Act;
            public Action Update;
            public Action Exit;
        }
        
        Dictionary<T, FSMAction> states = new Dictionary<T, FSMAction>();
        FSMAction currentState;
        public FSMAction CurrentStaet => currentState;

        public void AddState(FSMAction _callbackClass, T _stateID)
        {
#if UNITY_EDITOR
            if (states.ContainsKey(_stateID)) //Security is not already add
            {
                UnityEngine.Debug.LogError("Ya existe estado: " + _stateID);
                return;
            }
#endif

            //Add the new state
            states.Add(_stateID, _callbackClass);
        }

        public void ChangeState(T _stateID)
        {
            currentState?.Exit();

            currentState = states.ContainsKey(_stateID) ? states[_stateID] : null;
            currentState?.Enter();
        }

        public void Update()
        {
            if(currentState == null) return;

            currentState.Act();
            currentState.Update();
        }
    }
    
    public class FSMstateMachine<T>
    {
        Dictionary<T, IFsm> states = new Dictionary<T, IFsm>();
        IFsm currentState;
        public IFsm CurrentStaet => currentState;

        public void AddState(IFsm _callbackClass, T _stateID)
        {
#if UNITY_EDITOR
            if (states.ContainsKey(_stateID)) //Security is not already add
            {
                UnityEngine.Debug.LogError("Ya existe estado: " + _stateID);
                return;
            }
#endif

            //Add the new state
            states.Add(_stateID, _callbackClass);
        }

        public void ChangeState(T _stateID)
        {
            currentState?.Exit();

            currentState = states.ContainsKey(_stateID) ? states[_stateID] : null;
            currentState?.Enter();
        }

        public void Update()
        {
            if(currentState == null) return;

            currentState.Act();
            currentState.Update();
        }

        public void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }
    }

    public interface IFsm
    {
        public void Enter();
        public void Act(); // Check if we need change state
        public void Update();
        public void FixedUpdate();
        public void Exit();
    }

    public abstract class FsmState : IFsm
    {
        public virtual void Enter() { }

        public virtual void Act() {}

        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        public virtual void Exit() { }
    }
    
}


