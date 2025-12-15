using Unity.VisualScripting;
using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField] private InventoryItemData itemData;
    private CursorManager Instance;
    private bool onMouseDown;
    
    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
       
       Debug.Log("OnMouseDown");
        Book();
        
            
    }

    private void Book()
    {
        
        Collider2D col = GetComponent<Collider2D>();
          

        if (col == true && CompareTag("Book"))
        {
            Inventory.Instance.AddItem(itemData, 1);
            Destroy(gameObject);
            Debug.Log("Destroyed");
                    
        }

    }
}
