using System;
using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem
{
    [RequireComponent(typeof(RectTransform))]
    public class Slot : MonoBehaviour, IDropHandler, ISlot
    {
        [SerializeField] private int index;
        [SerializeField] private Image itemImage;

        private RectTransform _rectTransform;
        
        public Image ItemImage => itemImage;

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
            // item.anchoredPosition = _rectTransform.anchoredPosition;
                
            item.SetParent(gameObject.transform);
            item.localPosition = Vector3.zero;
        }
    }
}