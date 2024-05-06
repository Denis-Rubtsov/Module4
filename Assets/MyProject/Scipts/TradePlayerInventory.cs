using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradePlayerInventory : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] List<Cell> _inventory;
    [SerializeField] TraderScript _trader;

    void Start()
    {
        foreach (Cell cell in _inventory)
        {
            cell.OnClicked += CellOnClicked;
        }
        SetupInventory(_player.Inventory.Inventory);
    }

    private void CellOnClicked(Item item)
    {
        if(_player.Inventory.RemoveItem(item))
        {
            _player.AddMoney(item.Cost);
            _trader.Inventory.AddItem(item);
        }
        SetupInventory(_player.Inventory.Inventory);
    }

    void Update()
    {
        SetupInventory(_player.Inventory.Inventory);
    }

    private void SetupInventory(List<Item> list)
    {
        foreach (var cell in _inventory)
        {
            cell.RemoveItem();
        }

        for (int i = 0; i < list.Count; i++)
        {
            _inventory[i].SetItem(list[i]);
        }
    }
}
