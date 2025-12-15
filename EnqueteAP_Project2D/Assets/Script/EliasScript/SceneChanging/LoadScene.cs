using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadToWorkScene()
    {
        Debug.Log("button is clicked");
        SceneManager.LoadScene("WorkScene");
    }

    public void LoadToOfficeScene()
    {
        Debug.Log("button is clicked");
        SceneManager.LoadScene("OfficeScene");
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

    public void LoadToVivienScene()
    {
        Debug.Log("button is clicked");
        SceneManager.LoadScene("ViviScene");
    }

    public void LoadToKaciScene()
    {
        Debug.Log("button is clicked");
        SceneManager.LoadScene("SceneKaci");
    }
    
    public void LoadToRomainScene()
    {
        Debug.Log("button is clicked");
        SceneManager.LoadScene("RomainScene");
    }

}
