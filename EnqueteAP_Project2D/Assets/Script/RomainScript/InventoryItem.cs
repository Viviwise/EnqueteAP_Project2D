using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public InventoryItemData itemData;
    [SerializeField] private Image iconImage;

    void Update()
    {
        iconImage.sprite = itemData.itemSprite;
    }
}
