using System.Collections.Generic;
using InventorySystem.Interfaces;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour, IInventory
    {
        public IList<IItem> Items { get; private set; }

        public void Put(IItem item)
        {
            Items.Add(item);    
        }

        public void Take(IItem item)
        {
            Items.Remove(item);
        }
    }
}