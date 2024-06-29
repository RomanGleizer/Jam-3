using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public sealed class BaseItem : MonoBehaviour, IItem
    {
        [SerializeField] private new string name;
        [SerializeField] private string description;
        [SerializeField] private Image image;
        [SerializeField] private Vector2 currentPosition;
        [SerializeField] private Vector2 endPosition;

        public Image Image => image;
        public string Name => name;
        public string Description => description;
        public Vector2 CurrentPosition => currentPosition;
        public Vector2 EndPosition => endPosition;
    }
}