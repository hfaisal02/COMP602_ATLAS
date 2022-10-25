using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevel : MonoBehaviour
{
    GameManager gm;
    LevelManager lm;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI surviveText;
    public TextMeshProUGUI goalText;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        if(!lm)
        {
            lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        }

        if(lm)
        {
            if(gm.currentStage != 5)
            {
                levelText.text = "[LEVEL " + gm.currentStage + "]";

                timerText.text = "Time Elapsed: " + lm.LevelTimerConverted();
                surviveText.text = "Survive For: " + lm.SurvivalTimerConverted();

                if (lm.active)
                {
                    goalText.text = "Survive until the teleporter arrives.";
                }
                else
                {
                    goalText.text = "<s>Survive until the Teleporter arrives.</s>\nFind and go through the Teleporter.";
                }
            }
            else
            {
                levelText.text = "[FINAL LEVEL]";

                timerText.text = "Time Elapsed: " + lm.LevelTimerConverted();
                surviveText.text = "";

                goalText.text = "Defeat the Minotaur.";
            }
        } 
    }

    public void BossDefeated()
    {
        goalText.text = "<s>Defeat the Minotaur.</s>\nMinotaur Defeated!";
    }
}
