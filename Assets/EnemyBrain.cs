using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] public Player Player;
    [SerializeField] Animator _animator;
    [SerializeField] Health _health;
    [SerializeField] public NavMeshMover Mover;
    [SerializeField] public Attacker Attacker;
    [SerializeField] PlayerConfig _config;

    public float RemainingDistance { get; private set; }
    public bool IsDead { get; private set; }
    FSM _fsm;

    void Start()
    {
        _fsm = new(this);
        _health.SetMaxHealth(_config.MaxHealth);
        Attacker.SetWeapon(_config.Weapon);
    }

    public void Die() => _health.Die();
    
    void Update()
    {
        if (Player.IsDead) return;
        RemainingDistance = Mover.Distance;
        IsDead = _health.IsDead;
        _fsm.Update();
    }

    public void DestroyEnemy() => Destroy(this);
}
