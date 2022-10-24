using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        if(target)
        {
            moveDir = (target.position - transform.position).normalized;
        }
    }

    void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * moveSpeed * Time.deltaTime;
        }
    }
}
