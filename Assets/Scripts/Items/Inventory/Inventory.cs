using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<Item, InventoryItem> itemDictionary = new Dictionary<Item, InventoryItem>();

    public static event HandleInventoryChange OnInventoryChange;
    public delegate void HandleInventoryChange(List<InventoryItem> inventory);

    private int maxCapacity = 25;

    private void OnEnable()
    {
        Consumable.OnConsumableCollected += Add;
    }

    private void OnDisable()
    {
        Consumable.OnConsumableCollected -= Add;
    }

    public void Add(Item item)
    {
        if(inventory.Count >= maxCapacity)
        {
            return;
        }

        if(itemDictionary.TryGetValue(item, out InventoryItem value))
        {
            value.AddToStack();
            Debug.Log("Added another" + value.item.itemName + "! Now total " + value.stackSize);
            OnInventoryChange?.Invoke(inventory);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(item);
            inventory.Add(newItem);
            itemDictionary.Add(item, newItem);
            Debug.Log("Added " + item.itemName + " for the first time!");
            OnInventoryChange?.Invoke(inventory);
        }

        FindObjectOfType<AudioManager>().PlayOneShot("Added Item");
    }

    public void Remove(Item item)
    {
        if (itemDictionary.TryGetValue(item, out InventoryItem value))
        {
            value.RemoveFromStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                itemDictionary.Remove(item);
            }
            OnInventoryChange?.Invoke(inventory);
        }
    }
}
