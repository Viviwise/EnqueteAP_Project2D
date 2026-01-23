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

        public void StartDialogue(Dialogue dialogue)
        {
            if (dialoguePanel != null)
            {
                dialoguePanel.SetActive(true);
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
            }
            
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            
            if (dialogueText != null)
            {
                dialogueText.text = sentence;
            }
            
        }
        void EndDialogue()
        {
            
            isActive = false;
            
            if (dialoguePanel != null)
            {
                dialoguePanel.SetActive(false);
            }
            else
            {
                Debug.LogError(" dialoguePanel est NULL !");
            }
        }

        public bool IsDialogueActive()
        {
            return isActive;
        }
    }
}
