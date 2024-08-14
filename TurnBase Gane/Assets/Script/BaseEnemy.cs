using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseEnemy 
{
    public string name;

    public enum Type
    {
        Grass,
        Fire,
        Warter,
        electric
    }
    public enum Rarity
    {
        Common,
        rare,
        superrare,

    }
    public Type type;
    public Rarity rarity;
    public float BaseHp;
    public float currHp;

    public float BaseMP;
    public float currMP;

    public float BaseATK;
    public float currentATK;
    public float BaseDef;
    public float currDef;
}
