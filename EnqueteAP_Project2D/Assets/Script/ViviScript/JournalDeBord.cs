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
    
    [SerializeField] private Button journalButton;     
    [SerializeField] private GameObject journalPanel;  
    [SerializeField] private TMP_InputField noteInputField;  // <-- champ éditable

    public static JournalDeBord Instance;

    private bool journalOpen = false;

    
    //action dans le lancement du jeu 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        // bouton
        journalButton.onClick.AddListener(ToggleJournal);

        journalPanel.SetActive(false);
        noteInputField.gameObject.SetActive(false);
        
    }

    //ouverture du journal
    public void ToggleJournal()
    {
        journalOpen = !journalOpen;

        journalPanel.SetActive(true);
        noteInputField.gameObject.SetActive(true);

        if (journalOpen)
            noteInputField.ActivateInputField();
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
