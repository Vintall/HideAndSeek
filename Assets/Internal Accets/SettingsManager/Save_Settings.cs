using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save_Settings : MonoBehaviour
{
    void Start()
    {
        
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/Settings.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/Settings.dat", FileMode.Open);
            bf.Serialize(file, GetComponent<Settings_Pointers>().settings);
            file.Close();
        }
        else
        {
            CreateDefault();
            FileStream file = File.Open(Application.persistentDataPath + "/Settings.dat", FileMode.Open);
            bf.Serialize(file, GetComponent<Settings_Pointers>().settings);
            file.Close();
        }

    }
    public void CreateDefault()
    {
        FileStream file = File.Open(Application.persistentDataPath + "/Settings.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, GetComponent<Settings_Pointers>().settings_default);
        file.Close();
    }
}
