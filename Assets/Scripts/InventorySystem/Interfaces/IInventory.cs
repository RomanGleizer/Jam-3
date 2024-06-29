using System.Collections.Generic;

namespace InventorySystem.Interfaces
{
    public interface IInventory
    {
        Slot[] Slots { get; }
        void Put(IItem item);
        void Take(IItem item);
        void SwapItems(int slotIndex1, int slotIndex2);
    }
}
