using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    private ItemPickable itemPickable;

    [SerializeField] private Camera cam;
    [SerializeField] private InventoryManager inventoryManager;

    /*private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                ItemPickable item = hit.collider.GetComponent<ItemPickable>();

                if (item != null)
                {
                    inventoryManager.ItemPicked(hit.collider.gameObject);
                }
            }
        }
    }*/
}
