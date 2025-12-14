using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using JetBrains.Annotations;
public class InventoryItemUI : MonoBehaviour, IPointerClickHandler
{
    //=============== ITEM DATA ===============\\

    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    [SerializeField] private int maxNumberOfItems;

    //=============== ITEM SLOT ===============\\
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    //=============== ITEM DESCRIPTION SLOT ===============\\
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;
    public bool thisItemSelected;
    public InventoryItemData Data;
    private InventoryItemData current;

    public event Action<InventoryItemData> OnItemSelected;


    public static int Length { get; private set; }
    public void SetItem(InventoryItemData itemPair, int quantity)
    {
        Data = itemPair;
        itemName = itemPair.itemName;
        itemSprite = itemPair.itemSprite;
        itemDescription = itemPair.itemDescription;
        itemImage.sprite = itemSprite;
        itemImage.gameObject.SetActive(true);
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        OnItemSelected?.Invoke(itemPair);
    }

    public void SetReferences(Image itemImage, TMP_Text description, TMP_Text name)
    {
        itemDescriptionImage = itemImage;
        itemDescriptionText = description;
        itemDescriptionNameText = name;

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }

        if (current != null)
        {
            current.Use();
        }


        else
        {
            Inventory.Instance.inventoryUI.DeselectAllSlots();
            thisItemSelected = true;
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
            if (itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = emptySprite;
            }
        } 
    }

    public void OnRightClick()
    {
        if (thisItemSelected)
        {

        }
    }

}
