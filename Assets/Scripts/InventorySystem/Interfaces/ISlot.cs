using System;
using UnityEngine.UI;

namespace InventorySystem.Interfaces
{
    public interface ISlot
    {
        int Index { get; }
        IItem CurrentItem { get; }
    }
}