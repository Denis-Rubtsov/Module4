using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    public event Action<Dictionary<Slot, Item>> OnEquipmentChanged;
    public event Action<List<Item>> OnInventoryChanged;
    public event Action<Item> OnWeaponChanged;

    public Dictionary<Slot, Item> Equipment { get; private set; }
    public List<Item> Inventory { get; private set; }

    public PlayerInventory()
    {
        Equipment = new Dictionary<Slot, Item>();
        Inventory = new List<Item>();
    }

    public PlayerInventory(List<Item> inventory, Dictionary<Slot, Item> equipment)
    {
        Inventory = inventory;
        Equipment = equipment;
    }

    public void AddEquip(Slot slot, Item item)
    {
        Equipment.Add(slot, item);
        OnEquipmentChanged?.Invoke(Equipment);
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
        OnInventoryChanged?.Invoke(Inventory);
    }

    public void SwapItem(Item item)
    {
        RemoveEquipment(item.Slot);
        RemoveItem(item);
        AddEquip(item.Slot, item);
        if (item.Slot == Slot.Weapon) OnWeaponChanged?.Invoke(item);
    }

    private void RemoveEquipment(Slot slot)
    {
        AddItem(Equipment[slot]);
        Equipment.Remove(slot);
    }

    public bool RemoveItem(Item item)
    {
        if (Inventory.Contains(item))
        {
            Inventory.Remove(item);
            return true;
        }
        return false;
    }
}
