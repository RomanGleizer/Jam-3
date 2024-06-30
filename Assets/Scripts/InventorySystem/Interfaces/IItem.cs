using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Interfaces
{
    public interface IItem
    {
        Vector3 EndPosition { get; }
        int Id { get; }
        int TargetLevelIndex { get; }
    }
}