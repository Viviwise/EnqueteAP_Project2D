using System.Collections.Generic;
using Script.EliasScript;
using Script.EliasScript.SceneListeners;
using Script.KaciScript;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inspection : Interactable, IPointerClickHandler, IMonoSaveListenerComponent
{
    //SaveKey pas changer !!!!!!
    private const string SaveKey = "InspectionSaving"; // clé de sauvegarde
    
    
    [SerializeField] public string nomBlessure;
    [SerializeField] string lieuBlessure;
    private bool blessureHover = false;
    public Report targetReport;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        Report report = targetReport != null ? targetReport : Report.Instance;

        Debug.Log("Il y a " + nomBlessure + " sur " + lieuBlessure);
        blessureHover = true;

        if (report != null)
        {
            report.AddInjury(this);
        }
        else
        {
            Debug.LogError("Aucun Report disponible !");
        } 
    }


    //SAVE = écriture des données
    void IMonoSaveListenerComponent.Write(List<ISavedProperty> properties)
    {
        properties.Add(new SavedBoolProperty(SaveKey, blessureHover));
        
        properties.Add(new SavedStringProperty(SaveKey, nomBlessure));
    }

    // SAVE = lecture des données
    void IMonoSaveListenerComponent.Read(Dictionary<string, ISavedProperty> properties)
    {
        /*
        if (properties.TryGetValue(SaveKey, out ISavedProperty property))
            property.TrySetValue(out blessureHover, false);
        */
        properties.TrySetValue(SaveKey, out blessureHover);
        
        properties.TrySetValue(SaveKey, out nomBlessure);
    }
}