using System.Collections;
using DialogueSystem.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueSystem : MonoBehaviour, IDialogueSystem
    {
        [SerializeField] private float textAppearanceSpeed;
        
        private int _index;
        
        public Phrase Phrase { get; }
        
        public Phrase[] Phrases { get; }
        
        private void Start()
        {
            Phrase.Text = string.Empty;
            ((IDialogueSystem)this).StartDialogue();
        }

        private IEnumerator TypeLine()
        {
            foreach (var letter in Phrases[_index].Text.ToCharArray())
            {
                Phrase.Text += letter;
                yield return new WaitForSeconds(textAppearanceSpeed);
            }
        }

        private void ShowNextPhrase()
        {
            if (_index < Phrases.Length - 1)
            {
                _index++;
                Phrase.Text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.SetActive(false);    
            }
        }

        void IDialogueSystem.StartDialogue()
        {
            _index = 0;
            StartCoroutine(TypeLine());
        }

        public void ShowPhrases()
        {
            if (Phrase.Text == Phrases[_index].Text)
            {
                ShowNextPhrase();
            }
            else
            {
                StopAllCoroutines();
                Phrase.Text = Phrases[_index].Text;
            }
        }
    }
}