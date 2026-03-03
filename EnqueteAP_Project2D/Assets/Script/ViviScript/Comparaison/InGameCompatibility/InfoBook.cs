using Script.Comparaison;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoBook : MonoBehaviour, IPointerClickHandler
{
    public Category category;
    public int infoNumber;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("InfoBook CLICKED");

        ComparaisonManagerInGame.Instance.SelectInfo(this);
    }
}