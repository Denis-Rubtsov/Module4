using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : Window
{
    [SerializeField] Slider _hpSlider;
    [SerializeField] TextMeshProUGUI _hpText;
    [SerializeField] Slider _expSlider;
    [SerializeField] TextMeshProUGUI _expText;
    [SerializeField] TextMeshProUGUI _moneyCount;

    public override void Construct(Player player)
    {
        base.Construct(player);
        Debug.Log(player);
    }

    void Update()
    {
        DisplayHP();
        DisplayMoney();
        DisplayExp();
    }

    void DisplayHP()
    {
        _player.GetMaxAndCurrentHP(out var currentHp, out var maxHp);
        _hpSlider.value = Mathf.Abs(currentHp / maxHp);
        _hpSlider.enabled = true;
        _hpText.text = $"{currentHp}/{maxHp}";
    }
    void DisplayMoney()
    {
        _moneyCount.text = $"{_player.Money}";
    }

    void DisplayExp()
    {
        _expSlider.value = Mathf.Abs((float)(float)_player.Experience.ExpPoints) / Mathf.Pow(2, _player.Experience.Level);
        _expSlider.enabled = true;
        _expText.text = $"{_player.Experience.ExpPoints}/{(int)Mathf.Pow(2, _player.Experience.Level)}";
    }
}
