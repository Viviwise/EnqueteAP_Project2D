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
        Debug.Log("=== TryCheckCompatibility CALLED ===");

        if (selectedPerson == null)
        {
            Debug.Log("selectedPerson is NULL");
            return;
        }

        if (selectedInfo == null)
        {
            Debug.Log("selectedInfo is NULL");
            return;
        }

        Debug.Log("Person = " + selectedPerson.blessureID);
        Debug.Log("Category = " + selectedInfo.category);
        Debug.Log("InfoNumber = " + selectedInfo.infoNumber);

        if (database == null)
        {
            Debug.LogError("DATABASE IS NULL");
            return;
        }

        Debug.Log("Database entries count = " + database.entries.Count);

        var result = database.GetCompatibility(
            selectedPerson.blessureID,
            selectedInfo.category,
            selectedInfo.infoNumber
        );

        Debug.Log("RESULT FROM DATABASE = " + result);

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
        validationLine.positionCount = 3;

        Vector3 mid = new Vector3(end.x, start.y, start.z);

        
        Vector3 p0 = Camera.main.ScreenToWorldPoint(start);
        p0.z = 0;
        validationLine.SetPosition(0, p0);
        
        Vector3 p1 = Camera.main.ScreenToWorldPoint(mid);
        p1.z = 0;
        validationLine.SetPosition(1, p1);

        Vector3 p2 = Camera.main.ScreenToWorldPoint(end);
        p2.z = 0;
        validationLine.SetPosition(2, p2);

        Color color = Color.white;
        if (result == Compatibility.Compatible) color = Color.green;
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
