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
            username = name.Substring(0,3).ToUpper();
            highscore = score;
        }
    }
    [SerializeField] string highScoreFileName;

    public HighScore[] scores;
    // Start is called before the first frame update
    void Start()
    {
        scores = loadHighScores();
    }
    public void checkIfHighScore(HighScore highScore){

    }
    public HighScore[] loadHighScores(){

        HighScore[] myScores = (HighScore[]) HighScoreHandler.loadData(highScoreFileName);
        if (myScores == null){
            myScores = new HighScore[6];
        }
        for (int i = 0; i < 5; i++ ){
            if (myScores[i] == null){
                myScores[i] = new HighScore("NOV", 0);
            }
        }
        return myScores;
    }
    public void saveHighScores(){
        HighScoreHandler.saveScore(scores, highScoreFileName);
    }
}
