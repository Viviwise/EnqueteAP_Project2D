using UnityEngine;
using UnityEngine.UI;

namespace Script.RomainScript.Books
{
    public class BookUI :  MonoBehaviour
    {
        [field: SerializeField] public BookType BookType { get; private set; }
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private PlaySoundEnter soundUsed;
        [SerializeField] private PlaySoundExit soundExit;

        [SerializeField] public GameObject image01;
        [SerializeField] public GameObject image02;
        
        
        public void Open()
        {
            canvasGroup.alpha = 1;
            image01.SetActive(true);
            image02.SetActive(false);
            
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            soundUsed.OnUsed(0);
        }

        public void Close()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        public void NextPage()
        {
            image01.SetActive(false);
            image02.SetActive(true);
        }

        public void PreviousPage()
        {
            image01.SetActive(true);
            image02.SetActive(false);
        }
    }
}