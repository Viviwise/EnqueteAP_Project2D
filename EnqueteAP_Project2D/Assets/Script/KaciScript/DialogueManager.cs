using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Script.KaciScript
{
    public class DialogueManager : MonoBehaviour
    {
        public TextMeshProUGUI dialogueText;
        public TextMeshProUGUI nameText;
        public GameObject dialoguePanel;

        public float autoCloseDelay = 1f;

        private Queue<string> sentences;
        public static DialogueManager instance;
        private bool isActive;
        private DialogueTrigger currentTrigger;
        private bool isTyping = false;
        private string currentSentence;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            sentences = new Queue<string>();

            if (dialoguePanel != null)
            {
                dialoguePanel.SetActive(false);
            }
        }

        public void StartDialogue(Dialogue dialogue, DialogueTrigger trigger = null)
        {
            currentTrigger = trigger;

            if (dialoguePanel != null)
            {
                dialoguePanel.SetActive(true);
            }
            else
            {
                Debug.LogWarning("DialoguePanel est null !");
                return;
            }

            isActive = true;

            if (nameText != null)
            {
                nameText.text = dialogue.name;
            }

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
                Debug.Log("Phrase ajoutée : " + sentence);
            }
            
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = currentSentence;
                isTyping = false;
                return;
            }

            if (sentences.Count == 0)
            {
                StartCoroutine(CloseDialogueAfterDelay(autoCloseDelay));
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            currentSentence = sentence;
            isTyping = true;
            dialogueText.text = "";
            
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
            
            isTyping = false;
        }

        IEnumerator CloseDialogueAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            EndDialogue();
        }

        public void EndDialogue()
        {

            if (dialoguePanel != null)
                dialoguePanel.SetActive(false);

            isActive = false;
            isTyping = false;
            
            StopAllCoroutines();
        }

        public bool IsDialogueActive()
        {
            return isActive;
        }

        public void OpenDialoguePanel()
        {
            dialoguePanel.SetActive(true);
        }
    }
}
