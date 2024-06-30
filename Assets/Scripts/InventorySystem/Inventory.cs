using InventorySystem.Interfaces;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour, IInventory
    {
        [SerializeField] private Slot[] slots;

        public Slot[] Slots => slots;

        private void Awake()
        {
            slots = GetComponentsInChildren<Slot>();
        }
    }
}