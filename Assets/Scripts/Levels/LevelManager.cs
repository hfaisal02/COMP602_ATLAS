using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    private float levelTimer;
    private bool startTimer;    
    public float survivalTimer;

    public GameObject teleporter;
    public Transform[] teleporterLocations;
    private bool active;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

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
        int rand = Random.Range(0, teleporterLocations.Length);
        Teleporter obj = Instantiate(teleporter, teleporterLocations[rand]).GetComponent<Teleporter>();
        active = false;
    }
}
