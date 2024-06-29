using UnityEngine;

namespace InventorySystem.Interfaces
{
    public interface IItemData
    {
        public string Name { get; }
        public string Description { get; }
        public Vector2 CurrentPosition { get; }
        public Vector2 EndPosition { get; }
    }
}