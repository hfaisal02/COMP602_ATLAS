using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private float levelTimer;
    private bool startTimer;    
    public float survivalTimer;
    public GameObject teleporter;
    public Transform[] teleporterLocations;
    private bool active;

    void Start()
    {
        active = true;
        startTimer = true;
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
        Instantiate(teleporter, teleporterLocations[rand]);
        Debug.Log("Spawning Teleporter "+rand);
        
        active = false;
    }
}
