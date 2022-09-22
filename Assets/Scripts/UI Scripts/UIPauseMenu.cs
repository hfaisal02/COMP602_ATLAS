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
        
    }
}
