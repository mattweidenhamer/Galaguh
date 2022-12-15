using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    public int score = 0;
    public static string stringFormat = "000000";
    [SerializeField] string scoreboardPreText;
    [SerializeField] TMP_Text gameOverText;
    private TMP_Text scoreboardText;
    private Flasher attachedFlasher;

    
    // Start is called before the first frame update
    void Start()
    {
        scoreboardText = GetComponent<TMP_Text>();
        scoreboardText.text = scoreboardPreText + score.ToString(stringFormat);
        attachedFlasher = GetComponent<Flasher>();
    }
    public void gainScore(int scoreGain){
        score += scoreGain;
        scoreboardText.text = scoreboardPreText + score.ToString(stringFormat);
        attachedFlasher.startFlasher();
    }
    
    public void defeated(){
        gameOverText.text = "High score: " + score.ToString(stringFormat);
        gameOverText.GetComponent<Flasher>().startFlasher();
        StartCoroutine(exitBackToMenu());
        
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