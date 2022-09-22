using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Author: Toryn
public class Timer : MonoBehaviour
{
    private float playTime = 0.0f;
    private bool runTimer = false;

    //Test Variable
    private bool gameRunningTest = true;

    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameRunningTest == true)
        {
            TimerStart();

            if(runTimer)
            {
                playTime += Time.deltaTime;
                TimePlayed();
            }
        }
        else if(gameRunningTest == false)
        {
            StopTimer();
        }

        timerText.text = TimePlayed();
    }

    string TimePlayed()
    {
        int seconds = (int)(playTime % 60);
        int minutes = (int)(playTime / 60) % 60;
        int hours = (int)(playTime / 3600) % 24;

        string displayTime = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        return displayTime;

        //Debug.Log(displayTime);
    }

    void TimerStart()
    {
        runTimer = true;
        //Test code
        //Debug.Log("Timer is running...");
    }

    void StopTimer()
    {
        runTimer = false;
        ////Test code
        Debug.Log("Timer is stopped..");
    }
}
