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
        public override string ToString()
        {
            return highscore.ToString();
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
        int scoreRank = 6;
        if(scores[5].highscore < score){
            while (scores[scoreRank - 1].highscore < score){
                Debug.Log("Score is higher than position " + scoreRank.ToString());
                if(!(scoreRank >= scores.Length)){
                    scores[scoreRank] = scores[scoreRank - 1];
                }
                scoreRank--;
                if (scoreRank == 0){
                    break;
                }
            }
            scores[scoreRank] = new HighScore(score);  
        }

        updateScores();
        saveHighScores();
    }
    public HighScore[] loadHighScores(){
        HighScore[] myScores = (HighScore[]) HighScoreHandler.loadData(highScoreFileName);
        if (myScores == null){
            Debug.Log("Loaded null object");
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
