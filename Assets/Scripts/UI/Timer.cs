using UnityEngine;

//Author: Toryn
public class Timer : MonoBehaviour
{
    private bool runTimer = false;
    private bool gameRunningTest = true;

    void Update()
    {
        if(gameRunningTest == true)
        {
            TimerStart();

            if(runTimer)
            {
                PlayerData.playTime += Time.deltaTime;
                TimePlayed();
            }
        }
        else if(gameRunningTest == false)
        {
            StopTimer();
        }
    }

    public string TimePlayed()
    {
        int seconds = (int)(PlayerData.playTime % 60);
        int minutes = (int)(PlayerData.playTime / 60) % 60;
        int hours = (int)(PlayerData.playTime / 3600) % 24;

        string displayTime = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        return displayTime;
    }

    void TimerStart()
    {
        runTimer = true;
    }

    void StopTimer()
    {
        runTimer = false;
    }
}
