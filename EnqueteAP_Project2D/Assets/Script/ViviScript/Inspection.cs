using UnityEngine;

public class Inspection : Interactable
{
    [SerializeField] string nomBlessure;
    [SerializeField] string lieuBlessure;
    private bool blessureHover = false;
    
    [SerializeField] GameObject colliderComparaison;

    void Start()
    {
        colliderComparaison.SetActive(false);
    }
    public override void OnHoverEnter()
    {
        base.OnHoverEnter();
        Debug.Log("Il y a " + nomBlessure +" sur " + lieuBlessure);
        blessureHover = true;
        ShowColCOmparaison();
    }

    public void ShowColCOmparaison()
    {
        if (blessureHover)
        {
            colliderComparaison.SetActive(true);
        }
    }
    
}