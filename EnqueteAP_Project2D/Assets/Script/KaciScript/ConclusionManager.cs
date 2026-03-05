using Script.EliasScript;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.KaciScript
{
    public class ConclusionManager : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropdownWidmer;
        [SerializeField] private TMP_Dropdown dropdownPopov;
        [SerializeField] private TMP_Dropdown dropdownJavier;
        
        [SerializeField] private int reponseWidmer;
        [SerializeField] private int reponsePopov;
        [SerializeField] private int reponseJavier;
        [SerializeField] private  LoadScene loadSceneScript;
        public void ValidateConclusion()
        {
            int score = 0;
            
            if (dropdownWidmer.value == reponseWidmer) score++;
            if (dropdownPopov.value == reponsePopov) score++;
            if (dropdownJavier.value == reponseJavier) score++;
            
            
            Debug.Log("Score : " + score + "/3");
            
            switch (score)
            {
                case 0: loadSceneScript.LoadToBadEndingScene(); break;
                case 1: loadSceneScript.LoadToBadEndingScene(); break;
                case 2: loadSceneScript.LoadToMediumEndingScene();break;
                case 3: loadSceneScript.LoadToGoodEndingScene(); break;
            }
        }
    }
}