using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    [RequireComponent(typeof(RectTransform))]
    public class Slot : MonoBehaviour, IDropHandler, ISlot
    {
        [SerializeField] private int index;

        private RectTransform _rectTransform;

        public int Index => index;
        
        public IItem CurrentItem { get; private set; }
        
        public bool IsEmpty => CurrentItem == null;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetItem(IItem item)
        {
            CurrentItem = item;
        }

        public void RemoveItem()
        {
            CurrentItem = null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null
                || !eventData.pointerDrag.TryGetComponent(out RectTransform item)) return;

            item.SetParent(gameObject.transform);
            item.localPosition = Vector3.zero;
        }
    }
}