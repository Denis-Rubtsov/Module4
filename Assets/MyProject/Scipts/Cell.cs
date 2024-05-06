using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    public event Action<Item> OnClicked;

    [SerializeField] private Image _icon;
    public Item _item;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked?.Invoke(_item);
    }

    public void RemoveItem()
    {
        _item = null;
        _icon.sprite = null;
        _icon.gameObject.SetActive(false);
    }

    public void SetItem(Item item)
    {
        _item = item;
        _icon.sprite = _item.Icon;
        _icon.gameObject.SetActive(true);
    }
}