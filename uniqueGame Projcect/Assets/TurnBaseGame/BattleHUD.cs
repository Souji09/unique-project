using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI level;
    public Slider HPBar;
    void Start()
    {
        
    }
    public void SetHUD(Unit unit)
    {
        Name.text = unit.Unitname;
        level.text = $"Level {1 + unit.Level}";
        HPBar.maxValue = unit.MaxHP;
        HPBar.value = unit.currentHP;
    }
    public void SetHP(float hp)
    {
        HPBar.value = hp;
    }

}
