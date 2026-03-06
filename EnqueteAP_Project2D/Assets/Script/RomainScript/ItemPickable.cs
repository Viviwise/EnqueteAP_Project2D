using Script.RomainScript.Books;
using UnityEngine;
using UnityEngine.EventSystems;
using Color = UnityEngine.Color;
using Image = UnityEngine.UI.Image;


public class ItemPickable : MonoBehaviour
{
    public InventoryItemData itemData;
    private GameObject bookSlot;
    private BookUIManager bookUIManager;

    [SerializeField] private Color originalColor;
    [SerializeField] private Color Color = Color.orange;
    private Image image;


    //=============ADDED FOR DRAG & DROP Pick================//
    private Vector3 startPosition;
    private Camera cam;
    private bool isDragging;

    private void Start()
    {
        cam = Camera.main;
        startPosition = transform.position;

        bookSlot = GameObject.FindWithTag("BookSlot");
        image = bookSlot.GetComponent<Image>();
        originalColor = image.color;

        bookUIManager = FindFirstObjectByType<BookUIManager>();

    }

    private void OnMouseDown()
    {
        if (bookUIManager != null && bookUIManager.IsBookOpen)
            return;

        isDragging = true;

        bookSlot.transform.localScale = new Vector3(1.3f, 1.3f, 0);
        image.color = Color;

        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (!isDragging)
            return;

        if (bookUIManager != null && bookUIManager.IsBookOpen)
            return;

        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;
        transform.position = mouseWorld;
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // Vérifie les UI sous la souris
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        bool slotFound = false;

        foreach (var result in results)
        {
            InventorySlot slot = result.gameObject.GetComponent<InventorySlot>();

            if (slot != null)
            {
                slotFound = true;

                // Slot vide → on ajoute l'objet
                if (slot.heldItem == null)
                {
                    InventoryManager inventory = FindFirstObjectByType<InventoryManager>();
                    inventory.AddItemToSlot(this.gameObject, slot);
                    return;
                }
                else
                {
                    // Slot plein → retour position initiale
                    transform.position = startPosition;
                    return;
                }
            }
        }

        // Si aucun slot trouvé → retour position initiale
        if (!slotFound)
        {
            transform.position = startPosition;
        }
    }
}
