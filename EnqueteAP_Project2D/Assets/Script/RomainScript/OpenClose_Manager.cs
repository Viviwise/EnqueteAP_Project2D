using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class OpenClose_Manager : MonoBehaviour//, IPointerClickHandler
{

    [SerializeField] private CanvasGroup Page;

    [SerializeField] private bool open;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    
    public void OpenClosePage()
    {
        if (open == true)
        {
            Debug.Log("Open");
            Page.alpha = 1;
            Page.blocksRaycasts = true;
        }
        else
        {
            Debug.Log("Close");
            Page.alpha = 0;
            Page.blocksRaycasts = false;
        }
    }
    /*public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("OpenClose");
            OpenClosePage();
        }
    }*/
    
    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                OpenClosePage();
            }
        }
    }
}