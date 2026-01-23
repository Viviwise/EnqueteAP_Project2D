using Script.RomainScript.Books;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem heldItem;
    
    public void SetHeldItem(InventoryItem item)
    {
        heldItem = item;
        heldItem.transform.SetParent(transform);
        if (heldItem.transform is RectTransform rectTransform)
        {
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.localScale = Vector3.one;
            rectTransform.sizeDelta = Vector2.zero;
        }
    }
}