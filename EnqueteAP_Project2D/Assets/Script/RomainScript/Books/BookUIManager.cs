using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.RomainScript.Books
{
    public class BookUIManager : MonoBehaviour
    {
        [SerializeField] private BookUI[] booksUI;

        private BookUI currentOpenBook;
        
        //=============Close Book if clicked elsewhere============//

        /* private void Update()
        {
            if (currentOpenBook == null)
                return;
            
            if (Input.GetMouseButtonDown(0))
            {
                // Vérifie si on clique sur une UI
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    GameObject clicked = EventSystem.current.currentSelectedGameObject;

                    // Elément du livre → Not Close
                    if (clicked != null && clicked.transform.IsChildOf(currentOpenBook.transform))
                        return;
                }
                
                CloseCurrentBook();
            }
        }*/
        
        //=========================//

        public void OpenBook(BookType bookType)
        {
            foreach (var ui in booksUI)
            {
                if (ui.BookType == bookType)
                {
                    if (currentOpenBook == ui)
                        return;

                    if (currentOpenBook != null)
                        currentOpenBook.Close();

                    ui.Open();
                    currentOpenBook = ui;
                    return;
                }
            }
        }

        private void CloseCurrentBook()
        {
            if (currentOpenBook != null)
            {
                currentOpenBook.Close();
                currentOpenBook = null;
            }
        }
    }
}