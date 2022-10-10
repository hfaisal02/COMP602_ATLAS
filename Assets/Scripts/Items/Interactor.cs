using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private bool inRange;
    private Interactable interactable;

    private void Update()
    {
        if (interactable != null && inRange && InputManager.interactInput)
        {
            interactable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = collision.GetComponent<Interactable>();

        if (interactable != null)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = collision.GetComponent<Interactable>();

        if (interactable != null)
        {
            interactable = null;
            inRange = false;
        }
    }
}
