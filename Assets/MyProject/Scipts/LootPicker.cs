using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPicker : MonoBehaviour
{
    public event Action<Item> OnItemPicked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Loot>(out var loot))
        {
            var item = loot.Collect();
            var player = gameObject.GetComponent<Player>();
            player.AddMoney(loot.Money);
            player.Experience.LevelUp(loot.Exp, player.Health);
            OnItemPicked?.Invoke(item);
        }
    }

}
