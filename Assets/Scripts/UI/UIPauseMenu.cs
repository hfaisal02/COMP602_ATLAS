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
        if(gameCanvas.activeSelf)
        {
            gameCanvas.SetActive(false);
            PlayerData.menuActive = false;

            Time.timeScale = 1.0f;
        }
        else if(!PlayerData.menuActive)
        {
            gameCanvas.SetActive(true);
            PlayerData.menuActive = true;

            Time.timeScale = 0.0f;            
        }
    }
}
