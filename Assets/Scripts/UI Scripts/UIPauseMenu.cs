using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPauseMenu : MonoBehaviour
{
    public GameObject gameCanvas;
    private Timer timer;
    public TextMeshProUGUI timerText;



    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.TimePlayed();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameCanvas.SetActive(true);
        }
    }
}
