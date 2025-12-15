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

        private Queue<string> sentences;
        public static DialogueManager instance;
        private bool isActive;
        private DialogueTrigger currentTrigger; 

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
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
        }
        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }
        private void EndDialogue()
        {
            Debug.Log("EndDialogue appelé");
            
            if (dialoguePanel != null)
                dialoguePanel.SetActive(false);

            isActive = false;
            
            if (currentTrigger != null)
            {
                currentTrigger.OnDialogueEnd();
                currentTrigger = null; 
            }
            
        }

        public bool IsDialogueActive()
        {
            return isActive;
        }

        public void SkipTyping()
        {
            StopAllCoroutines();
        }
    }
}
