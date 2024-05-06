using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderScript : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] GameObject _tradeWindow;
    public PlayerInventory Inventory;

    void Start()
    {
        Inventory = new();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= 2.25 && Input.GetKeyDown(KeyCode.E)) _tradeWindow.SetActive(true);
    }
}
