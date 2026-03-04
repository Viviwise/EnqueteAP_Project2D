using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.EliasScript
{
    public class LoadScene : MonoBehaviour
    {
        public void LoadToSceneSalleExam()
        {
            Debug.Log("button is clicked");
            SceneManager.LoadScene(2);
        }

        public void LoadToBrieffingScene()
        {
            Debug.Log("button is clicked");
            SceneManager.LoadScene(1);
        }
        
        public void LoadToMenuScene()
        {
            Debug.Log("button is clicked");
            SceneManager.LoadScene("MenuScene");
        }

        public void LoadToGoodEndingScene()
        {
            Debug.Log("button is clicked");
            SceneManager.LoadScene("GoodEndScene");
        }
    
        public void LoadToBadEndingScene()
        {
            Debug.Log("button is clicked");
            SceneManager.LoadScene("BadEndScene");
        }
        
        public void QuitScene()
        {
            Debug.Log("button is clicked");
            Application.Quit();
        }

    }
}
