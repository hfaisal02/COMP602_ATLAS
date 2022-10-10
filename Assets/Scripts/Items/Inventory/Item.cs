using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public class Item : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    [TextArea(5, 10)]
    public string itemDescription;

    [Header("Stats")]
    public int price;

    [Header("Sprite")]
    public Sprite icon;
}
