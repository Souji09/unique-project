using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHanler
{
    private string DatadirPath = "";
    private string DataFileName = "";

    public FileDataHanler(string datadirPath, string dataFileName)
    {
        this.DatadirPath = datadirPath;
        this.DataFileName = dataFileName;
    }
    public DataGame Load()
    {
        string fullpath = Path.Combine(DatadirPath, DataFileName);
        DataGame loadData = null;
        if (File.Exists(fullpath))
        {
            try
            {
                string DataToLoad = "";
                using (FileStream stream = new FileStream(fullpath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        DataToLoad = reader.ReadToEnd();
                    }
                }
                loadData = JsonUtility.FromJson<DataGame>(DataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Loi xay ra khi co gang luu du lieu vao file: " + fullpath + "\n" + e);
            }
        }
        return loadData;
    }
    public void Save(DataGame data)
    {
        string fullpath = Path.Combine(DatadirPath, DataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

            string dataToStore = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception ex)
        {
            Debug.LogError("Loi xay ra khi co gang luu du lieu vao file: " + fullpath + "\n" + ex);
        }
    }
}
