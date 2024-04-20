using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FSMDie : FSMState
{
    float _timer = 5.5f;

    public FSMDie(FSM fsm) : base(fsm) { }

    public override void Update()
    {
        _enemy.Die();
        if (_timer <= 0) _enemy.DestroyEnemy();
    }

}
