using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChangeSalle : MonoBehaviour
{
    public GameObject salleExamUI;
    public GameObject examinationC1UI;
    public GameObject examinationC2UI;
    public GameObject examinationC3UI;
    //public GameObject tableBureauUI;
    public GameObject conclusionUI;

    public Camera cam;

    public Button goToExamC1Button;
    public Button goToExamC2Button;
    public Button goToExamC3Button;

    public Button goToReportSpaceButton;
    public Button goToReportC1Button;
    public Button goToReportC2Button;
    public Button goToReportC3Button;
    
    public Button goToReportFinalButton;
    public Button quitReportFinalButton;
    public TMP_Dropdown dropDownC1;
    public TMP_Dropdown dropDownC2;
    public TMP_Dropdown dropDownC3;

    public Button goToSalleExamButton;
    public Button goToBureauButton;
    public Button goToTableBureauButton;

    //position pièces
    private Vector3 salleExamPosition;
    private Vector3 examinationPosition;
    private Vector3 bureauPosition;
    private Vector3 tableBureauPosition;
    private Vector3 reportSpacePosition;
    private Vector3 reportPosition;
    private Vector3 reportFinalPosition;

    void Start()
    {
        //position pour cam
        salleExamPosition = new Vector3(0f, 0f, -10f);
        examinationPosition = new Vector3(20f, 0f, -10f);
        bureauPosition = new Vector3(40f, 0f, -10f);
        tableBureauPosition = new Vector3(60f, 0f, -10f);
        reportSpacePosition = new Vector3(80f, 0f, -10f);
        reportPosition = new Vector3(100f, 0f, -10f);
        reportFinalPosition = new Vector3(120f, 0f, -10f);
        

        //button analyse et cadavres
        salleExamUI.SetActive(false);
        examinationC1UI.SetActive(false);
        examinationC2UI.SetActive(false);
        examinationC3UI.SetActive(false);

        //button changement pièces
        goToSalleExamButton.gameObject.SetActive(true);
        goToBureauButton.gameObject.SetActive(false);
        goToTableBureauButton.gameObject.SetActive(true);
        
        goToReportSpaceButton.gameObject.SetActive(false);
        goToReportFinalButton.gameObject.SetActive(false);
        quitReportFinalButton.gameObject.SetActive(false);
        dropDownC1.gameObject.SetActive(false);
        dropDownC2.gameObject.SetActive(false);
        dropDownC3.gameObject.SetActive(false);
        
        goToReportC1Button.gameObject.SetActive(false);
        goToReportC2Button.gameObject.SetActive(false);
        goToReportC3Button.gameObject.SetActive(false);
        
        //button accès cadavres
        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);


        goToExamC1Button.onClick.AddListener(GoToExaminationC1);
        goToExamC2Button.onClick.AddListener(GoToExaminationC2);
        goToExamC3Button.onClick.AddListener(GoToExaminationC3);
        goToSalleExamButton.onClick.AddListener(GoToSalleExam);
        goToBureauButton.onClick.AddListener(GoToBureau);
        goToTableBureauButton.onClick.AddListener(GoToTableBureau);
        
        goToReportSpaceButton.onClick.AddListener(GoToReportSpace);
        goToReportC1Button.onClick.AddListener(GoToReportCadavre);
        goToReportC2Button.onClick.AddListener(GoToReportCadavre);
        goToReportC3Button.onClick.AddListener(GoToReportCadavre);
        
        goToReportFinalButton.onClick.AddListener(GoToReportFinal);
        
        cam.transform.position = bureauPosition;
        
        conclusionUI.SetActive(false);
    }
    
    public void GoToExaminationC1()
    {
        cam.transform.position = examinationPosition;
        
        salleExamUI.SetActive(false);
        examinationC1UI.SetActive(true);

        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        goToBureauButton.gameObject.SetActive(false);
        goToSalleExamButton.gameObject.SetActive(true);
        goToReportSpaceButton.gameObject.SetActive(false);
    }
    public void GoToExaminationC2()
    {
        cam.transform.position = examinationPosition;
        
        salleExamUI.SetActive(false);
        examinationC2UI.SetActive(true);

        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        goToSalleExamButton.gameObject.SetActive(true);
        goToBureauButton.gameObject.SetActive(false);
        goToReportSpaceButton.gameObject.SetActive(false);
    }
    public void GoToExaminationC3()
    {
        cam.transform.position = examinationPosition;
        
        salleExamUI.SetActive(false);
        examinationC3UI.SetActive(true);

        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        goToSalleExamButton.gameObject.SetActive(true);
        goToBureauButton.gameObject.SetActive(false);
        goToReportSpaceButton.gameObject.SetActive(false);
    }
    public void GoToReportCadavre()
    {
        cam.transform.position = reportPosition;
        
        goToSalleExamButton.gameObject.SetActive(false);
        goToReportSpaceButton.gameObject.SetActive(false);
        goToReportC1Button.gameObject.SetActive(false);
        goToReportC2Button.gameObject.SetActive(false);
        goToReportC3Button.gameObject.SetActive(false);
    }

    
    public void GoToReportSpace()
    { 
        cam.transform.position = reportSpacePosition;
        
        salleExamUI.SetActive(true);
        goToReportC1Button.gameObject.SetActive(true);
        goToReportC2Button.gameObject.SetActive(true);
        goToReportC3Button.gameObject.SetActive(true);
        
        goToSalleExamButton.gameObject.SetActive(true);
        goToExamC1Button.gameObject.SetActive(false);
        goToExamC2Button.gameObject.SetActive(false);
        goToExamC3Button.gameObject.SetActive(false);
        
        goToBureauButton.gameObject.SetActive(false);
        goToTableBureauButton.gameObject.SetActive(false);
        
        goToReportSpaceButton.gameObject.SetActive(false);
    }
    

    public void GoToSalleExam()
    {
        cam.transform.position = salleExamPosition;
        
        examinationC1UI.SetActive(false);
        examinationC2UI.SetActive(false);
        examinationC3UI.SetActive(false);
        
        salleExamUI.SetActive(false);

        goToSalleExamButton.gameObject.SetActive(false);
        goToExamC1Button.gameObject.SetActive(true);
        goToExamC2Button.gameObject.SetActive(true);
        goToExamC3Button.gameObject.SetActive(true);
        goToBureauButton.gameObject.SetActive(true);
        goToTableBureauButton.gameObject.SetActive(false);
        goToReportSpaceButton.gameObject.SetActive(true);
        goToReportFinalButton.gameObject.SetActive(false);
    }

    public void GoToBureau()
    {
        cam.transform.position = bureauPosition;
        
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
        
        goToReportSpaceButton.gameObject.SetActive(false);
        goToReportFinalButton.gameObject.SetActive(false);
        dropDownC1.gameObject.SetActive(false);
        dropDownC2.gameObject.SetActive(false);
        dropDownC3.gameObject.SetActive(false);
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
        goToReportSpaceButton.gameObject.SetActive(false);
        
        goToReportFinalButton.gameObject.SetActive(true);
        quitReportFinalButton.gameObject.SetActive(false);
        quitReportFinalButton.gameObject.SetActive(false);
        conclusionUI.SetActive(false);
        dropDownC1.gameObject.SetActive(false);
        dropDownC2.gameObject.SetActive(false);
        dropDownC3.gameObject.SetActive(false);
    }

    public void GoToReportFinal()
    {
        cam.transform.position = reportFinalPosition;
        
        goToTableBureauButton.gameObject.SetActive(false);
        goToReportFinalButton.gameObject.SetActive(false);
        quitReportFinalButton.gameObject.SetActive(true);
        conclusionUI.SetActive(true);
        dropDownC1.gameObject.SetActive(true);
        dropDownC2.gameObject.SetActive(true);
        dropDownC3.gameObject.SetActive(true);
    }
}