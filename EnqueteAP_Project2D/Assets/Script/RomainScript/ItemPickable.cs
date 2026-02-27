using UnityEngine;
using UnityEngine.EventSystems;


public class ItemPickable : MonoBehaviour
{
    public InventoryItemData itemData;
    public GameObject bookSlot;
    
        //=============ADDED FOR DRAG & DROP Pick================//
    private Vector3 startPosition;
    private Camera cam;
    private bool isDragging;

    private void Start()
    {
        cam = Camera.main;
        startPosition = transform.position;

    }

    private void OnMouseDown()
    {
        if (isDragging = true)
        {
            bookSlot.transform.localScale = new Vector3(1.3f, 1.3f , 0);
        }
        
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;
        transform.position = mouseWorld;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        bookSlot.transform.localScale = new Vector3(1, 1, 0);

        // Vérife
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var result in results)
        {
            InventorySlot slot = result.gameObject.GetComponent<InventorySlot>();

            if (slot != null && slot.heldItem == null)
            {
                InventoryManager inventory = FindFirstObjectByType<InventoryManager>();
                inventory.AddItemToSlot(this.gameObject, slot);
                return;
            }
        }

        // Si non slot -> position initiale
        transform.position = startPosition;
    }
}
