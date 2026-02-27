using Script.Comparaison;

public class InfoBook : Interactable
{
    public Category category;
    public int infoNumber;
    
    public override void OnClick()
    {
        ComparaisonManagerInGame.Instance.SelectInfo(this);
    }

}