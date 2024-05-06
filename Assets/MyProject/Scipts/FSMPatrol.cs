using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMPatrol : FSMState
{
    float _timer = 90;

    public FSMPatrol(FSM fsm) : base( fsm) { }

    public override void Update()
    {
        Vector3 newPosition = new(Random.Range(20, 101), 0, Random.Range(30, 111));
        _enemy.Mover.MoveTo(newPosition);
        if (_timer <= 0)
        {
            _enemy.Mover.StopOrStart();
            _timer = 90;
        }
        if (Mathf.Abs(FindAngleToPlayer()) <= 35) _fsm.SetState<FSMChase>();
        EnemysDeath();
    }
}
