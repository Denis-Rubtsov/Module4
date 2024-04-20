using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAttack : FSMState
{
    public FSMAttack(FSM fsm) : base(fsm) { }

    public override void Update()
    {
        if (_enemy.RemainingDistance > 1) _fsm.SetState<FSMChase>();
        _enemy.Attacker.Attack();
        EnemysDeath();
    }
}
