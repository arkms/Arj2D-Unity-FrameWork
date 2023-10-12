using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arj2D
{
    public class FSMStateMachine<T>
    {
        Dictionary<T, FSMstateMachineActions> states = new Dictionary<T, FSMstateMachineActions>();
        FSMstateMachineActions currentActions;
        T currentState;

        public T CurrentStateId => currentState;

        public void AddState(FSMstateMachineActions _callback, T _stateID)
        {
#if UNITY_EDITOR
            if (states.ContainsKey(_stateID)) //Security is not already add
            {
                UnityEngine.Debug.LogError("Ya existe estado: " + _stateID);
                return;
            }
#endif

            //Add the new state
            states.Add(_stateID, _callback);
        }

        public void Start(T _stateID)
        {
            currentState = _stateID;
            currentActions = states.ContainsKey(_stateID) ? states[_stateID] : null;
            currentActions?.Enter?.Invoke();
        }

        public void ChangeState(T _stateID)
        {
            if (currentState.Equals(_stateID))
                return;
            
            currentActions?.Exit?.Invoke();

            currentState = _stateID;
            currentActions = states.ContainsKey(_stateID) ? states[_stateID] : null;
            currentActions?.Enter?.Invoke();
        }

        public void Update()
        {
            currentActions?.Update?.Invoke();
        }

        public void FixedUpdate()
        {
            currentActions?.FixedUpdate?.Invoke();
        }
    }

    public class FSMstateMachineActions
    {
        public Action Enter = null;
        public Action Update = null;
        public Action FixedUpdate = null;
        public Action Exit = null;
    }

    public class FSMStateMachineActionsBehaviour : MonoBehaviour
    {
        // In the awake or start call add to FSM
        protected FSMstateMachineActions actions;

        protected void Awake()
        {
            actions = new FSMstateMachineActions
            {
                Enter = ActionEnter,
                Update = ActionUpdate,
                FixedUpdate = ActionFixedUpdate,
                Exit = ActionExit
            };
        }

        protected virtual void ActionEnter(){}
        protected virtual void ActionUpdate(){}
        protected virtual void ActionFixedUpdate(){}
        protected virtual void ActionExit(){}
    }
}


