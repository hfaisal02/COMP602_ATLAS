using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyRanged : MonoBehaviour
{
    AIDestinationSetter ds;
    AIPath ap;

    public float playerDist;
    bool active;

    private float cooldown;
    public float startCooldown;
    //public GameObject projectile;

    void Awake()
    {
        ds = GetComponent<AIDestinationSetter>();
        ap = GetComponent<AIPath>();
        
    }

    void Start()
    {
        ds.target = GameObject.FindGameObjectWithTag("PlayerTransform").transform;
        playerDist = ap.slowdownDistance;
        cooldown = 0;
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, ds.target.position);

        if (dist <= playerDist)
        {
            active = true;
        }

        if (active)
        {
            if(cooldown <= 0)
            {
                //shoot projectile
                Debug.Log("shoot projectile");
                cooldown = startCooldown;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }
}
