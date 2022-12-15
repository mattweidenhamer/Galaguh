using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class HighScores : MonoBehaviour
{
    public class HighScore {
        public string username;
        public int highscore;
        public HighScore(String name, int score){
            username = name;
            highscore = score;
        }
    }

    public HighScore[] scores;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkHighScores(HighScore highScore){

    }
}
