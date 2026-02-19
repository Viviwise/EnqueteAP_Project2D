using System.Security.Cryptography;
using Script.RomainScript.Books;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class InventoryManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private GameObject[] slots =  new GameObject[3];
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Camera cam;
    [FormerlySerializedAs("uiManager")] [SerializeField]
    private BookUIManager bookUIManager;

    [SerializeField] private GameObject deskTop;
    
    GameObject draggedObject;
    GameObject lastItemSlot;
    
    void Update()
    {
        if (draggedObject != null)
        {
            draggedObject.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameObject clickedObject = null;

            // PRIORITÉ UI
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                clickedObject = eventData.pointerCurrentRaycast.gameObject;
            }
            else
            {
                // PHYSICS 2D
                Vector2 worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                if (hit.collider != null)
                    clickedObject = hit.collider.gameObject;
            }

            if (clickedObject != null)
            {
                InventorySlot slot = clickedObject.GetComponent<InventorySlot>();
                
                if (slot != null && slot.heldItem != null)
                {
                    draggedObject = slot.heldItem.gameObject;
                    slot.heldItem = null;
                    lastItemSlot = clickedObject;
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (draggedObject != null && eventData.button == PointerEventData.InputButton.Left)
        { 
            GameObject pointerCurrentObject = null;

            // PRIORITÉ UI
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                pointerCurrentObject = eventData.pointerCurrentRaycast.gameObject;
            }
            else
            {
                // PHYSICS 2D
                Vector2 worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                if (hit.collider != null)
                    pointerCurrentObject = hit.collider.gameObject;
            }

            InventorySlot slot = null;
            bool isOverSlot = pointerCurrentObject && pointerCurrentObject.TryGetComponent(out slot);
            
            InventorySlot lastItemSlotComponent = lastItemSlot.GetComponent<InventorySlot>();
            InventoryItem inventoryItem = draggedObject.GetComponent<InventoryItem>();
            
            
            // No Items in the slots
            if (isOverSlot && slot.heldItem == null)
            {
                slot.SetHeldItem(inventoryItem);
                
                if(lastItemSlotComponent == slot)
                    bookUIManager.OpenBook(inventoryItem.itemData.bookType);
            }
            // Switch Items
            else
            {
                if  (isOverSlot && slot.heldItem != null)
                {
                    lastItemSlotComponent.SetHeldItem(slot.heldItem);
                    slot.SetHeldItem(inventoryItem);
                }
                // Return Item LastSlot
                else if (pointerCurrentObject != deskTop)
                {
                    lastItemSlotComponent.SetHeldItem(inventoryItem);
                }
                // Drop
                else
                {
                    Debug.Log("1");

                    Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
                    position.z = 0f;

                    GameObject newItem = Instantiate(inventoryItem.itemData.itemPrefab, position, Quaternion.identity);
                    newItem.GetComponent<ItemPickable>().itemData = inventoryItem.itemData;

                    lastItemSlotComponent.heldItem = null;
                    Destroy(draggedObject);
                }

                Debug.Log("2");
            }

            draggedObject = null;
        }
    }

    public void ItemPicked(GameObject pickedItem)
    {
        GameObject emptySlot = null;
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i].GetComponent<InventorySlot>();

            if (slot.heldItem == null)
            {
                emptySlot = slots[i];
                break;
            }
        }
        
        if (emptySlot && emptySlot.TryGetComponent(out InventorySlot inventorySlot))
        {
            GameObject newItem = Instantiate(itemPrefab);
            InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
            inventoryItem.itemData = pickedItem.GetComponent<ItemPickable>().itemData;

            inventorySlot.SetHeldItem(inventoryItem);
            Destroy(pickedItem);
        }
    }
}

