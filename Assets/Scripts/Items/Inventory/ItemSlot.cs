using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackText;

    public void ClearSlot()
    {
        icon.enabled = false;
        stackText.enabled = false;
    }

    public void EnableSlot()
    {
        icon.enabled = true;
        stackText.enabled = true;
    }

    public void DrawSlot(InventoryItem item)
    {
        if(item == null)
        {
            ClearSlot();
            return;
        }

        EnableSlot();

        icon.sprite = item.item.icon;
        stackText.text = item.stackSize.ToString();
    }
}
