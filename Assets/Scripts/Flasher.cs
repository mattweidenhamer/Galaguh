using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flasher : MonoBehaviour
{
    [SerializeField] int timesToFlash;
    [SerializeField] float timeBetweenFlash;
    [SerializeField] Color32 defaultTextColor;
    [SerializeField] Color32[] flashColors;
    private int currentColor = 0;
    private int flashedTimes = 0;
    private float timeSinceLastFlash = 0f;
    private bool isFlashing = false;
    private TMP_Text scoreboardText;
    // Start is called before the first frame update
    void Start()
    {
        scoreboardText = GetComponent<TMP_Text>();
        scoreboardText.color = defaultTextColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlashing){
            timeSinceLastFlash += Time.deltaTime;
            if(timeSinceLastFlash >= timeBetweenFlash){
                flash();
            }
        }
    }
    public void flash()
    {
        timeSinceLastFlash = 0f;
        if(++currentColor >= flashColors.Length){
            currentColor = 0;
        }
        scoreboardText.color = flashColors[currentColor];
        if (++flashedTimes >= timesToFlash){
            Debug.Log(flashedTimes.ToString());
            isFlashing = false;
            scoreboardText.color = defaultTextColor;
        }
    }
    public void startFlasher()
    {
        currentColor = 0;
        flashedTimes = 0;
        isFlashing = true;
        flash();
    }
}

