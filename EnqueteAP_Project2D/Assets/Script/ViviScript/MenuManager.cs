using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SceneSalleExam");
    }
}
