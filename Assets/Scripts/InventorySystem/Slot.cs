using InventorySystem.Interfaces;
using UnityEngine;

namespace InventorySystem
{
    public class Slot : MonoBehaviour, ISlot
    {
        public int Number { get; private set; }
        
        public IItem CurrentItem { get; private set; }
        
        public bool IsEmpty => CurrentItem == null;
        
        public void SetItem(IItem item)
        {
            CurrentItem = item;
        }

        public void RemoveItem()
        {
            CurrentItem = null;
        }
    }
}