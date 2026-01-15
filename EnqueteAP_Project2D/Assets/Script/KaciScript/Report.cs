using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.KaciScript
{
    public class Report : MonoBehaviour
    {


        public string reportName = "Rapport 1"; 

        public Transform container;
        public GameObject prefabLine;
        public Button buttonValidate;
        public TextMeshProUGUI result;
        public GameObject panelReport;
        
        public List<InjuryID> correctInjuryIds;
        
        public  List<LineReport> lineReports = new List<LineReport>();
        private bool isReportVisible = false;
        
        public static Report instance;
        
        private void Start()
        {
            if (buttonValidate != null)
            {
                buttonValidate.onClick.AddListener(() => ValidateReport());
            }
        }

        private void Awake()
        {
            if (instance != null)
            {
                return;
            }
            instance = this;
            DontDestroyOnLoad(this);
        }
        public bool ValidateReport()
        {
            
            int correctAnswers = 0;
            int wrongAnswers = 0;
            int missedInjuries = 0;

            foreach (LineReport lineReport in lineReports)
            {
                InjuryID injuryId = lineReport.GetInjury().injuryid;
                bool playerMarkedCorrect = lineReport.IsMarkedCorrect();
                bool isActuallyCorrect = correctInjuryIds.Contains(injuryId);


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
            
            return isValid; 
        }

        public void AddInjury(Injury injury)
        {
            foreach (LineReport lineReport in lineReports)
            {
                if (lineReport.GetInjury().injuryid == injury.injuryid)
                {
                    return;
                }
            }

            GameObject newLine = Instantiate(prefabLine, container);
            LineReport newLineReport = newLine.GetComponent<LineReport>();
            
            if (newLineReport != null)
            {
                newLineReport.Initialize(injury);
                lineReports.Add(newLineReport);
                
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
          
        }
    }
}
