using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private Item _item;
    public int Money { get; private set; }
    public int Exp { get; private set; }

    public void Init(Item item, int money, int exp)
    {
        _item = item;
        Money = money;
        Exp = exp;
        Instantiate(_item.Prefab, transform.position, Quaternion.identity, transform);
    }

    public Item Collect()
    {
        Destroy(gameObject);
        return _item;
    }
}
