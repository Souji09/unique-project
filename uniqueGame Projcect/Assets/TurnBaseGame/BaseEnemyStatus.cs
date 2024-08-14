using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyStatus 
{
    public string name;
    public string Max_HP;
    public float Max_DEF;

    public float curr_HP;
    public float curr_DEF;
    public enum EnemyType
    {
        normal,
        rare,
        Boss
    }
}
