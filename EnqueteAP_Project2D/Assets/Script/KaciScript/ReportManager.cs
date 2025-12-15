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
        public List<Text> reportText = new List<Text>();
        private  bool isActive; 
        
        private List<InjuryData>  injuryExaminees = new List<InjuryData>();

        private void Awake()
        {
            instance = this; 
        }

        public void AddInjuryData(InjuryData injuryData)
        {
            if (!injuryExaminees.Contains(injuryData))
            {
                injuryExaminees.Add(injuryData); 
                UpdateReportDisplay();
            }
            
        }
            public void UpdateReportDisplay()
            {
                for (int i = 0; i < injuryExaminees.Count; i++)
                {
                    if (i < reportText.Count && reportText[i] != null)
                    {
                        reportText[i].text = injuryExaminees[i].injuryName;
                    }
                }

                for (int i = injuryExaminees.Count; i < reportText.Count; i++)
                {
                    if (reportText[i] != null)
                    {
                        reportText[i].text = "";
                    }
                }
            }

         void SwitchPanel()
        {
            if (reportPanel == null)
                return; 
            isActive = !isActive;
            if (isActive == true)
            {
                reportPanel.SetActive(true);
            }
            else 
            {
                reportPanel.SetActive(false);
            }
        }
        

       
        
    }
} 
