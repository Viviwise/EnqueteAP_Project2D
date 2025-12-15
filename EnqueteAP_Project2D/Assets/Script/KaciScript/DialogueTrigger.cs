using Script.KaciScript;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour 
{
    public Dialogue dialogue;
    private bool isInDialogue = false;
    private bool canAdvance = false;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            CheckClickOnInjury();
        }
    }

    private void CheckClickOnInjury()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject && CompareTag("Injury"))
            {
                HandleDialogueClick();
            }
        }
    }

    private void HandleDialogueClick()
    {
        Debug.Log("Clic détecté sur objet Injury");
        
        if (DialogueManager.instance == null)
        {
            Debug.LogError("DialogueManager manquant!");
            return;
        }

        if (!isInDialogue)
        {
            TriggerDialogue();
            return;
        }

        if (canAdvance)
        {
            DialogueManager.instance.DisplayNextSentence();
        }
        else
        {
            canAdvance = true;
        }
    }

    void TriggerDialogue()
    {
        if (dialogue == null || dialogue.sentences.Length == 0)
        {
            Debug.LogWarning("Dialogue vide ou null!");
            return;
        }

        Debug.Log("Démarrage du dialogue");
        isInDialogue = true;
        canAdvance = false;
        DialogueManager.instance.StartDialogue(dialogue, this);
    }

    public void OnDialogueEnd()
    {
        Debug.Log("Dialogue terminé");
        isInDialogue = false;
        canAdvance = false;
    }
}
