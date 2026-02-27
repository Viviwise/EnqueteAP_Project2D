using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TogleReport : MonoBehaviour
{
    public TextMeshProUGUI organText;
    public Toggle bonEtatToggle;
    public Toggle mauvaisEtatToggle;

    public void Initialize(string organName)
    {
        organText.text = organName;

        bonEtatToggle.isOn = false;
        mauvaisEtatToggle.isOn = false;
    }

    public string GetEtat()
    {
        if (bonEtatToggle.isOn) return "Bon état";
        if (mauvaisEtatToggle.isOn) return "Mauvais état";
        return "Non renseigné";
    }
}
