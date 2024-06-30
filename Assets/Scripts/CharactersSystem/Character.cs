﻿using DragAndDrop;
using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CharactersSystem
{
    public class Character : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null ||
                !eventData.pointerDrag.TryGetComponent(out RectTransform rectTransform))
                return;
            
            if (!rectTransform.TryGetComponent(out ItemDragManager item))
                return;

            if (item.ParentBeforeDrag != null)
            {
                rectTransform.SetParent(item.ParentBeforeDrag);
                rectTransform.localPosition = Vector3.zero;
                return;
            }
            
            eventData.pointerDrag.transform.position = item.PositionBeforeDrag;
        }
    }
}