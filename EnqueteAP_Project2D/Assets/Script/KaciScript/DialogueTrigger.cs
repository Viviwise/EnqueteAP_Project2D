using Script.KaciScript;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour 
{
    public Dialogue dialogue;
    private bool isInDialogue = false;
    private bool isFirstClick = true;

    private void Update()
    {
        if (isInDialogue && !isFirstClick && Input.GetMouseButtonDown(0))
        {
            if (DialogueManager.instance != null)
            {
                DialogueManager.instance.DisplayNextSentence();
            }
        }
    }

    private void OnMouseDown()
    {
        if (DialogueManager.instance == null)
        {
            return;
        }

        if (!isInDialogue)
        {
            TriggerDialogue();
            isFirstClick = true; 
        }
        else if (!isFirstClick)
        {
            DialogueManager.instance.DisplayNextSentence();
        }
        
        if (isFirstClick)
        {
            isFirstClick = false;
        }
    }

    void TriggerDialogue()
    {
        if (dialogue == null)
        {
            return;
        }

        if (dialogue.sentences.Length == 0)
        {
            return;
        }

        isInDialogue = true;
        DialogueManager.instance.StartDialogue(dialogue, this);
    }

    public void OnDialogueEnd()
    {
        isInDialogue = false;
        isFirstClick = true; 
    }
}
