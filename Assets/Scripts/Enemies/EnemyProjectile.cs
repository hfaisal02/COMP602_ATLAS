using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Vector3 dir;
    private int damage;

    public float lifeTime;
    public float moveSpeed;

    public void Setup(Vector3 dir, int damage)
    {
        this.dir = dir;
        this.damage = damage;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        Vector3 temp = transform.position;
        temp += dir * moveSpeed * Time.fixedDeltaTime;
        transform.position = temp;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBehaviour player))
        {
            Debug.Log("projectile collided with the player.");
            player.TakeDamage(damage);
        }
        Debug.Log("e proj deleted.");
        Destroy(gameObject);
    }
}
