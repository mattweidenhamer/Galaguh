using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    [Serializable]
    public class HighScore {

        public int highscore;
        public HighScore(int score){
            highscore = score;
        }
    }
    [SerializeField] string highScoreFileName;
    public HighScore[] scores;
    [SerializeField] TMP_Text[] scoreDisplays;
    void Start()
    {
        scores = loadHighScores();
        if(PlayerPrefs.HasKey("Score")){
            Debug.Log("Found a score");
            checkIfHighScore(PlayerPrefs.GetInt("Score"));
            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.Save();
        }
        updateScores();
    }
    public void checkIfHighScore(int score){
        int indexHigherThan = 0;
        foreach(HighScore highScore in scores){
            if(score > highScore.highscore){
                indexHigherThan++;
            }
        }
        
        if(indexHigherThan > 0){
            for (int i = 5; i < 6 - indexHigherThan && i > 0; i--){
                scores[i] = scores[i - 1];
            }
            scores[6 - indexHigherThan] = new HighScore(score);
            updateScores();
            saveHighScores();
        }
    }
    public HighScore[] loadHighScores(){
        HighScore[] myScores = (HighScore[]) HighScoreHandler.loadData(highScoreFileName);
        if (myScores == null){
            myScores = new HighScore[6];
        }
        for (int i = 0; i < 6; i++ ){
            if (myScores[i] == null){
                myScores[i] = new HighScore(0);
            }
        }
        return myScores;
    }
    public void saveHighScores(){
        HighScoreHandler.saveScore(scores, highScoreFileName);
    }
    public void updateScores(){
        for (int i = 0; i < 6; i++){
            scoreDisplays[i].text =  scores[i].highscore.ToString("000000");
        }
    }
}
