using System;
using System.Collections.Generic;
using Script.EliasScript;
using Script.EliasScript.SceneListeners;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ici besoin d'un script listener comme class
public class JournalDeBord : MonoSaveListener
{
    //SaveJournalState pas changer !!!!!!
    private const string SaveJournalState = "JournalText"; // clé de sauvegarde + valeur
    
    [SerializeField] private GameObject journalPanel;  
    [SerializeField] private TMP_InputField noteInputField;
    
    private bool journalOpen = false;

    void Awake()
    {
        journalPanel.SetActive(false);
        noteInputField.gameObject.SetActive(false);
    }

    public void ToggleJournal()
    {
        if (journalOpen)
        {
            journalPanel.SetActive(false);
            noteInputField.gameObject.SetActive(false);
        }
        else
        {
            journalPanel.SetActive(true);
            noteInputField.gameObject.SetActive(true);
            noteInputField.ActivateInputField();
        }

        journalOpen = !journalOpen;
    }
    
    
    //SAVE = écriture des données
    protected override void Write(List<ISavedProperty> properties)
    {
        properties.Add(new SavedStringProperty(SaveJournalState, noteInputField.text));
    }
    // SAVE = lecture des données
    protected override void Read(Dictionary<string, ISavedProperty> properties)
    {
        if(properties.TrySetValue(SaveJournalState, out string text))
            noteInputField.text = text;
    }
}
