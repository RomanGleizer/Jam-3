using InventorySystem.Interfaces;
using UnityEngine;

namespace InventorySystem
{
    public sealed class TestItem : MonoBehaviour, IItem
    {
        [SerializeField] private new string name;
        [SerializeField] private string description;
        [SerializeField] private Vector2 currentPosition;
        [SerializeField] private Vector2 endPosition;

        public string Name => name;
        public string Description => description;
        public Vector2 CurrentPosition => currentPosition;
        public Vector2 EndPosition => endPosition;
    }
}