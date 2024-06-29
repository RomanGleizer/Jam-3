using InventorySystem.Interfaces;
using UnityEngine;

namespace InventorySystem
{
    public class Slot : MonoBehaviour, ISlot
    {
        public int Number { get; private set; }

        public IItem CurrentItem { get; private set; }
    }
}