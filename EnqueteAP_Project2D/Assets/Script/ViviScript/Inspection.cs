
using UnityEngine;

public class Inspection : Interactable
{
    [SerializeField] string nomBlessure;
    [SerializeField] string lieuBlessure;

    public override void OnHoverEnter()
    {
        base.OnHoverEnter();
        Debug.Log("Il y a " + nomBlessure +" sur " + lieuBlessure);
    }

    public override void OnClick()
    {
        Debug.Log("Noté");
    }

}