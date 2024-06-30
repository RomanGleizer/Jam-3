using CharactersSystem.Interfaces;
using DialogueSystem;
using Enums;
using InventorySystem;
using InventorySystem.Interfaces;
using UnityEngine;

namespace CharactersSystem
{
    public class Character : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IItem item)) {
                print(item.Id);
            };
            
        }
    }
}