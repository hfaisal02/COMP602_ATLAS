using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    [HideInInspector] public float levelTimer;
    private bool startTimer;    
    public float survivalTimer;

    public GameObject teleporter;
    public Transform[] teleporterLocations;
    [HideInInspector] public bool active;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.health = gameManager.maxHealth;

        active = true;
        startTimer = true;

        survivalTimer *= gameManager.currentStage;
    }

    void Update()
    {        
        if(startTimer)
        {
            levelTimer += Time.deltaTime;
        }

        if(levelTimer >= survivalTimer && active)
        {
            Debug.Log("The Player has survived for the required time.");
            SpawnTeleporter();
        }
    }

    void SpawnTeleporter()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("Teleporter");
        int rand = Random.Range(0, teleporterLocations.Length);
        Teleporter obj = Instantiate(teleporter, teleporterLocations[rand]).GetComponent<Teleporter>();
        active = false;
    }

    public string LevelTimerConverted()
    {
        int seconds = (int)(levelTimer % 60);
        int minutes = (int)(levelTimer / 60) % 60;

        string displayTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        return displayTime;
    }

    public string SurvivalTimerConverted()
    {
        int seconds = (int)(survivalTimer % 60);
        int minutes = (int)(survivalTimer / 60) % 60;

        string displayTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        return displayTime;
    }
}
