using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public class FSMChase : FSMState
    {
        public FSMChase(FSM fsm) : base(fsm) { }

        public override void Update()
        {
            _enemy.Mover.MoveTo(_enemy.Player.Position);
            if (_enemy.RemainingDistance <= 1) _fsm.SetState<FSMAttack>();
            if (Mathf.Abs(FindAngleToPlayer()) > 35 || _enemy.RemainingDistance > 4) _fsm.SetState<FSMPatrol>();
            EnemysDeath();
        }
    }

