using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Load_Settings : MonoBehaviour
{
    void Awake()
    {
        Load();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Settings.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Settings.dat", FileMode.Open);
            GetComponent<Settings_Pointers>().settings = (Settings)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("Create file settings");
            GetComponent<Save_Settings>().CreateDefault();
            Load();
        }
    }
    
}
