using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] MotionScript _motion;
    [SerializeField] InputManager _input;
    [SerializeField] Attacker _attacker;
    [SerializeField] Health _health;
    PlayerConfig _config;
    [SerializeField] List<PlayerConfig> _configs;
    public bool IsDead { get; private set; }
    public Vector3 Position { get; private set; }

    void Awake()
    {
        _config = _configs[StaticData.SelectedConfig];
        _health.SetMaxHealth(_config.MaxHealth);
        _motion.SetSpeed(_config.Speed);
        _attacker.SetWeapon(_config.Weapon);
    }

    void Start()
    {
        IsDead = _health.IsDead;
    }

    // Update is called once per frame
    void Update()
    {
        Position = transform.position;
        IsDead = _health.IsDead;
        if (IsDead) _health.Die();
        if (_input.Attacking)
        {
            _attacker.Attack();
        }

        _motion.Move(_input.Motion);
    }

    public void GetMaxAndCurrentHP(out float currentHp, out float maxHp)
    {
        currentHp = _health.CurrentHealth;
        maxHp = _health.MaxHealth;
    }
}
