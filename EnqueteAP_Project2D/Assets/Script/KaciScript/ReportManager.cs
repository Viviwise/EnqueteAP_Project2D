using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.KaciScript
{
    public class ReportManager : MonoBehaviour
    {
        public static ReportManager Instance;

        public List<Report> allReports;
        public Button buttonValidateAll;
        
        [Range(0f, 1f)]
        public float percentageToWin = 0.5f;

        private LoadScene loadScene;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("Multiple ReportManager instances detected!");
                Destroy(gameObject);
                return;
            }
            Instance = this;
            Debug.Log(" ReportManager Instance créée");
        }

        private void Start()
        {
            if (buttonValidateAll != null)
            {
                buttonValidateAll.onClick.AddListener(ValidateAllReports);
            }

            Debug.Log($" Nombre de rapports à valider : {allReports.Count}");
            Debug.Log($" Taux de réussite requis : {percentageToWin * 100:F0}%");
        }

        public void ValidateAllReports()
        {
            Debug.Log("=== VALIDATION GLOBALE ===");

            int totalReports = allReports.Count;
            int validReports = 0;

            for (int i = 0; i < allReports.Count; i++)
            {
                Report report = allReports[i];
                Debug.Log($"\n--- Rapport {i + 1}/{totalReports} ---");
                
                bool isValid = report.ValidateReport();

                if (isValid)
                {
                    validReports++;
                    Debug.Log($"Rapport {i + 1} : VALIDE");
                }
                else
                {
                    Debug.Log($"Rapport {i + 1} : INVALIDE");
                }
            }

            float successRate = (float)validReports / totalReports;
            
            Debug.Log("\n=== RÉSULTAT FINAL ===");
            Debug.Log($"Rapports valides: {validReports}/{totalReports}");
            Debug.Log($"Taux de réussite: {successRate * 100:F0}%");
            Debug.Log($"Requis: {percentageToWin * 100:F0}%");

            if (successRate >= percentageToWin)
            {
                Debug.Log("🎉 VICTOIRE !");
                if (loadScene != null)
                {
                    loadScene.LoadToGoodEndingScene();
                }
                else
                {
                    Debug.LogError("LoadScene n'est pas assigné!");
                }
            }
            else
            {
                Debug.Log(" DÉFAITE...");
                if (loadScene != null)
                {
                    loadScene.LoadToBadEndingScene();
                }
                else
                {
                    Debug.LogError("LoadScene n'est pas assigné!");
                }
            }
        }

        public void ResetAllReports()
        {
            foreach (Report report in allReports)
            {
                report.ClearReport();
            }
            Debug.Log(" Tous les rapports réinitialisés");
        }

      
  
    }
}
