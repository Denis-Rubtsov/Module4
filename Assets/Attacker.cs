using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] LayerMask _attackMask;
    [SerializeField] Vector3 _weaponRange;
    [field: SerializeField] public Weapon Weapon { get; private set; }
    Collider[] _hits = new Collider[5];
    float _attackTimer;
    public float Range {get { return Weapon.Range; }}

    void Start() => _attackTimer = Weapon.AttackCooldown;

    public void Attack()
    {
        if (_attackTimer <= 0)
        {
            AnimateAttack();
            DamageEnemies();
            _attackTimer = Weapon.AttackCooldown;
        }
    }

    private void DamageEnemies()
    {
        var count = Physics.OverlapSphereNonAlloc(transform.position, Weapon.Range, _hits, _attackMask); 
        for (int i = 0; i < count; i++)
        {
            if (_hits[i].TryGetComponent<Health>(out var health)) health.TakeDamage(Weapon.Damage);
        }
    }

    void AnimateAttack() => _animator.SetTrigger("Attack");

    // Update is called once per frame
    void Update()
    {
        _attackTimer -= Time.deltaTime;
        
    }
}
