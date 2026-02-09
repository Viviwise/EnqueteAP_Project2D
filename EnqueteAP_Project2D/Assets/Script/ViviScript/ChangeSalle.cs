using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSalle : MonoBehaviour
{
    public GameObject salleExamUI;
    public GameObject examinationC1UI;
    public GameObject examinationC2UI;
    public GameObject examinationC3UI;
    //public GameObject tableBureauUI;

    public Camera cam;

    public Button goToExamC1Button;
    public Button goToExamC2Button;
    public Button goToExamC3Button;

    public Button goToSalleExamButton;
    
    public Button goToBureauButton;
    
    public Button goToTableBureauButton;

    private Vector3 salleExamPosition;
    private Vector3 examinationPosition;
    private Vector3 bureauPosition;
    private Vector3 tableBureauPosition;

    void Start()
    {
        salleExamPosition = new Vector3(0f, 0f, -10f);
        examinationPosition = new Vector3(20f, 0f, -10f);
        bureauPosition = new Vector3(40f, 0f, -10f);
        tableBureauPosition = new Vector3(60f, 0f, -10f);
        
        cam.transform.position = bureauPosition;

        salleExamUI.SetActive(false);
        examinationC1UI.SetActive(false);
        examinationC2UI.SetActive(false);
        examinationC3UI.SetActive(false);

        goToSalleExamButton.gameObject.SetActive(true);
        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        goToBureauButton.gameObject.SetActive(false);
        goToTableBureauButton.gameObject.SetActive(true);


        goToExamC1Button.onClick.AddListener(GoToExaminationC1);
        goToExamC2Button.onClick.AddListener(GoToExaminationC2);
        goToExamC3Button.onClick.AddListener(GoToExaminationC3);
        goToSalleExamButton.onClick.AddListener(GoToSalleExam);
        goToBureauButton.onClick.AddListener(GoToBureau);
        goToTableBureauButton.onClick.AddListener(GoToTableBureau);
    }
    
    public void GoToExaminationC1()
    {
        salleExamUI.SetActive(false);
        examinationC1UI.SetActive(true);
        cam.transform.position = examinationPosition;

        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        goToBureauButton.gameObject.SetActive(false);


        goToSalleExamButton.gameObject.SetActive(true);
    }
    public void GoToExaminationC2()
    {
        salleExamUI.SetActive(false);
        examinationC2UI.SetActive(true);
        cam.transform.position = examinationPosition;

        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        goToSalleExamButton.gameObject.SetActive(true);
        goToBureauButton.gameObject.SetActive(false);

    }
    
    public void GoToExaminationC3()
    {
        salleExamUI.SetActive(false);
        examinationC3UI.SetActive(true);
        cam.transform.position = examinationPosition;

        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        goToSalleExamButton.gameObject.SetActive(true);
        goToBureauButton.gameObject.SetActive(false);

    }

    public void GoToSalleExam()
    {
        examinationC1UI.SetActive(false);
        examinationC2UI.SetActive(false);
        examinationC3UI.SetActive(false);
        
        salleExamUI.SetActive(true);
        cam.transform.position = salleExamPosition;

        goToSalleExamButton.gameObject.SetActive(false);
        goToExamC1Button.gameObject.SetActive(true);
        goToExamC2Button.gameObject.SetActive(true);
        goToExamC3Button.gameObject.SetActive(true);
        goToBureauButton.gameObject.SetActive(true);
        goToTableBureauButton.gameObject.SetActive(false);
    }

    public void GoToBureau()
    {
        examinationC1UI.SetActive(false);
        examinationC2UI.SetActive(false);
        examinationC3UI.SetActive(false);
        salleExamUI.SetActive(false);
        
        goToSalleExamButton.gameObject.SetActive(true);
        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        goToBureauButton.gameObject.SetActive(false);
        goToTableBureauButton.gameObject.SetActive(true);


        cam.transform.position = bureauPosition;
    }

    public void GoToTableBureau()
    {
        cam.transform.position = tableBureauPosition;
        
        examinationC1UI.SetActive(false);
        examinationC2UI.SetActive(false);
        examinationC3UI.SetActive(false);
        salleExamUI.SetActive(false);
        
        goToSalleExamButton.gameObject.SetActive(false);
        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        goToBureauButton.gameObject.SetActive(true);
        goToTableBureauButton.gameObject.SetActive(false);

    }
}