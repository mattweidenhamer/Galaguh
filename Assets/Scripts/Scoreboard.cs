using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        scoreboardText.text = scoreboardPreText + formatString(score.ToString());
        attachedFlasher = GetComponent<Flasher>();
    }
    public void gainScore(int scoreGain){
        score += scoreGain;
        scoreboardText.text = scoreboardPreText + formatString(score.ToString());
        attachedFlasher.startFlasher();
    }
    
    public void defeated(){
        gameOverText.text = "High score: " + formatString(score.ToString());
        gameOverText.GetComponent<Flasher>().startFlasher();
        StartCoroutine(exitBackToMenu());
        
    }
    public string formatString(string stringToFormat){
        return string.Format("{0:000000}", stringToFormat);
    }
    IEnumerator exitBackToMenu()
    {
        Debug.Log("Preparing to exit to menu.");
        print(Time.timeScale.ToString());
        yield return new WaitForSecondsRealtime(5f);
        Debug.Log("Done waiting, exiting to menu.");
        SceneManager.LoadScene("HighScoreScene", LoadSceneMode.Single);
    }
}