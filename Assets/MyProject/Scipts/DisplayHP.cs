using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayHP : MonoBehaviour
{
    [SerializeField] Player player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.GetMaxAndCurrentHP(out var currentHp, out var maxHp);
        var slider = gameObject.GetComponent<Slider>();
        slider.value = Mathf.Abs(currentHp / maxHp);
        slider.enabled = true;
        var tm = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        tm.text = $"{currentHp}/{maxHp}";
    }
}
