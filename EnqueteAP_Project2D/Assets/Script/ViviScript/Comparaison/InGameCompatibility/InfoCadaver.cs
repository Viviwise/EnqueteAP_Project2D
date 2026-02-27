using UnityEngine;
using UnityEngine.EventSystems;

public class InfoCadaver : MonoBehaviour, IPointerClickHandler
{
    public string blessureID;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("InfoCadaver CLICKED");

        ComparaisonManagerInGame.Instance.SelectPerson(this);
    }
}