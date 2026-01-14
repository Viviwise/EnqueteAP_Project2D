using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.KaciScript
{
    public class Report : MonoBehaviour
    {
        // ❌ SUPPRIMÉ : public static Report Instance;

        [Header("Identification")]
        public string reportName = "Rapport 1";  // ✅ NOUVEAU : Nom du rapport

        [Header("UI Configuration")]
        public Transform container;
        public GameObject prefabLine;
        public Button buttonValidate;
        public TextMeshProUGUI result;
        public GameObject panelReport;
        
        [Header("Solution correcte")]
        public List<InjuryID> correctInjuryIds;
        
        [Header("État actuel")]
        private List<LineReport> lineReports = new List<LineReport>();
        private bool isReportVisible = false;

        private void Awake()
        {
            Debug.Log($"✅ {reportName} créé");
        }

        private void Start()
        {
            if (buttonValidate != null)
            {
                buttonValidate.onClick.AddListener(() => ValidateReport());
            }

            Debug.Log($" {reportName} - Solution attendue :");
            foreach (InjuryID id in correctInjuryIds)
            {
                Debug.Log($"  - {id}");
            }
        }

        public bool ValidateReport()
        {
            Debug.Log($"=== VALIDATION DE {reportName} ===");
            
            int correctAnswers = 0;
            int wrongAnswers = 0;
            int missedInjuries = 0;

            foreach (LineReport lineReport in lineReports)
            {
                InjuryID injuryId = lineReport.GetInjury().injuryid;
                bool playerMarkedCorrect = lineReport.IsMarkedCorrect();
                bool isActuallyCorrect = correctInjuryIds.Contains(injuryId);

                Debug.Log($" {lineReport.GetInjury().injuryname}");
                Debug.Log($" Joueur: {(playerMarkedCorrect ? "✓" : "✗")} | Réalité: {(isActuallyCorrect ? "✓" : "✗")}");

                if (playerMarkedCorrect && isActuallyCorrect)
                {
                    correctAnswers++;
                }
                else if (playerMarkedCorrect && !isActuallyCorrect)
                {
                    wrongAnswers++;
                }
            }

            foreach (InjuryID correctId in correctInjuryIds)
            {
                bool foundAndChecked = lineReports.Any(lr => 
                    lr.GetInjury().injuryid == correctId && lr.IsMarkedCorrect());

                if (!foundAndChecked)
                {
                    missedInjuries++;
                }
            }
            
            bool isValid = (correctAnswers == correctInjuryIds.Count) && (wrongAnswers == 0);

            if (result != null)
            {
                if (isValid)
                {
                    result.text = $" Parfait !\n{correctAnswers}/{correctInjuryIds.Count}";
                    result.color = Color.green;
                }
                else
                {
                    result.text = $"Erreurs :\n";
                    result.text += $"Bonnes: {correctAnswers}/{correctInjuryIds.Count}\n";
                    result.text += $"Fausses: {wrongAnswers}\n";
                    result.text += $"Manquées: {missedInjuries}";
                    result.color = Color.red;
                }
            }

            Debug.Log($"{reportName} → Valide: {isValid}");
            return isValid; 
        }

        public void AddInjury(Injury injury)
        {
            foreach (LineReport lineReport in lineReports)
            {
                if (lineReport.GetInjury().injuryid == injury.injuryid)
                {
                    Debug.Log($"{injury.injuryname} déjà dans {reportName}");
                    return;
                }
            }

            GameObject newLine = Instantiate(prefabLine, container);
            LineReport newLineReport = newLine.GetComponent<LineReport>();
            
            if (newLineReport != null)
            {
                newLineReport.Initialize(injury);
                lineReports.Add(newLineReport);
                Debug.Log($"✅ {injury.injuryname} → {reportName}");
            }
        }

        public void ToggleReports()
        {
            isReportVisible = !isReportVisible;
            panelReport.SetActive(isReportVisible);
        }

        public void ClearReport()
        {
            foreach (LineReport line in lineReports)
            {
                Destroy(line.gameObject);
            }
            lineReports.Clear();
            
            if (result != null)
            {
                result.text = "";
            }
            
            Debug.Log($"{reportName} réinitialisé");
        }
    }
}
