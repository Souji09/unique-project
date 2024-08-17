using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Unit: MonoBehaviour
{
    public string  Unitname;
    public int Level;
    public float MaxHP;
    public float currentHP;
    public int Dame;
    public int Defend;
    public bool takeDame(int damg)
    {
        currentHP -= damg;
        if(currentHP <=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void heal(int amount)
    {
        currentHP += amount;
        if(currentHP > MaxHP)
        {
            currentHP = MaxHP;
        }
    }
}
