using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flasher : MonoBehaviour
{
    [SerializeField] int timesToFlash;
    [SerializeField] float timeBetweenFlash;
    [SerializeField] Color32 defaultTextColor;
    [SerializeField] Color32 flashColor1;
    [SerializeField] Color32 flashColor2;
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
        switch (++currentColor){
            case 1:
                Debug.Log("Flash to color 1");
                scoreboardText.color = flashColor1;
                break;
            case 2:
                Debug.Log("Flash to color 2");
                scoreboardText.color = flashColor2;
                break;
            default:
                Debug.Log("Flash to default color");
                scoreboardText.color = defaultTextColor;
                currentColor = 0;
                break;
        }
        if (++flashedTimes >= timesToFlash){
            isFlashing = false;
            scoreboardText.color = defaultTextColor;
        }
    }
    public void startFlasher()
    {
        currentColor = 0;
        timesToFlash = 0;
        isFlashing = true;
        flash();
    }
    public void changeColor(Color32 color){
        scoreboardText.color = new Color();
    }
}

