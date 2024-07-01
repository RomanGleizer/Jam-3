using CharactersSystem;
using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndPosition : MonoBehaviour, IDropHandler
{
    [SerializeField] private int itemId;
    [SerializeField] private Character char1;
    [SerializeField] private Character char2;
    [SerializeField] private LevelChanger levelChanger;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null ||
            !eventData.pointerDrag.TryGetComponent(out RectTransform rectTransform))
            return;
        
        if (rectTransform.TryGetComponent(out IItem item) && item.Id == itemId)
        {
            var canvasZooms = FindObjectsOfType<CanvasZoom>();
            foreach (var canvasZoom in canvasZooms)
            {
                canvasZoom.IsActive = false;
            }
            rectTransform.gameObject.SetActive(false);
            char1.EndSpeech(itemId);
            char2.EndSpeech(itemId);
            levelChanger.countOfItem++;
        }
            
    }
}