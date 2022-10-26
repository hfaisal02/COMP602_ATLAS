using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    GameManager gm;

    float safetyTimer;
    public float startSafetyTimer;

    bool canTakeDamage;

    public SpriteRenderer sprite;
    Color c;

    public static event HandleHealthChanged OnHealthChanged;
    public delegate void HandleHealthChanged(int amount);

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        safetyTimer = 0;
        c = sprite.color;
    }
    
    void Update()
    {
        if(!canTakeDamage)
        {
            c.a = 0f;

            if(safetyTimer <= 0)
            {
                canTakeDamage = true;
            }
            else
            {
                safetyTimer -= Time.deltaTime;
            }
        }
        else
        {
            c.a = 255f;
        }
    }

    public void TakeDamage(int amount)
    {
        if(canTakeDamage)
        {
            OnHealthChanged?.Invoke(amount);

            safetyTimer = startSafetyTimer;
            canTakeDamage = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out EnemyHitBox e))
        {
            TakeDamage(e.enemy.damage);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out EnemyHitBox e))
        {
            TakeDamage(e.enemy.damage);
        }
    }
}
