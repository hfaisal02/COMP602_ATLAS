using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyRanged : MonoBehaviour
{
    Enemy enemy;

    AIDestinationSetter ds;
    AIPath ap;

    public float playerDist;
    bool active;

    private float cooldown;
    public float startCooldown;

    public GameObject projectile;
    //Transform playerPos;

    void Awake()
    {
        enemy = GetComponent<Enemy>();

        ds = GetComponent<AIDestinationSetter>();
        ap = GetComponent<AIPath>();
        
    }

    void Start()
    {
        //playerPos = GameObject.FindGameObjectWithTag("PlayerTransform").transform;
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
                Vector3 projDir = (ds.target.position - transform.position).normalized;

                var proj = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<EnemyProjectile>();
                proj.Setup(projDir, enemy.damage);

                cooldown = startCooldown;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }
}
