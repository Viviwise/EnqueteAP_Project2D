using UnityEngine;
using UnityEngine.UI;

namespace Script.RomainScript.Books
{
    public class BookUIManager : MonoBehaviour
    {
        [SerializeField] private BookUI[] booksUI;
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private Button buttonReportEnd;

        private BookUI currentOpenBook;

        public bool IsBookOpen => currentOpenBook != null;

        public void OpenBook(BookType bookType)
        {
            // Si un livre est déjà ouvert -> on ne fait rien
            if (currentOpenBook != null)
                return;

            foreach (var ui in booksUI)
            {
                if (ui.BookType == bookType)
                {
                    ui.Open();
                    currentOpenBook = ui;
                    LockGameplay();
                    return;
                }
            }
        }

        public void CloseCurrentBook()
        {
            if (currentOpenBook == null)
                return;

            currentOpenBook.Close();
            currentOpenBook = null;

            UnlockGameplay();
        }

        private void LockGameplay()
        {
            if (inventoryManager != null)
                inventoryManager.enabled = false;

            ItemPickable[] items = FindObjectsByType<ItemPickable>(FindObjectsSortMode.None);
            foreach (var item in items)
                item.enabled = false;

            if (buttonReportEnd != null)
                buttonReportEnd.interactable = false;
        }

        private void UnlockGameplay()
        {
            if (inventoryManager != null)
                inventoryManager.enabled = true;

            ItemPickable[] items = FindObjectsByType<ItemPickable>(FindObjectsSortMode.None);
            foreach (var item in items)
                item.enabled = true;

            if (buttonReportEnd != null)
                buttonReportEnd.interactable = true;
        }
    }
}