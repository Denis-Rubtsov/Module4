using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] LayerMask _attackMask;
    [SerializeField] float _range;
    [SerializeField] Vector3 _weaponRange;
    [SerializeField] float _damage;
    [SerializeField] float _attackCooldown;
    Collider[] _hits = new Collider[5];
    float _attackTimer;
    public float Range {get { return _range; }}

    void Start() => _attackTimer = _attackCooldown;

    public void Attack()
    {
        if (_attackTimer <= 0)
        {
            AnimateAttack();
            DamageEnemies();
            _attackTimer = _attackCooldown;
        }
    }

    private void DamageEnemies()
    {
        var count = Physics.OverlapSphereNonAlloc(transform.position, _range, _hits, _attackMask); 
        for (int i = 0; i < count; i++)
        {
            if (_hits[i].TryGetComponent<Health>(out var health)) health.TakeDamage(_damage);
        }
    }

    void AnimateAttack() => _animator.SetTrigger("Attack");

    // Update is called once per frame
    void Update()
    {
        _attackTimer -= Time.deltaTime;
        
    }
}
