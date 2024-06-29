namespace InventorySystem.Interfaces
{
    public interface ISlot
    {
        int Number { get; }
        IItem CurrentItem { get; }
    }
}