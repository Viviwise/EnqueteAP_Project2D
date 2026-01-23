using Script.KaciScript;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueTrigger : MonoBehaviour, IPointerClickHandler
{
    public Dialogue dialogue;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (DialogueManager.instance != null && !DialogueManager.instance.IsDialogueActive())
        {
            DialogueManager.instance.StartDialogue(dialogue);
        }
    }
}