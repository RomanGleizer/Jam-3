using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public sealed class BaseItem : MonoBehaviour, IItem
    {
        [SerializeField] private int id;
        [SerializeField] private int targetLevelIndex;
        [SerializeField] private Vector3 endPosition;
        
        public Vector3 EndPosition => endPosition;
       
        public int Id => id;

        public int TargetLevelIndex => targetLevelIndex;
    }
}