using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalDeBord : MonoBehaviour
{
    [SerializeField] private Button journalButton;     
    [SerializeField] private GameObject journalPanel;  
    [SerializeField] private TMP_InputField noteInputField;  // <-- champ éditable

    public static JournalDeBord Instance;

    private bool journalOpen = false;

    private const string SaveKey = "JournalText"; // clé de sauvegarde

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

        // charger texte sauvegardé
        LoadJournal();

        journalPanel.SetActive(false);
        noteInputField.gameObject.SetActive(false);

        // sauvegarde à chaque changement de texte
        noteInputField.onValueChanged.AddListener(OnTextChanged);
    }

    public void ToggleJournal()
    {
        journalOpen = !journalOpen;

        journalPanel.SetActive(journalOpen);
        noteInputField.gameObject.SetActive(journalOpen);

        if (journalOpen)
            noteInputField.ActivateInputField();
    }

    private void OnTextChanged(string newValue)
    {
        PlayerPrefs.SetString(SaveKey, newValue);
        PlayerPrefs.Save();
    }

    private void LoadJournal()
    {
        if (PlayerPrefs.HasKey(SaveKey))
            noteInputField.text = PlayerPrefs.GetString(SaveKey);
        else
            noteInputField.text = "";
    }
}