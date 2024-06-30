using System.Linq;
using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DragAndDrop
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(IItem))]
    public class ItemDragManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private const float CanvasGroupAlphaOnBeginDrag = .6f;
        private const float CanvasGroupAlphaOnEndDrag = 1f;
        
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private CanvasZoom[] canvasZooms;
        
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private IItem _item;
        
        public Vector3 PositionBeforeDrag { get; private set; }
        
        public Transform ParentBeforeDrag { get; private set; }
        
        public bool IsActive { get; private set; }
        
        private void Awake()
        {
            _item = GetComponent<IItem>();
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            audioSource.Play();

            if (transform.parent.TryGetComponent(out ISlot _))
            {
                PositionBeforeDrag = default;
                ParentBeforeDrag = transform.parent;
            }
            else
            {
                ParentBeforeDrag = null;
                PositionBeforeDrag = transform.position;
            }

            var levelBackgrounds = FindObjectsOfType<LevelBackground>();
            foreach (var level in levelBackgrounds)
            {
                if (!level.gameObject.activeSelf) 
                    continue;
                
                transform.SetParent(level.transform); 
                break;
            }
            
            _canvasGroup.alpha = CanvasGroupAlphaOnBeginDrag;

            foreach (var canvasZoom in canvasZooms)
            {
                canvasZoom.IsActive = true;    
            }
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.alpha = CanvasGroupAlphaOnEndDrag;
            _canvasGroup.blocksRaycasts = true;
            
            foreach (var canvasZoom in canvasZooms)
            {
                canvasZoom.IsActive = false;    
            }

            if (eventData.pointerDrag.transform.position != _item.EndPosition ||
                !eventData.pointerDrag.TryGetComponent(out IItem item)) return;
            
            var levelBackgrounds = FindObjectsOfType<LevelBackground>();
            
            if (levelBackgrounds.All(level => level.Id != item.TargetLevelIndex)) 
                return;
            
            eventData.pointerDrag.SetActive(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            var backgrounds = FindObjectsOfType<LevelBackground>();
            foreach (var background in backgrounds)
            {
                if (background.TryGetComponent(out Image levelBackground) && levelBackground.gameObject.activeSelf)
                {
                    _rectTransform.anchoredPosition += eventData.delta / levelBackground.rectTransform.localScale;
                    break;
                }       
            }
        }
    }
}