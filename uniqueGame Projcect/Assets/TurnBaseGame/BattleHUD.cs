using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI level;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI defend;
    public Slider HPBar;

    public void SetHUD(Unit unit)
    {
        Name.text = unit.Unitname;
        level.text = $"Level: {1 + unit.Level}";
        attack.text = "Strength: " + unit.Dame.ToString();
        defend.text = "Defend: "+ unit.Defend.ToString();
        HPBar.maxValue = unit.MaxHP;
        HPBar.value = unit.currentHP;
    }
    public void SetHP(float hp)
    {
        HPBar.value = hp;
    }

}
