using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<ItemSlot> itemSlots = new List<ItemSlot>(25);

    public Inventory inventory;

    private void OnEnable()
    {
        Inventory.OnInventoryChange += DrawInventory;
        DrawInventory(inventory.inventory);
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawInventory;
    }

    private void Awake()
    {
        InitInventory();
    }

    void ResetInventory()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        itemSlots = new List<ItemSlot>(25);
    }

    void CreateItemSlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform);
        newSlot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        ItemSlot newSlotComponent = newSlot.GetComponent<ItemSlot>();
        newSlotComponent.ClearSlot();

        itemSlots.Add(newSlotComponent);
    }

    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();

        for (int i = 0; i < itemSlots.Capacity; i++)
        {
            CreateItemSlot();
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            itemSlots[i].DrawSlot(inventory[i]);
        }
    }

    void InitInventory()
    {
        for (int i = 0; i < itemSlots.Capacity; i++)
        {
            CreateItemSlot();
        }
    }
}
