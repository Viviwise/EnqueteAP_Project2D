using Script.KaciScript;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inspection : Interactable , IPointerClickHandler 
{
    [SerializeField] public string nomBlessure;
    [SerializeField] string lieuBlessure;
    private bool blessureHover = false;
    public Report targetReport;
    
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
    
    
  public void OnPointerClick(PointerEventData eventData)
{
    Report report = targetReport != null ? targetReport : Report.Instance;
    
    if (report != null)
    {
        report.AddInjury(this);
        DialogueManager.instance.OpenDialoguePanel();
    }
    else
    {
        Debug.LogError("Aucun Report disponible !");
    }
}

}