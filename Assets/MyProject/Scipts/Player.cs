using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] MotionScript _motion;
    [SerializeField] InputManager _input;
    [SerializeField] Attacker _attacker;
    [SerializeField] Health _health;
    PlayerConfig _config;
    [SerializeField] List<PlayerConfig> _configs;
    [SerializeField] LootPicker _picker;
    public PlayerInventory Inventory { get; private set; }
    public int Money { get; private set; } = 100;
    public bool IsDead { get; private set; }
    public Vector3 Position { get; private set; }

    void Awake()
    {
        _config = _configs[StaticData.SelectedConfig];
        _health.SetMaxHealth(_config.MaxHealth);
        _motion.SetSpeed(_config.Speed);
        _attacker.SetWeapon(_config.Weapon);
        Inventory = new PlayerInventory();
        Inventory.AddEquip(Slot.Weapon, _config.Weapon);
        _picker.OnItemPicked += OnItemPicked;
        Inventory.OnWeaponChanged += OnWeaponChanged;
    }

    private void OnWeaponChanged(Item item)
    {
        if (item is Weapon weapon) _attacker.SetWeapon(weapon);
    }

    void Start()
    {
        IsDead = _health.IsDead;
    }

    public void AddMoney(int newMoney)
    {
        Money += newMoney;
    }

    public void TakeMoney (int cost)
    {
        Money -= cost;
    }

    private void OnItemPicked(Item item)
    {
        Inventory.AddItem(item);
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
