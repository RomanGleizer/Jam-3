using CharactersSystem.Interfaces;
using DialogueSystem;
using Enums;
using InventorySystem.Interfaces;
using UnityEngine;

namespace CharactersSystem
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private new string name;

        public Phrase PhraseAboutReceivedItem { get; private set; }
        
        public IItem ReceivedItem { get; private set; }

        public string Name => name;
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IItem item)) return;
            ReceivedItem = item;

            PhraseAboutReceivedItem = new Phrase(
                ReceivedItem, 
                PhraseStatuses.PointedAtCharacter, 
                "new");
        }
    }
}