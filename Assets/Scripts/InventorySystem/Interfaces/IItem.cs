using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

namespace InventorySystem.Interfaces
{
    public interface IItem
    {
        Image Image { get; }
        string Name { get; }
        string Description { get; }
        Vector2 EndPosition { get; }
    }
}