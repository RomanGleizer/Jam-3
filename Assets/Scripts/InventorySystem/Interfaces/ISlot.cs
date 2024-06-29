using UnityEngine.UI;

namespace InventorySystem.Interfaces
{
    public interface ISlot
    {
        Image ItemImage { get; }
        int Index { get; }
        IItem CurrentItem { get; }
        void SetItem(IItem item);
        void RemoveItem();
        bool IsEmpty { get; }
    }
}