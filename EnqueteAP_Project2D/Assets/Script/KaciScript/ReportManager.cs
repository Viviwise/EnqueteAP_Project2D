using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.KaciScript
{
    public class ReportManager : MonoBehaviour
    {
        public static ReportManager instance;
        public GameObject reportPanel;
        public List<Button> reportButton = new List<Button>();
        private bool isActive; 

        private List<InjuryData> injuryExaminees = new List<InjuryData>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            InitializeButtons();
            UpdateReportDisplay(); 
        }

        private void InitializeButtons()
        {
            foreach (Button button in reportButton)
            {
                TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    Debug.Log("Bouton initialisé: " + button.name);
                    buttonText.text = ""; // Commence vide
                }
            }
        }

        public void AddInjuryData(InjuryData injuryData)
        {
            if (!injuryExaminees.Contains(injuryData))
            {
                injuryExaminees.Add(injuryData); 
                UpdateReportDisplay();
                Debug.Log($"Blessure ajoutée: {injuryData.injuryName}");
            }
            else
            {
                Debug.LogWarning("Cette blessure existe déjà dans le rapport");
            }
        }

        public void RemoveInjuryData(InjuryData injuryData)
        {
            if (injuryExaminees.Contains(injuryData))
            {
                injuryExaminees.Remove(injuryData);
                UpdateReportDisplay();
                Debug.Log($"Blessure retirée: {injuryData.injuryName}");
            }
        }

        public void UpdateReportDisplay()
        {
            for (int i = 0; i < injuryExaminees.Count; i++)
            {
                if (i < reportButton.Count && reportButton[i] != null)
                {
                    TextMeshProUGUI buttonText = reportButton[i].GetComponentInChildren<TextMeshProUGUI>();
                    if (buttonText != null)
                    {
                        buttonText.text = injuryExaminees[i].injuryName;
                    }
                }
            }

            for (int i = injuryExaminees.Count; i < reportButton.Count; i++)
            {
                if (reportButton[i] != null)
                {
                    TextMeshProUGUI buttonText = reportButton[i].GetComponentInChildren<TextMeshProUGUI>();
                    if (buttonText != null)
                    {
                        buttonText.text = "";
                    }
                }
            }
        }

        public void ToggleReportPanel()
        {
            if (reportPanel == null)
            {
                Debug.LogError("reportPanel n'est pas assigné !");
                return;
            }
            
            isActive = !isActive;
            reportPanel.SetActive(isActive);
            
            Debug.Log($"Panel rapport: {(isActive ? "Ouvert" : "Fermé")}");
        }

        public void OpenReportPanel()
        {
            if (reportPanel != null)
            {
                reportPanel.SetActive(true);
                isActive = true;
            }
        }

        public void CloseReportPanel()
        {
            if (reportPanel != null)
            {
                reportPanel.SetActive(false);
                isActive = false;
            }
        }
    }
}
