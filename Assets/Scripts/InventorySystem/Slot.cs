using DragAndDrop;
using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class Slot : MonoBehaviour, IDropHandler, ISlot
    {
        [SerializeField] private int index;

        public int Index => index;
        
        public IItem CurrentItem { get; private set; }
        
        public bool IsEmpty => CurrentItem == null;

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
            if (eventData.pointerDrag == null || !eventData.pointerDrag.TryGetComponent(out RectTransform rectTransform)) 
                return;
            
            if (!IsEmpty && rectTransform.TryGetComponent(out ItemDragManager itemDragManager))
            {
                eventData.pointerDrag.transform.position = itemDragManager.PositionBeforeDrag;
                return;
            }

            rectTransform.SetParent(gameObject.transform);
            rectTransform.localPosition = Vector3.zero;
            
            if (rectTransform.TryGetComponent(out IItem item))
                CurrentItem = item;
        }
    }
}