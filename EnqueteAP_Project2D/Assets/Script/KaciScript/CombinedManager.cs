using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.KaciScript
{
    public class CombinedManager : MonoBehaviour
    {
        public int numberSelected;
        public List<string> correctCombined;
        public Button valideButton;
        public Color colorSelected;
        public Color colorUnselected;
        private List<string> selected;
        private List<Button> buttons;
        public static ReportManager instancereportmanager;
        public static InjuryObject instanceinjury;
        
    }
}