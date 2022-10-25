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

    //Acceptance Test 3
    void OnCollisionEnter2D(Collision2D collision) //a method that triggers on a collision between two game objects with collider components
    {
        Debug.Log("The projectile has collided"); //if the method is fired in the first place, it means a successfull collision has occured

        if(collision.gameObject.TryGetComponent(out Enemy enemy)) //check if the object the projectile collided with has an Enemy component
        {
            if(enemy) //check if the enemy was collided with is valid
            {
                Debug.Log("Collided with an enemy."); //print confirmation to the console
                enemy.TakeDamage(damage); //deal damage to the enemy on collision
            }
            else
            {
                Debug.Log("Invalid collision with enemy."); //print error message
            }            
        }
        else
        {
            Debug.Log("The projectile did not collide with an enemy, no damage was dealt.");
        }
        
        Destroy(gameObject); //if the projectile collides with any object, destroy it
        Debug.Log("The projectile was destroyed due to collision with " + collision.gameObject.name + "."); //print confirmation to the console
    }
}
