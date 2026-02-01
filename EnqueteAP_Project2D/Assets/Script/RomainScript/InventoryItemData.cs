using System;
using JetBrains.Annotations;
using Script.RomainScript.Books;
using UnityEngine;

[CreateAssetMenu(fileName = "Book", menuName = "BookItem")]
public class InventoryItemData : ScriptableObject
{

    public string itemName;
    public string itemDescription;
    public GameObject itemPrefab;

    public ItemType itemType;
    public BookType bookType;

    public Sprite itemSprite;
}