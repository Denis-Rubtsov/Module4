using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : MonoBehaviour, ISaveLoadEntity<PlayerSaveData>
{
    [SerializeField] MotionScript _motion;
    [SerializeField] InputManager _input;
    [SerializeField] Attacker _attacker;
    [field:SerializeField] public Health Health { get; private set; }
    PlayerConfig _config;
    [SerializeField] List<PlayerConfig> _configs;
    [SerializeField] LootPicker _picker;
    public PlayerInventory Inventory { get; private set; }
    public int Money { get; private set; } = 100;
    public bool IsDead { get; private set; }
    public Vector3 Position { get; private set; }
    SaveService _saveService;
    public Experience Experience { get; private set; }

    public void Construct(Camera camera, SaveService saveService)
    {
        var data = Restore();
        _saveService = saveService;
        _config = _configs[StaticData.SelectedConfig];
        if (Health == null) Debug.Log("Health почему-то null");

        if (data == null)
        {
            Health.Construct(_config.MaxHealth);
            Money = 100;
            Experience = new(0, 1);
        }
        else
        {
            if (data.Level != 0 && data.Exp != 0) this.Experience = new(data.Exp, data.Level);
            else Experience = new(0, 1);
            if (data.Health.Max != 0 && data.Health.Current != 0) Health.Construct(data.Health.Max, data.Health.Current);
            else Health.Construct(_config.MaxHealth);
            Money = data.Money;
        }

        _motion.Construct(camera, _config.Speed);
        _attacker.SetWeapon(_config.Weapon);

        Inventory = new PlayerInventory();
        Inventory.AddEquip(Slot.Weapon, _config.Weapon);
        _picker.OnItemPicked += OnItemPicked;
        Inventory.OnWeaponChanged += OnWeaponChanged;
        IsDead = Health.IsDead;
        _saveService.AddEntity(this);
    }

    private void OnWeaponChanged(Item item)
    {
        if (item is Weapon weapon) _attacker.SetWeapon(weapon);
    }

    public void AddMoney(int newMoney)
    {
        Money += newMoney;
    }

    public void TakeMoney(int cost)
    {
        Money -= cost;
    }

    private void OnItemPicked(Item item)
    {
        Inventory.AddItem(item);
    }

    void Update()
    {
        Position = transform.position;
        IsDead = Health.IsDead;
        if (IsDead) Health.Die();
        if (_input.Attacking)
        {
            _attacker.Attack();
        }

        if (Input.GetKeyDown(KeyCode.H)) Health.Heal();
        if (Input.GetKeyDown(KeyCode.G)) DoNothing();

        _motion.Move(_input.Motion);
    }

    private void DoNothing()
    {
        return;
    }

    public void GetMaxAndCurrentHP(out float currentHp, out float maxHp)
    {
        currentHp = Health.CurrentHealth;
        maxHp = Health.MaxHealth;
    }

    public void Save()
    {
        PlayerSaveData saveData = new PlayerSaveData
        {
            Exp = Experience.ExpPoints,
            Money = this.Money,
            Level = Experience.Level,
            Health = new PlayerHealthData
            {
                Current = Health.CurrentHealth,
                Max = Health.MaxHealth
            }
        };

        string data = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("Player", data);
    }

    public PlayerSaveData Restore()
    {
        if (PlayerPrefs.HasKey("Player"))
        {
            string json = PlayerPrefs.GetString("Player");
            return JsonUtility.FromJson<PlayerSaveData>(json);
        }
        else
        {
            return null;
        }
    }
}

[Serializable]
public class PlayerSaveData : SaveData
{
    public int Exp;
    public int Level;
    public int Money;
    public PlayerHealthData Health;
}

[Serializable]
public struct PlayerHealthData
{
    public float Current;
    public float Max;
}