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

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null ||
                !eventData.pointerDrag.TryGetComponent(out RectTransform rectTransform))
                return;

            var containsChild = transform.childCount > 0;

            if (containsChild && rectTransform.TryGetComponent(out ItemDragManager itemDragManager))
            {
                if (itemDragManager.ParentBeforeDrag == null)
                {
                    eventData.pointerDrag.transform.position = itemDragManager.PositionBeforeDrag;
                    return;
                }
                
                eventData.pointerDrag.transform.SetParent(itemDragManager.ParentBeforeDrag);
                rectTransform.localPosition = Vector3.zero;
                return;
            }

            if (!rectTransform.TryGetComponent(out IItem _)) 
                return;

            rectTransform.SetParent(gameObject.transform);
            rectTransform.localPosition = Vector3.zero;
        }
    }
}