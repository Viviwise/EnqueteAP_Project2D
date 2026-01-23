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
    

  
    public override void OnHoverEnter()
    {
        base.OnHoverEnter();
        Debug.Log("Il y a " + nomBlessure +" sur " + lieuBlessure);
        blessureHover = true;
    }

    
    
    
  public void OnPointerClick(PointerEventData eventData)
{
    Report report = targetReport != null ? targetReport : Report.Instance;
    
    if (report != null)
    {
        report.AddInjury(this);
    }
    else
    {
        Debug.LogError("Aucun Report disponible !");
    }
}

}