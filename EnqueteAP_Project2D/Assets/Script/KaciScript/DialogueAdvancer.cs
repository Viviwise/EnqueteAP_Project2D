using Script.KaciScript;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueAdvancer : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (DialogueManager.instance != null && DialogueManager.instance.IsDialogueActive())
        {
            DialogueManager.instance.DisplayNextSentence();
        }
    }
}