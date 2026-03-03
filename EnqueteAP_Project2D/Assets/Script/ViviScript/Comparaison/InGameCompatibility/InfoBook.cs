using Script.Comparaison;

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