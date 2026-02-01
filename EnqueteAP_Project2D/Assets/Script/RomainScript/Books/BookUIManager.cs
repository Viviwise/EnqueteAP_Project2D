using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.RomainScript.Books
{
    public class BookUIManager : MonoBehaviour
    {
        [SerializeField] private BookUI[] booksUI;

        public void OpenBook(BookType bookType)
        {
            foreach (var ui in booksUI)
            {
                if (ui.BookType == bookType)
                {
                    ui.Open();
                }
                else
                {
                    ui.Close();
                }
                    
            }
        }
    }
}