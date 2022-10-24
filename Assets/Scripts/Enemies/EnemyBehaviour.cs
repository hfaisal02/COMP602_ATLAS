using Pathfinding;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [HideInInspector] public AIDestinationSetter ds;
    [HideInInspector] public AIPath ap;

    public float playerDist;
    [HideInInspector] public bool active;

    void Awake()
    {
        ds = GetComponent<AIDestinationSetter>();
        ap = GetComponent<AIPath>();
    }
    
    void Start()
    {
        ds.target = GameObject.FindGameObjectWithTag("PlayerTransform").transform;
    }
    
    void Update()
    {
        float dist = Vector2.Distance(transform.position, ds.target.position);

        if (dist <= playerDist)
        {
            active = true;
        }
    }
}
