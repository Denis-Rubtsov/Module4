using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartUpStartLocation : GameStartUpScript
{
    [SerializeField] protected TraderScript _trader;

    void Start()
    {
        CreatePlayer();
        _trader.Construct(_player);
        foreach (var w in _windows)
        {
            if (w is HUD hud) hud.Construct(_player);
            if (w is InventoryWindow inventory) inventory.Construct(_player);
            if (w is TradePlayerInventory trade) trade.Construct(_player);
            if (w is TraderWindowScript traderInventory) traderInventory.Construct(_player);
        }
        _exit.Construct(_player);
        _pauseMenu.Construct(_saveService);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) _pauseMenu.gameObject.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        _saveService.SaveAll();
    }
}
