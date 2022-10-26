using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    [HideInInspector] public Enemy enemy;

    void Awake()
    {
        enemy = transform.parent.GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBehaviour player))
        {
            Debug.Log("collided with player!");
            player.TakeDamage(enemy.damage);
        }
    }
}
