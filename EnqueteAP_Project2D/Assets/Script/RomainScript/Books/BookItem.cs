using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

namespace Script.RomainScript.Books
{
    [RequireComponent(typeof(ItemPickable))]
    public class BookItem : MonoBehaviour //, IPointerClickHandler
    {
        public BookType BookType => pickable.itemData.bookType;
        
        private Camera cam;
        
        private BookUIManager uiManager;
        private ItemPickable pickable;
        
        private void Start()
        {
            pickable = GetComponent<ItemPickable>();
            cam = Camera.main;
            uiManager = Object.FindFirstObjectByType<BookUIManager>();
            
        }

        /*public void OnPointerClick(PointerEventData eventData)
        { //eventData.button = PointerEventData.InputButton.Right;
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("BookItem");
                if (uiManager != null)
                {
                    uiManager.OpenBook(BookType);
                }
            }
        }*/

        private void Update()
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

                RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

                if (hit.collider && hit.collider.gameObject == gameObject && uiManager)
                    uiManager.OpenBook(BookType);
            }
        }
    }
}