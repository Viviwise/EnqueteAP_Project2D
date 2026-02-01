using System.Collections.Generic;
using Script.EliasScript;
using Script.KaciScript;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inspection : Interactable , IPointerClickHandler, ISavedIntElement
{
    private const string SaveKey = "InjuryHover"; // clé de sauvegarde
    public Dictionary<string, int> SavedInts { get; private set; }
    
    
    [SerializeField] public string nomBlessure;
    [SerializeField] string lieuBlessure;
    private bool blessureHover = false;
    public Report targetReport;
    
    
  /*  public override void OnHoverEnter()
    {
        base.OnHoverEnter();
        Debug.Log("Il y a " + nomBlessure +" sur " + lieuBlessure);
        blessureHover = true;
    }
    */
  
  
  private void Awake()
  {
      SavedInts = new Dictionary<string, int>();
      blessureHover = SavedManager.LoadInt(SaveKey) == 1;
      
  }
    
  public void OnPointerClick(PointerEventData eventData)
{
    Report report = targetReport != null ? targetReport : Report.Instance;
    
    Debug.Log("Il y a " + nomBlessure +" sur " + lieuBlessure);
    blessureHover = true;
    
    if (report != null)
    {
        report.AddInjury(this);
    }
    else
    {
        Debug.LogError("Aucun Report disponible !");
    }
    
    int boolToInt = blessureHover ? 1 : -1;
    SavedInts[SaveKey] = boolToInt;
    this.Saved();
}


}