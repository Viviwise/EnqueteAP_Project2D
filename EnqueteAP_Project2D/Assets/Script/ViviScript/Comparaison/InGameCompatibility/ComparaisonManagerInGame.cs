using Script.Comparaison;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ComparaisonManagerInGame : MonoBehaviour
{
    public static ComparaisonManagerInGame Instance;

    public CompatibilityDatabase database;

    private InfoCadaver selectedPerson;
    private InfoBook selectedInfo;

  
    public RectTransform canvasRect;
    public RectTransform linePrefab;
    private RectTransform currentLine;
    private List<RectTransform> segments = new List<RectTransform>();



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

        if (database == null)
        {
            Debug.LogError("DATABASE IS NULL");
            return;
        }

        var result = database.GetCompatibility(
            selectedPerson.blessureID,
            selectedInfo.category,
            selectedInfo.infoNumber
        );

        Debug.Log("RESULT FROM DATABASE = " + result);

        DrawValidationLineUI(
            selectedPerson.GetComponent<RectTransform>(),
            selectedInfo.GetComponent<RectTransform>(),
            result
        );

        previouslySelectedPerson = selectedPerson;
        previouslySelectedInfo = selectedInfo;
    }

    private void DrawValidationLineUI(RectTransform startRect, RectTransform endRect, Compatibility result)
    {
        if (linePrefab == null || canvasRect == null)
        {
            Debug.LogError("linePrefab or canvasRect is NULL");
            return;
        }

        foreach (var seg in segments)
            Destroy(seg.gameObject);
        segments.Clear();

        Vector2 screenStart = startRect.position;
        Vector2 screenEnd = endRect.position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenStart, null, out Vector2 localStart);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenEnd, null, out Vector2 localEnd);

        Vector2 midHorizontal = new Vector2(localEnd.x, localStart.y);

        CreateSegment(localStart, midHorizontal, result);

        CreateSegment(midHorizontal, new Vector2(midHorizontal.x, localEnd.y), result);

        CreateSegment(new Vector2(midHorizontal.x, localEnd.y), localEnd, result);
    }

    private void CreateSegment(Vector2 p1, Vector2 p2, Compatibility result)
    {
        RectTransform segment = Instantiate(linePrefab, canvasRect);
        segment.gameObject.SetActive(true);

        Vector2 dir = p2 - p1;
        float dist = dir.magnitude;

        segment.sizeDelta = new Vector2(dist, 4f);
        segment.anchoredPosition = p1 + dir * 0.5f;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        segment.rotation = Quaternion.Euler(0, 0, angle);

        var image = segment.GetComponent<Image>();
        if (image != null)
        {
            if (result == Compatibility.Compatible) image.color = Color.green;
            else if (result == Compatibility.Incompatible) image.color = Color.red;
            else image.color = Color.white;
        }

        segments.Add(segment);
    }

    private bool IsClickOnSelectable()
    {
        if (EventSystem.current == null)
            return false;

        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var result in results)
        {
            if (result.gameObject.GetComponent<InfoBook>() != null)
                return true;

            if (result.gameObject.GetComponent<InfoCadaver>() != null)
                return true;
        }

        return false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsClickOnSelectable())
                return;

            DeselectAll();
        }
    }

    private void DeselectAll()
    {
        selectedPerson = null;
        selectedInfo = null;
        previouslySelectedPerson = null;
        previouslySelectedInfo = null;

        HideValidationLine();
    }

    private void HideValidationLine()
    {
        foreach (var seg in segments)
        {
            if (seg != null)
                Destroy(seg.gameObject);
        }

        segments.Clear();

        if (currentLine != null)
            currentLine.gameObject.SetActive(false);
    }
}