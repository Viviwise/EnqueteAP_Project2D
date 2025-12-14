using UnityEngine;
using UnityEngine.InputSystem;

public class Inspection : MonoBehaviour
{
    public string infoName;
    public string zone;

    private bool isHovering = false;

    void Update()
    {
       HoverCol();
    }

    public void HoverCol()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(screenPos);

        Collider2D col = GetComponent<Collider2D>();

        bool nowHovering = col != null && col.OverlapPoint(mousePos);

        if (nowHovering && !isHovering)
        {
            isHovering = true;
            CursorManager.Instance.OnHoverEnter();
            Debug.Log(infoName + " se trouve sur " + zone);
        }
        else if (!nowHovering && isHovering)
        {
            isHovering = false;
            CursorManager.Instance.OnHoverExit();
        }

        if (isHovering && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log(infoName + " se trouve sur " + zone + " >:(  frr arrete d'appuyer ça fait mal");
        }
    }
}