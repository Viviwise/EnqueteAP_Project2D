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
        public void OnPointerClick(PointerEventData eventData)
        { 
          

            if (targetReport != null)
            {
                targetReport.AddInjury(this);
            }
            else
            {
                Debug.LogError("Report n'est pas assigné à cette blessure !");
            }
        }
    }
}