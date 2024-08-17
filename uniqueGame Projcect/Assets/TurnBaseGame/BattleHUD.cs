using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text Name;
    public Text level;
    public Text attack;
    public Text defend;
    public Text Fait;

    public Slider HPBar;

    public void SetHUD(Unit unit)
    {
        Name.text = unit.Unitname;
        level.text = $"Level: {1 + unit.Level}";
        attack.text = "Strength: " + unit.Dame.ToString();
        defend.text = "Defend: "+ unit.Defend.ToString();
        Fait.text = "Fait: "+unit.Fait.ToString();
        HPBar.maxValue = unit.MaxHP;
        HPBar.value = unit.currentHP;
    }
    public IEnumerator SetHP(float hp)
    {
        float elapsedTime = 0f;
        float duration = 0.5f; 
        float startingHP = HPBar.value;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            HPBar.value = Mathf.Lerp(startingHP, hp, elapsedTime / duration);
            yield return null;
        }
        HPBar.value = hp; 
    }



}
