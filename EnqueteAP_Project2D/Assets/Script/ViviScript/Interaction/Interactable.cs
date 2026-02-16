using Script;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public virtual void OnHoverEnter()
    {
        CursorManager.instance.OnHoverEnter();
    }

    public virtual void OnHoverExit()
    {
        CursorManager.instance.OnHoverExit();
    }

    public virtual void OnClick()
    {
        Debug.Log("Clicked on " + name);
    }
}