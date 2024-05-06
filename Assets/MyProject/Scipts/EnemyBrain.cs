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
    [SerializeField] EnemyConfig _config;
    [SerializeField] Loot _loot;

    Item _lootItem;

    public float RemainingDistance { get; private set; }
    public bool IsDead { get; private set; }
    FSM _fsm;

    void Start()
    {
        _fsm = new(this);
        _health.SetMaxHealth(_config.MaxHealth);
        Attacker.SetWeapon(_config.Weapon);
        _lootItem = _config.Weapon;
    }

    public void Die() => _health.Die();
    
    void Update()
    {
        if (Player.IsDead) return;
        RemainingDistance = Mover.Distance;
        IsDead = _health.IsDead;
        _fsm.Update();
    }

    public void SpawnLoot()
    {
        if (_lootItem == null) return;

        Loot loot = Instantiate(_loot, transform.position, Quaternion.identity);
        loot.Init(_lootItem);
    }

    public void DestroyEnemy() => Destroy(this);
}
