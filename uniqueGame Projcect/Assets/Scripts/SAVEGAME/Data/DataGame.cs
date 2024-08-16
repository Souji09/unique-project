using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataGame
{
    //Xac dinh nhung du lieu can luu 
    public Vector3 playerPosition;

    public Dictionary<string, bool> Checkpiont;
    public DataGame()
    {
        playerPosition = Vector3.zero;
        Checkpiont = new Dictionary<string, bool>();
    }
}
