using UnityEngine;

namespace Script.KaciScript
{
    public class InjuryObject : MonoBehaviour
    {
        public InjuryData injuryData;
        public ReportManager reportManager;
        private void OnMouseDown()
        {
            if (gameObject.CompareTag("Injury"))
            {
                RecoverInfo();
                reportManager.UpdateReportDisplay();
            }
        }

        private void RecoverInfo()
        {
            if (injuryData == null)
            {
                Debug.LogError("Aucune Data n'a été assigné");
                return;
            }

            if (ReportManager.instance != null)
            {
                ReportManager.instance.AddInjuryData(injuryData);
            }
        }
    }
}