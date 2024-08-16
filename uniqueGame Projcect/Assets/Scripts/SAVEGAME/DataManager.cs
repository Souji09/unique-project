using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private DataGame gamedata;

    private List<IDataPersistence> dataPersistenceObject;

    private FileDataHanler dataHanler;
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
        this.dataHanler = new FileDataHanler(Application.persistentDataPath, fileName);
        this.dataPersistenceObject = FindAllDataPersistenceObjects();
        loadgame();
    }
    public void newgame()
    {
        this.gamedata = new DataGame();
    }
    public void loadgame()
    {
        this.gamedata = dataHanler.Load();
        if(this.gamedata == null)
        {
            Debug.Log("Khong tim thay du lieu");
            newgame();
        }
        foreach(IDataPersistence dataPersistenceObj  in dataPersistenceObject)
        {
            dataPersistenceObj.LoadData(gamedata);
        }
    }
    public void savegame()
    {
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObject)
        {
            dataPersistenceObj.SaveData(ref gamedata);
        }
        dataHanler.Save(gamedata);
    }
    public void OnApplicationQuit()
    {
        savegame();
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObject = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObject);
    }
}
