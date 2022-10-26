using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPrompt : MonoBehaviour
{
    public static event HandleInteractPrompt DisplayInteractPrompt;
    public delegate void HandleInteractPrompt();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            InvokeEvent();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InvokeEvent();
        }
    }

    public void InvokeEvent()
    {
        DisplayInteractPrompt?.Invoke();
    }
}
