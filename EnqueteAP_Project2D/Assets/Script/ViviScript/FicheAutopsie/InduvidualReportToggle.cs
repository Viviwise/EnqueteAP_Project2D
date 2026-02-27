using UnityEngine;

public class InduvidualReportToggle : MonoBehaviour
{
    public GameObject linePrefab;
    public Transform contentParent;
    public GameObject reportPanel;


    string[] organes = { "Foie", "Coeur", "Poumon", "Estomac", "Trachée", "Peau", "Rate", "Bouche" };

    void Start()
    {
        if (reportPanel != null)
            reportPanel.SetActive(false); 
        foreach (string organe in organes)
        {
            GameObject line = Instantiate(linePrefab, contentParent);

            TogleReport report = line.GetComponent<TogleReport>();
            
            report.Initialize(organe);
        }
    }

    public void ToggleReport()
    {
        if (reportPanel != null)
            reportPanel.SetActive(!reportPanel.activeSelf);
    }
    
}
