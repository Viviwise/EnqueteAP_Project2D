using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.KaciScript
{
    public class LineReport : MonoBehaviour
    {
        public TextMeshProUGUI textName;
        public Toggle checkboxCorrect; 
        public Injury myinjury;

        public void Initialize(Injury injury)
        {
            myinjury = injury;
            textName.text = myinjury.injuryname;
            checkboxCorrect.isOn = false;

        }

        public bool IsMarkedCorrect()
        {
            return checkboxCorrect.isOn;
        }
        
        public Injury GetInjury()
        {
            return myinjury;
        }

        public bool HasInjuryID(InjuryID id)
        {
            return myinjury != null && myinjury.injuryid == id;
        }

        
    }
}