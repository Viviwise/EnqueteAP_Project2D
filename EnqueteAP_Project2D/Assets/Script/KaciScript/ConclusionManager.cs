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
        
        [SerializeField] private int reponsePichard;
        [SerializeField] private int reponseRouflet;
        [SerializeField] private int reponseJames;
        [SerializeField] private  LoadScene loadScene;
        
        private void Awake()
        {
            loadScene = GetComponent<LoadScene>();
        }


        public void ValidateConclusion()
        {
            int score = 0;
            
            if (dropdownWidmer.value == reponsePichard) score++;
            if (dropdownPopov.value == reponseRouflet) score++;
            if (dropdownJavier.value == reponseJames) score++;
            
            
            Debug.Log("Score : " + score + "/3");
            
            switch (score)
            {
                case 0: SceneManager.LoadScene("BadEndScene"); break;
                case 1: SceneManager.LoadScene("BadEndScene"); break;
                case 2: SceneManager.LoadScene("BadEndScene"); break;
                case 3: SceneManager.LoadScene("GoodEndScene"); break;
            }
        }
    }
}