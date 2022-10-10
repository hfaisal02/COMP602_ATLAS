using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour, Interactable
{
    public Item item;

    public static event HandleConsumableCollected OnConsumableCollected;
    public delegate void HandleConsumableCollected(Item item);

    public void Interact()
    {
        OnConsumableCollected?.Invoke(item);
        Destroy(gameObject);
    }
}
