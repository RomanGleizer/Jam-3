using InventorySystem.Interfaces;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour, IInventory
    {
        [SerializeField] private Slot[] slots;

        public Slot[] Slots => slots;

        private void Awake()
        {
            slots = GetComponentsInChildren<Slot>();
        }

        public void Put(IItem item)
        {
            foreach (var slot in Slots)
            {
                if (!slot.IsEmpty) continue;
                slot.SetItem(item);
                return;
            }
        }

        public void Take(IItem item)
        {
            foreach (var slot in Slots)
            {
                if (slot.CurrentItem != item) continue;
                slot.RemoveItem();
                return;
            }
        }
        
        public void SwapItems(int slotIndex1, int slotIndex2)
        {
            if (slotIndex1 < 0 || slotIndex1 >= Slots.Length || slotIndex2 < 0 || slotIndex2 >= Slots.Length)
                return;

            var slot1 = Slots[slotIndex1];
            var slot2 = Slots[slotIndex2];

            var tempItem = slot1.CurrentItem;
            slot1.SetItem(slot2.CurrentItem);
            slot2.SetItem(tempItem);
        }
    }
}