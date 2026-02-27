using UnityEngine;
using UnityEngine.EventSystems;


public class InfoCadaver : Interactable
{
    [SerializeField] public string blessureID;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ComparaisonManagerInGame.Instance.SelectPerson(this);
        Debug.Log("InfoCadaver activé");
    }
    
}