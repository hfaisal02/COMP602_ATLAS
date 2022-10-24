using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        Transform playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerPos.position = transform.position;
        Destroy(gameObject);
    }
}
