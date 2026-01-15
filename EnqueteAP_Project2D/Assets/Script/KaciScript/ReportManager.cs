using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.KaciScript
{
    public class ReportManager : MonoBehaviour
    {

        public List<Report> allReports;
        public Button buttonValidateAll;
        
        [Range(0f, 1f)]
        public float percentageToWin = 0.5f;

        public LoadScene loadScene;
        
        
        
        private void Start()
        {
            if (buttonValidateAll != null)
            {
                buttonValidateAll.onClick.AddListener(ValidateAllReports);
            }

        }

        public void ValidateAllReports()
        {
            foreach (Report report in allReports)
            {
                if (report.lineReports.Count == 0)
                {
                    return;
                }
            }

            int totalReports = allReports.Count;
            int validReports = 0;

            

            for (int i = 0; i < allReports.Count; i++)
            {
                Report report = allReports[i];
                
                bool isValid = report.ValidateReport();

                if (isValid)
                {
                    validReports++;
                    Debug.Log("RapportValidé ");
                }
                else
                {
                    Debug.Log("Rapport Invalid");
                }
            }

            float successRate = (float)validReports / totalReports;
        
            if (successRate >= percentageToWin)
            {
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
