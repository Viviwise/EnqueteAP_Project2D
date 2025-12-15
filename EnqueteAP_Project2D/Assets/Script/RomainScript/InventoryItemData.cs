using System;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "Book", menuName = "BookItem")]
public class InventoryItemData : ScriptableObject
{

    public string itemName;
    public string itemDescription;

    public ItemType itemType;
    
    public Sprite itemSprite;

    public void Use()
    {
        switch
            (itemType)
        {
            case ItemType.Book:
                UseBook();
                break;
        }
    }

    public void UseBook()
    {
        Inventory.Instance.BookSlot.SetItem(this, Inventory.Instance.GetQuantity(this));
    }
}