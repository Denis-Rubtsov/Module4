using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState
{
    protected EnemyBrain _enemy;
    protected FSM _fsm;

    public FSMState( FSM fsm)
    {
        _enemy = fsm.Enemy;
        _fsm = fsm;
    }

    protected float FindAngleToPlayer()
    {
        var playerPos = _enemy.Player.Position;
        playerPos.y = _enemy.transform.position.y;
        float angle = Vector3.SignedAngle(playerPos - _enemy.transform.position, _enemy.transform.forward, Vector3.up);
        return angle;
    }

    protected void EnemysDeath()
    {
        if (!_enemy.IsDead) return;
        _fsm.SetState<FSMDie>();
        _enemy.SpawnLoot();
    }

    public virtual void Enter() => Debug.Log($"Entering state {this.GetType()}");
    public virtual void Exit() => Debug.Log($"Exiting state {this.GetType()}");
    public virtual void Update() { }
}
