using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class StateMachine : IDisposable
{
    private IReadOnlyList<IExitState> _states;
    private IExitState _currentState;

    public void Initialize(IReadOnlyList<IExitState> states)
    {
        _states = states;
    }

    public void EnterState<TState>() where TState : IState
    {
        var state = _states.FirstOrDefault(s => s.GetType() == typeof(TState));

        if (state == null)
        {
            Debug.LogError($"Failed to find state of type {typeof(TState)}");
            return;
        }

        Debug.Log($"State transition from {_currentState?.GetType().Name} to {state.GetType().Name}");

        _currentState?.Exit();
        _currentState = state;
        ((IState)_currentState).Enter();
    }

    public void EnterState<TState, TPayload>(TPayload data) where TState : IPayLoadedState<TPayload>
    {
        var state = _states.FirstOrDefault(s => s.GetType() == typeof(TState));

        if (state == null)
        {
            Debug.LogError($"Failed to find state of type {typeof(TState)}");
            return;
        }

        Debug.Log($"State transition from {_currentState?.GetType().Name} to {state.GetType().Name}");

        _currentState?.Exit();
        _currentState = state;
        ((IPayLoadedState<TPayload>)_currentState).Enter(data);
    }

    public void Dispose()
    {
        _currentState?.Exit();
    }
}