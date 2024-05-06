using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    public FSMState CurrentState { get; private set; }
    private Dictionary<Type, FSMState> _states = new();
    public EnemyBrain Enemy { get; private set; }

    public FSM(EnemyBrain enemy)
    {
        Enemy = enemy;
        AddAllStates();
        SetStateAtBeginning();
    }
    public void AddState(FSMState state)
    {
        _states.Add(state.GetType(), state);
    }

    void SetStateAtBeginning() => CurrentState = new FSMPatrol(this);

    void AddAllStates()
    {
        AddState(new FSMAttack(this));
        AddState(new FSMDie(this));
        AddState(new FSMChase(this));
        AddState(new FSMPatrol(this));
    }
    
    public void SetState<T>() where T : FSMState
    {
        var type = typeof(T);

        if (CurrentState.GetType() == type) return;
        if (_states.TryGetValue(type, out var newState))
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }

    public void Update() => CurrentState?.Update();
}
