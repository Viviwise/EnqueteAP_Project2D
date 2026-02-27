using UnityEngine;

public class ButtonOpenBook : MonoBehaviour
{
   [SerializeField] private GameObject book;
   private bool isOpen = false;

   void Start()
   {
      book.SetActive(false);
      isOpen = false;
   }

   public void OpenBook()
   {
      isOpen = !isOpen;
      book.SetActive(isOpen);
   }
}
