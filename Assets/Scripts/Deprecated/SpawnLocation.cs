using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = this.gameObject.transform.position;
    }
}
