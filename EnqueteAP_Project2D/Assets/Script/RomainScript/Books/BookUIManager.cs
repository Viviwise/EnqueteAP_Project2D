using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.RomainScript.Books
{
    public class BookUIManager : MonoBehaviour
    {
        [SerializeField] private BookUI[] booksUI;

        private BookUI currentOpenBook;

        public void OpenBook(BookType bookType)
        {
            foreach (var ui in booksUI)
            {
                if (ui.BookType == bookType)
                {
                    if (currentOpenBook == ui)
                    {
                        ui.Close();
                        currentOpenBook = null;
                        return;
                    }
                    
                    if (currentOpenBook != null)
                        currentOpenBook.Close();
                    
                    ui.Open();
                    currentOpenBook = ui;
                }
            }
        }
    }
}