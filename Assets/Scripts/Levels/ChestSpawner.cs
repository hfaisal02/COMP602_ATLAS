using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    private GameManager gm;

    public GameObject chest;
    public Transform[] chestLocations;
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        SpawnChests();
    }

    void SpawnChests()
    {
        for (int i = 0; i < (1 + gm.currentStage); i++)
        {
            int rand = Random.Range(0, chestLocations.Length);

            Instantiate(chest, chestLocations[rand].position, Quaternion.identity);
        }
    }
}
