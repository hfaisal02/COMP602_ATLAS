using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            Destroy(player.transform.parent.gameObject);
            Cursor.visible = true;
        }
            
    }
}
