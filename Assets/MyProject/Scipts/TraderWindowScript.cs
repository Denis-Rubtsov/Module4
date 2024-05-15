using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderWindowScript : Window
{
    [SerializeField] List<Cell> _inventory;
    [SerializeField] TraderScript _trader;

    public override void Construct(Player player)
    {
        base.Construct(player);
        foreach (Cell cell in _inventory)
        {
            cell.OnClicked += CellOnClicked;
        }
        SetupInventory(_trader.Inventory.Inventory);
    }

    private void CellOnClicked(Item item)
    {
        if (_trader.Inventory.RemoveItem(item))
        {
            _player.TakeMoney(item.Cost);
            _player.Inventory.AddItem(item);
        }
        SetupInventory(_trader.Inventory.Inventory);
    }

    void Update()
    {
        SetupInventory(_trader.Inventory.Inventory);
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
