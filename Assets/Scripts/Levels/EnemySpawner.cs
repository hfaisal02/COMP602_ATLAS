using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameManager gm;

    public Transform[] spawnLocations;
    public GameObject[] enemies;

    public float spawnInterval;
    private float spawnTimer;
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        spawnTimer = 3f;
        spawnInterval -= gm.currentStage / 2;
        Debug.Log("enemy spawn interval for this level: " + spawnInterval);
    }
    
    void Update()
    {
        if(spawnTimer <= 0)
        {
            int randPos = Random.Range(0, spawnLocations.Length);
            int randEnemy = Random.Range(0, enemies.Length);

            Enemy newEnemy = Instantiate(enemies[randEnemy], spawnLocations[randPos].position, Quaternion.identity).GetComponent<Enemy>();

            newEnemy.maxHealth += gm.currentStage;
            newEnemy.moveSpeed += gm.currentStage;
            
            newEnemy.Setup();

            Debug.Log("enemy health: " + newEnemy.maxHealth);
            Debug.Log("enemy speed: " + newEnemy.moveSpeed);
            
            spawnTimer = spawnInterval;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
