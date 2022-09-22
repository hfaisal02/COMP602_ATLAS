using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPauseMenu : MonoBehaviour
{
    public GameObject gameCanvas;
    private Timer timer;
    public TextMeshProUGUI timerText;

    void Start()
    {
        timer = GetComponent<Timer>();
    }

    void Update()
    {
        timerText.text = timer.TimePlayed();
    }

    public void Pause()
    {
        //pauseActive = true;
        if(gameCanvas.activeSelf)
        {
            gameCanvas.SetActive(false);

            Time.timeScale = 1.0f;
        }
        else
        {
            gameCanvas.SetActive(true);

            Time.timeScale = 0.0f;
        }
    }
}
