using Vector2 = UnityEngine.Vector2;

namespace InventorySystem.Interfaces
{
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
        Vector2 CurrentPosition { get; }
        Vector2 EndPosition { get; }
    }
}