using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius;
    private bool inRange;

    private GameObject player;  
    private PlayerInputHandler inputHandler;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inputHandler = player.GetComponent<PlayerInputHandler>();
    }

    void Update()
    {
        if(inRange)
        {
            if(inputHandler.interactInput)
            {
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with "+transform.name+".");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);        
    }
}
