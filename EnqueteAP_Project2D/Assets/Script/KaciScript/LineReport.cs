using TMPro;
using UnityEngine;

public class LineReport : MonoBehaviour
{
    private Inspection injury;
    public TextMeshProUGUI displayText;

    void Awake()
    {
        displayText = GetComponentInChildren<TextMeshProUGUI>();
        
        if (displayText == null)
        {
            Debug.LogError("Aucun TextMeshProUGUI trouvé dans LineReport !");
        }
    }

    public void Initialize(Inspection inspection)
    {
        if (inspection == null)
        {
            Debug.LogError("Inspection null !");
            return;
        }

        this.injury = inspection;
        
        if (displayText != null)
        {
            displayText.text = inspection.nomBlessure;
            Debug.Log($"Blessure ajoutée : {inspection.nomBlessure}");
        }
    }

    public Inspection GetInjury()
    {
        return injury;
    }
}