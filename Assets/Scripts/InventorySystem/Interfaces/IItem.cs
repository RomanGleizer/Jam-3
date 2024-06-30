using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Interfaces
{
    public interface IItem
    {
        Image Image { get; }
        string Name { get; }
        string Description { get; }
        Vector3 EndPosition { get; }
        int Id { get; }
    }
}