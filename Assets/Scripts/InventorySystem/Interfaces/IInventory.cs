using System.Collections.Generic;

namespace InventorySystem.Interfaces
{
    public interface IInventory
    {
        Slot[] Slots { get; }
    }
}
