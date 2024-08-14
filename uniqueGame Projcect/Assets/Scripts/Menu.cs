using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OnNewGame()
    {
        DataManager.instance.newgame();
    }
    public void OnLoadGame()
    {
        DataManager.instance.loadgame();
    }
    public void OnSaveGame()
    {
        DataManager.instance.savegame();
    }
}
