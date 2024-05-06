using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxHealth;
    [SerializeField] private Animator _animator;
    public float MaxHealth {get { return _maxHealth; }}
    public float CurrentHealth { get; private set; }
    public bool IsDead { get; private set; } = false;
    
    void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (CurrentHealth >= _maxHealth) CurrentHealth -= damage;
        else CurrentHealth = 0;
        _animator.SetTrigger("Damaged");
        if (CurrentHealth <= 0) IsDead = true;
    }

    public void SetMaxHealth(float maxHealth) => _maxHealth = maxHealth;

    public void Die()
    {
        _animator.SetTrigger("Died");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}