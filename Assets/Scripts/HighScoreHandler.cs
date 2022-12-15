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
    }
    public static object loadData(string fileName){
        string fullPath = Application.persistentDataPath + "/" + fileName + ".bin";
        if (File.Exists(fileName)){
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fullPath, FileMode.Open);
            object score = Formatter.Deserialize(fileStream);
            fileStream.Close();
            return score;
        }
        else {
            return null;
        }
    }
}