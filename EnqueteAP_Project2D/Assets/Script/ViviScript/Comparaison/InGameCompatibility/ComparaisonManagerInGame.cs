using Script.Comparaison;
using UnityEngine;

public class ComparaisonManagerInGame : MonoBehaviour
{
    public static ComparaisonManagerInGame Instance;

    public CompatibilityDatabase database;

    private InfoCadaver selectedPerson;
    private InfoBook selectedInfo;
    
    public LineRenderer validationLine;
    
    private InfoCadaver previouslySelectedPerson;
    private InfoBook previouslySelectedInfo;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SelectPerson(InfoCadaver person)
    {
        selectedPerson = person;
            Debug.Log("Person selected: " + person.blessureID);
        TryCheckCompatibility();
    }

    public void SelectInfo(InfoBook info)
    {
        selectedInfo = info;
        Debug.Log("Info selected: " + info.category + " #" + info.infoNumber);
        TryCheckCompatibility();
    }

    private void TryCheckCompatibility()
    {
        if (selectedPerson == null || selectedInfo == null)
            return;

        if (selectedPerson == previouslySelectedPerson &&
            selectedInfo == previouslySelectedInfo)
        {
            HideValidationLine();

            selectedPerson = null;
            selectedInfo = null;

            previouslySelectedPerson = null;
            previouslySelectedInfo = null;

            Debug.Log("Sélection annulée");
            return;
        }

        var result = database.GetCompatibility(
            selectedPerson.blessureID,
            selectedInfo.category,
            selectedInfo.infoNumber
        );

        Debug.Log($"Compatibility = {result}");

        DrawValidationLine(
            selectedPerson.transform.position,
            selectedInfo.transform.position,
            result
        );

        previouslySelectedPerson = selectedPerson;
        previouslySelectedInfo = selectedInfo;
    }

    
    private void DrawValidationLine(Vector3 start, Vector3 end, Compatibility result)
    {
        if (validationLine == null) return;

        validationLine.gameObject.SetActive(true);
        validationLine.positionCount = 2;
        validationLine.SetPosition(0, start);
        validationLine.SetPosition(1, end);

        // Choix de couleur
        Color color = Color.white;
        if (result == Compatibility.Compatible) color = Color.green;
        else if (result == Compatibility.PartiallyCompatible) color = new Color(1f, 0.64f, 0f); // orange
        else if (result == Compatibility.Incompatible) color = Color.red;

        validationLine.startColor = color;
        validationLine.endColor = color;
    }

    private void HideValidationLine()
    {
        if (validationLine != null)
            validationLine.gameObject.SetActive(false);
        
        if (selectedPerson == previouslySelectedPerson && selectedInfo == previouslySelectedInfo)
        {
            HideValidationLine();
            selectedPerson = null;
            selectedInfo = null;
        }
       
    }
    

}
