using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] GameObject _inventory;

    public void OnEnable()
    {
        _button.onClick.AddListener(InventoryButtonClicked);
    }

    private void InventoryButtonClicked() => _inventory.SetActive(true);
}
