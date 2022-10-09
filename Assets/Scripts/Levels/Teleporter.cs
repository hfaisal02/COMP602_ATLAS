using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("The Player has collided with the teleporter.");
        }
        else
        {
            Debug.Log("Another object has collided with the teleporter.");
        }
    }
}
