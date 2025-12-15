using Unity.VisualScripting;
using UnityEngine;

public class OpenClose_Inventory : MonoBehaviour
{
    
    [SerializeField] private CanvasGroup Page;
    
    public void OpenCloseUi()
    {
        Page.alpha = Page.alpha > 0 ? 0 : 1;
        Page.blocksRaycasts = Page.blocksRaycasts == true ? false : true;
    }
    
}