using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private DataGame gamedata;
   public static DataManager instance {  get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Tim thay nhieu hon mot trinh quan ly luu tru trong scene");
        }
        instance = this;
    }
    private void Start()
    {
        loadgame();
    }
    public void newgame()
    {
        this.gamedata = new DataGame();
    }
    public void loadgame()
    {
        if(this.gamedata == null)
        {
            Debug.Log("Khong tim thay du lieu");
            newgame();
        }
    }
    public void savegame()
    {

    }
    public void OnApplicationQuit()
    {
        savegame();
    }
}
