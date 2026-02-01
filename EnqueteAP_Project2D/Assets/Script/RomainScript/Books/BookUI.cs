using UnityEngine;

namespace Script.RomainScript.Books
{
    public class BookUI :  MonoBehaviour
    {
        [field: SerializeField] public BookType BookType { get; private set; }
        [SerializeField] private CanvasGroup canvasGroup;
    
        public void Open()
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }

        public void Close()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }
}