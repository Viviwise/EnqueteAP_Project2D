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
            GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
            InventorySlot slot = clickedObject.GetComponent<InventorySlot>();
            
            if (slot != null && slot.heldItem != null)
            {
                draggedObject = slot.heldItem.gameObject;
                slot.heldItem = null;
                lastItemSlot = clickedObject;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (draggedObject != null && eventData.button == PointerEventData.InputButton.Left)
        { 
            GameObject pointerCurrentObject = eventData.pointerCurrentRaycast.gameObject;
            InventorySlot slot = null;
            bool isOverSlot = pointerCurrentObject && pointerCurrentObject.TryGetComponent(out slot);
            
            InventorySlot lastItemSlotComponent = lastItemSlot.GetComponent<InventorySlot>();
            InventoryItem inventoryItem = draggedObject.GetComponent<InventoryItem>();

            
            //No Items in the slots
            if (isOverSlot && slot.heldItem == null)
            {
                slot.SetHeldItem(inventoryItem);
                
                if(lastItemSlotComponent == slot)
                    bookUIManager.OpenBook(inventoryItem.itemData.bookType);
            }
            //Switch Items
            else
            {
                if  (isOverSlot && slot.heldItem != null)
                {
                    lastItemSlotComponent.SetHeldItem(slot.heldItem);
                    slot.SetHeldItem(inventoryItem);
                }
                //Return Item LastSlot
                else if (pointerCurrentObject.name != "Drop")
                {
                    lastItemSlotComponent.SetHeldItem(inventoryItem);
                    
                }
                //Drop
                else
                {
                    Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
                    position.z = 0f;

                    GameObject newItem = Instantiate(inventoryItem.itemData.itemPrefab, position, new Quaternion());
                    newItem.GetComponent<ItemPickable>().itemData = inventoryItem.itemData;

                    lastItemSlotComponent.heldItem = null;
                    Destroy(draggedObject);
                }
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
