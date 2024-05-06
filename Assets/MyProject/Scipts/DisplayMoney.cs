using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{_player.Money}";
    }
}
