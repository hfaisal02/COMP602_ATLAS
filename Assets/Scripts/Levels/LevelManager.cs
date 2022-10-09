using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float survivalTimer;
    public GameObject teleporter;
    public Transform[] teleporterLocations;
    private bool active;

    void Start()
    {
        active = true;
    }

    void Update()
    {
        if(PlayerData.playTime >= survivalTimer && active)
        {
            Debug.Log("The Player has survived for the required time.");
            SpawnTeleporter();
            active = false;
        }
        
        int rand = Random.Range(0, teleporterLocations.Length);
        Debug.Log("Spawning Teleporter "+rand);
    }

    void SpawnTeleporter()
    {
        int rand = Random.Range(0, teleporterLocations.Length);
        Instantiate(teleporter, teleporterLocations[rand]);
        Debug.Log("Spawning Teleporter "+rand);
    }
}
