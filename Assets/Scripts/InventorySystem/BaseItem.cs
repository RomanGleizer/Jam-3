using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public sealed class BaseItem : MonoBehaviour, IItem
    {
        [SerializeField] private int id;
        [SerializeField] private new string name;
        [SerializeField] private string description;
        [SerializeField] private Image image;
        [SerializeField] private Vector3 endPosition;

        public Image Image => image;
        public string Name => name;
        public string Description => description;
        public Vector3 EndPosition => endPosition;
        public int Id => id;
    }
}