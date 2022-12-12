using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public int score = 0;
    [SerializeField] string scoreboardPreText;
    private TMP_Text scoreboardText;
    private Flasher attachedFlasher;
    [SerializeField] TMP_Text gameOverText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreboardText = GetComponent<TMP_Text>();
        scoreboardText.text = scoreboardPreText + score.ToString();
        attachedFlasher = GetComponent<Flasher>();
        attachedFlasher.startFlasher();
    }
    public void gainScore(int scoreGain){
        score += scoreGain;
        scoreboardText.text = scoreboardPreText + score.ToString();
        attachedFlasher.startFlasher();
    }
    public void defeated(){
        gameOverText.text = "High score: " + score.ToString();
    }

}
public class HighScoreEntry
{
    public string name;
    public int score;
}
