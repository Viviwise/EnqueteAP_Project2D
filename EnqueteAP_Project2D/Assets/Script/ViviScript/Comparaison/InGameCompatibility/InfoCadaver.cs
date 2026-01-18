using UnityEngine;
using Script.Comparaison;

public class InfoCadaver : Interactable
{
    [SerializeField] public string blessureID;
    
    public override void OnClick()
    {
        ComparaisonManagerInGame.Instance.SelectPerson(this);
    }
    
}