using System;
using UnityEngine.UI;

namespace InventorySystem.Interfaces
{
    public interface ISlot
    {
        int Index { get; }
        bool IsEmpty { get; }
        IItem CurrentItem { get; }
        void SetItem(IItem item);
        void RemoveItem();
    }
}