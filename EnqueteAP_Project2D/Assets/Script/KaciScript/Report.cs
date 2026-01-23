using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Script.KaciScript
{
    public class Report : MonoBehaviour
    {
        public string reportName = "Rapport 1"; 

        public Transform container;
        public GameObject prefabLine;
        public GameObject panelReport;

        public List<LineReport> lineReports = new List<LineReport>();
        private bool isReportVisible = false;
        public static Report Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this );
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
