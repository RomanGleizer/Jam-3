namespace InventorySystem.Interfaces
{
    public interface ISlot
    {
        int Number { get; }
        IItem CurrentItem { get; }
        void SetItem(IItem item);
        void RemoveItem();
        bool IsEmpty { get; }
    }
}