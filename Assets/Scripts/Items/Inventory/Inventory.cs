using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<Item, InventoryItem> itemDictionary = new Dictionary<Item, InventoryItem>();

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
        if(itemDictionary.TryGetValue(item, out InventoryItem value))
        {
            value.AddToStack();
            Debug.Log("Added another" + value.item.itemName + "! Now total " + value.stackSize);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(item);
            inventory.Add(newItem);
            itemDictionary.Add(item, newItem);
            Debug.Log("Added " + item.itemName + " for the first time!");
        }
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
        }
    }
}
