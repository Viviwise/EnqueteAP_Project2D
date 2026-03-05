using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryItem heldItem;
    public Color hoveredColor = Color.red;

    private Color originalColor;
    private Image imageRenderer;

    void Start()
    {
        imageRenderer = GetComponent<Image>();
        originalColor = imageRenderer.color;
    }

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (heldItem != null)
        {
            imageRenderer.color = hoveredColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageRenderer.color = originalColor;
    }
}