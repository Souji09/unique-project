using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[System.Serializable]
public class Unit: MonoBehaviour
{
    public string  Unitname;
    public int Level;
    public int MaxHP;
    public int currentHP;
    public int Dame;
    public int Defend;
    public int Fait;
    public bool takeDame(int damg)
    {
        int dameDeal =  damg - Defend;
        if(dameDeal <= 1)
        {
            dameDeal = 1;
        }
        currentHP -= dameDeal;
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
