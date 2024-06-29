using System.Collections.Generic;
using DialogueSystem;
using InventorySystem.Interfaces;

namespace CharactersSystem.Interfaces
{
    public interface ICharacter
    {
        Phrase PhraseAboutReceivedItem { get; }
        IItem ReceivedItem { get; } 
        string Name { get; }
    }
}