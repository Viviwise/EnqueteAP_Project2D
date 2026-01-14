using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.KaciScript
{
    public class Injury : MonoBehaviour, IPointerClickHandler 
    {

        public InjuryID injuryid;
        public string injuryname;
        [TextArea] public string injurydesc;
        public Report targetReport;  

        private void Start()
        {
            Debug.Log($" Injury {injuryname} → Report assigné: {(targetReport != null ? targetReport.name : "AUCUN")}");
        }

        public void OnPointerClick(PointerEventData eventData)
        { 
            Debug.Log($"CLIC sur {injuryname}");

            if (targetReport != null)
            {
                Debug.Log($" Ajout à {targetReport.name}");
                targetReport.AddInjury(this);
            }
            else
            {
                Debug.LogError(" Aucun Report assigné à cette blessure !");
            }
        }
    }
}