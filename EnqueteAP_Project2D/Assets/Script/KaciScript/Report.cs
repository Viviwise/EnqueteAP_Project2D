using System;
using System.Collections.Generic;
using System.Linq;
using Script.EliasScript;
using Script.EliasScript.SceneListeners;
using TMPro;
using UnityEngine;

namespace Script.KaciScript
{
    
    [Serializable]
    public class LineReportsSavedProperties : SavedProperty<List<LineReport>>
    {
        public LineReportsSavedProperties(string key, List<LineReport> value) : base(key, value)
        {
        }
    }
    
    
    
    public class Report : MonoBehaviour, IMonoSaveListenerComponent
    {
        //SAVE
        public const string ContentReport = "ContenuDuRapport";


        public string reportName = "Rapport 1";

        public Transform container;
        public GameObject prefabLine;
        public GameObject panelReport;

        public List<LineReport> lineReports = new List<LineReport>();
        private bool isReportVisible = false;
        public static Report Instance { get; private set; }

        //SAVE = écriture des données
        public void Write(List<ISavedProperty> properties)
        {
            properties.Add(new LineReportsSavedProperties(ContentReport, lineReports));
        }

        //SAVE = lecture des données
        public void Read(Dictionary<string, ISavedProperty> properties)
        {
            properties.TrySetValue(ContentReport, out lineReports);
        }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Debug.LogWarning("Il y a déjà une instance de Report !");
            }
        }


        public void AddInjury(Inspection inspection)
        {
            if (inspection == null)
            {
                Debug.LogError("Inspection est null !");
                return;
            }

            if (string.IsNullOrEmpty(inspection.nomBlessure))
            {
                Debug.LogWarning("L'inspection n'a pas de nom de blessure !");
                return;
            }

            if (container == null)
            {
                Debug.LogError("Container n'est pas assigné dans l'Inspector !");
                return;
            }

            if (prefabLine == null)
            {
                Debug.LogError("PrefabLine n'est pas assigné dans l'Inspector !");
                return;
            }

            string nomBlessure = inspection.nomBlessure;

            foreach (LineReport lineReport in lineReports)
            {
                if (lineReport != null && lineReport.GetInjury() != null)
                {
                    if (lineReport.GetInjury().nomBlessure == nomBlessure)
                    {
                        Debug.Log($"La blessure '{nomBlessure}' existe déjà dans le rapport.");
                        return;
                    }
                }
            }

            GameObject newLine = Instantiate(prefabLine, container);
            LineReport newLineReport = newLine.GetComponent<LineReport>();

            if (newLineReport != null)
            {
                newLineReport.Initialize(inspection);
                lineReports.Add(newLineReport);
                Debug.Log($"Blessure '{nomBlessure}' ajoutée au rapport.");
            }
            else
            {
                Debug.LogError("Le prefabLine n'a pas de composant LineReport !");
                Destroy(newLine);
            }
        }

        public void OpenReport()
        {
            if (Instance != null && Instance != this)
            {
                Instance.CloseReport();
            }

            isReportVisible = true;

            if (panelReport != null)
            {
                panelReport.SetActive(true);
            }
            else
            {
                Debug.LogError("PanelReport n'est pas assigné !");
            }

            Instance = this;
            Debug.Log($"{reportName} ouvert");
        }


        public void CloseReport()
        {
            isReportVisible = false;

            if (panelReport != null)
            {
                panelReport.SetActive(false);
            }

            if (Instance == this)
            {
                Instance = null;
            }

            Debug.Log($"{reportName} fermé");
        }
    }
}


/* CODE DE SAVE DE KACI => garde au cas ou
    public void SaveReportPlayerPref()
    {
        Debug.Log("=== DÉBUT SAUVEGARDE ===");

        if (lineReports == null || lineReports.Count == 0)
        {
            Debug.LogWarning("⚠La liste lineReports est vide !");
            return;
        }

        Debug.Log($"Nombre de lignes à sauvegarder : {lineReports.Count}");

        List<string> nomsBlessures = new List<string>();

        for (int i = 0; i < lineReports.Count; i++)
        {
            LineReport lineReport = lineReports[i];

            if (lineReport == null)
            {
                Debug.LogWarning($" Ligne {i} est null");
                continue;
            }

            Inspection injury = lineReport.GetInjury();

            if (injury == null)
            {
                Debug.LogWarning($" Ligne {i} n'a pas d'inspection");
                continue;
            }

            if (string.IsNullOrEmpty(injury.nomBlessure))
            {
                Debug.LogWarning($" Ligne {i} a une blessure sans nom");
                continue;
            }

            nomsBlessures.Add(injury.nomBlessure);
            Debug.Log($"  [{i}] Ajouté : {injury.nomBlessure}");
        }

        if (nomsBlessures.Count == 0)
        {
            Debug.LogWarning(" Aucune blessure valide à sauvegarder !");
            return;
        }

        string dataString = string.Join("|", nomsBlessures);

        PlayerPrefs.SetString("ReportData", dataString);
        PlayerPrefs.SetInt("InjuryCount", nomsBlessures.Count);
        PlayerPrefs.SetString("ReportName", reportName);
        PlayerPrefs.Save();

        Debug.Log($" SAUVEGARDE RÉUSSIE !");
        Debug.Log($"   Rapport : {reportName}");
        Debug.Log($"   Blessures : {nomsBlessures.Count}");
        Debug.Log($"   Données : {dataString}");
    }


    public void LoadReportPlayerPref()
    {
        if (!PlayerPrefs.HasKey("ReportData"))
        {
            Debug.LogWarning(" Aucune donnée sauvegardée trouvée !");
            return;
        }

        string dataString = PlayerPrefs.GetString("ReportData", "");
        int count = PlayerPrefs.GetInt("InjuryCount", 0);
        string savedReportName = PlayerPrefs.GetString("ReportName", "Rapport inconnu");

        Debug.Log($"   Rapport : {savedReportName}");
        Debug.Log($"   Nombre : {count}");
        Debug.Log($"   Données brutes : {dataString}");

        if (string.IsNullOrEmpty(dataString))
        {
            Debug.LogWarning("⚠Les données sont vides !");
            return;
        }

        string[] nomsBlessures = dataString.Split('|');

        Debug.Log($"CHARGEMENT RÉUSSI : {nomsBlessures.Length} blessures");

        foreach (string nom in nomsBlessures)
        {
            Debug.Log($"  • {nom}");
        }
    }*/
