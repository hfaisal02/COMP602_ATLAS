using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    private Vector3 dir;
    private float damage;

    public float lifeTime;
    public float moveSpeed;

    public void Setup(Vector3 dir, float damage)
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
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
        Debug.Log("collided");
    }
}
