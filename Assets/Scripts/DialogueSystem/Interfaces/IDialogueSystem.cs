using UnityEngine.UI;

namespace DialogueSystem.Interfaces
{
    public interface IDialogueSystem
    {
        Phrase Phrase { get; }
        Phrase[] Phrases { get; }

        void StartDialogue();
    }
}