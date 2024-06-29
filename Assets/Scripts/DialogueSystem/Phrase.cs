using Enums;
using InventorySystem.Interfaces;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class Phrase
    {
        public Phrase(IItem item, PhraseStatuses status, string text)
        {
            Item = item;
            Status = status;
            Text = text;
        }
        
        public IItem Item { get; }
        public PhraseStatuses Status { get; }
        public string Text { get; set; }
    }
}