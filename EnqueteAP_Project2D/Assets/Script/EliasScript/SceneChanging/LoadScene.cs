using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.EliasScript
{
    public class LoadScene : MonoBehaviour
    {
        public Image fadeImage;
        private float fadeDuration = 1f;

        private void Start()
        {
            StartCoroutine(FadeIn());
        }

        IEnumerator FadeIn()
        {
            float time = 0;

            while (time < fadeDuration)
            {
                time += Time.deltaTime;
                float alpha = 1 - (time / fadeDuration);
                fadeImage.color = new Color(0, 0, 0, alpha);
                yield return null;
            }
        }

        IEnumerator FadeOutAndLoad(string sceneName)
        {
            float time = 0;

            while (time < fadeDuration)
            {
                time += Time.deltaTime;
                float alpha = time / fadeDuration;
                fadeImage.color = new Color(0, 0, 0, alpha);
                yield return null;
            }

            SceneManager.LoadScene(sceneName);
        }

        public void LoadToSceneSalleExam()
        {
            StartCoroutine(FadeOutAndLoad("SceneSalleExam"));
        }

        public void LoadToBrieffingScene()
        {
            StartCoroutine(FadeOutAndLoad("BrieffingGame"));
        }
        
        public void LoadToMenuScene()
        {
            StartCoroutine(FadeOutAndLoad("StartGame"));
        }

        public void LoadToGoodEndingScene()
        {
            StartCoroutine(FadeOutAndLoad("GoodEndScene"));
        }
        public void LoadToMediumEndingScene()
        {
            StartCoroutine(FadeOutAndLoad("MediumEndScene"));
        }
    
        public void LoadToBadEndingScene()
        {
            StartCoroutine(FadeOutAndLoad("BadEndScene"));
        }
        
        public void QuitScene()
        {
            Application.Quit();
        }
    }
}