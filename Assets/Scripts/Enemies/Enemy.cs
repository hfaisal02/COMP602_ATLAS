using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyDrops ed;

    private float health;
    public float maxHealth;
    public float moveSpeed;
    
    void Awake()
    {
        ed = GetComponent<EnemyDrops>();
    }

    public int damage;

    void Start()
    {
        health = maxHealth;
    }

    public void Setup()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            FindObjectOfType<AudioManager>().PlayOneShot("Explode");

            ed.DropLoot();
            Destroy(gameObject);
        }
    }
}
