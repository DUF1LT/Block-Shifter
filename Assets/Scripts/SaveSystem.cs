using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    private static string _dirPath = Application.dataPath;
    private static string _filePath = _dirPath + "/GameSettings.dat";


    public static bool IsSaveExists()
    {
        return File.Exists(_filePath);
    }

    public static void SaveGame(GameSettings gameSettings)
    {
        //if (!Directory.Exists(_dirPath))
        //{
        //    Debug.Log("Creating Directory");
        //    Directory.CreateDirectory(_dirPath);
        //}

        //Opening filestream to serialize GameSetting into the binary file
        using (FileStream stream = new FileStream(_filePath, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(stream, gameSettings);
            }
            catch (SerializationException e)
            {
                Debug.Log("Failed to serialize. Reason: " + e.Message);
                throw;
            }
        }
    }

    public static GameSettings LoadGame()
    {
        //Opening filestream to deserialize GameSetting into the binary file
        using (FileStream stream = new FileStream(_filePath, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            GameSettings gameSettings;
            try
            {
                gameSettings = (GameSettings)formatter.Deserialize(stream);
            }
            catch (SerializationException e)
            {
                Debug.Log("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            return gameSettings;
        }
    }
}
