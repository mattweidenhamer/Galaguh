using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class HighScoreHandler
{

    public static void saveScore(System.Object score, string fileName){
        string fullPath = Application.persistentDataPath + "/" + fileName + ".bin";
        BinaryFormatter Formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(fullPath, FileMode.Create);
        Formatter.Serialize(fileStream, score);
        fileStream.Close();
        Debug.Log("Saved file successfully at " + fullPath);
    }
    public static object loadData(string fileName){
        string fullPath = Application.persistentDataPath + "/" + fileName + ".bin";
        if (File.Exists(fullPath)){
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fullPath, FileMode.Open);
            object score = Formatter.Deserialize(fileStream);
            fileStream.Close();
            Debug.Log("Loaded file successfully from " + fullPath);
            return score;
        }
        else {
            return null;
        }
    }
}