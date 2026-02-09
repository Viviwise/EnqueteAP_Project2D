using UnityEngine;
using UnityEngine.UI;

namespace Script.RomainScript.Books
{
    public class BookUI :  MonoBehaviour
    {
        [field: SerializeField] public BookType BookType { get; private set; }
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] public GameObject image001;
        [SerializeField] public GameObject image02;
        
        
        public void Open()
        {
            canvasGroup.alpha = 1;
            image001.SetActive(true);
            image02.SetActive(false);
            
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }

        public void Close()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        public void NextPage()
        {
            image001.SetActive(false);
            image02.SetActive(true);
        }

        public void PreviousPage()
        {
            image001.SetActive(true);
            image02.SetActive(false);
        }
    }
}