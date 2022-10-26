using Pathfinding;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Enemy enemy;
    [HideInInspector] public AIDestinationSetter ds;
    [HideInInspector] public AIPath ap;

    public float playerDist;
    [HideInInspector] public bool active;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        ds = GetComponent<AIDestinationSetter>();
        ap = GetComponent<AIPath>();
    }
    
    void Start()
    {
        ds.target = GameObject.FindGameObjectWithTag("PlayerTransform").transform;
    }
    
    void Update()
    {
        ap.maxSpeed = enemy.moveSpeed;

        float dist = Vector2.Distance(transform.position, ds.target.position);

        if (dist <= playerDist)
        {
            active = true;
        }
    }
}
