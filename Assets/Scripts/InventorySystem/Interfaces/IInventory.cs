using System.Collections.Generic;

namespace InventorySystem.Interfaces
{
    public interface IInventory
    {
        IList<IItem> Items { get; }
        void Put(IItem item);
        void Take(IItem item);
    }
}
