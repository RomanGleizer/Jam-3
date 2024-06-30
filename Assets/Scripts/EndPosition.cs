﻿using CharactersSystem;
using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndPosition : MonoBehaviour, IDropHandler
{
    [SerializeField] private int itemId;
    [SerializeField] private Character char1;
    [SerializeField] private Character char2;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null ||
            !eventData.pointerDrag.TryGetComponent(out RectTransform rectTransform))
            return;
        
        if (rectTransform.TryGetComponent(out IItem item) && item.Id == itemId)
        {
            rectTransform.gameObject.SetActive(false);
            char1.EndSpeech(itemId);
            char2.EndSpeech(itemId);
        }
            
    }
}