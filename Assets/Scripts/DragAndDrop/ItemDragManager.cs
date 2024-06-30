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
        private CanvasZoom[] canvasZooms;
        
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private IItem _item;
        
        public Vector3 PositionBeforeDrag { get; private set; }
        
        public Transform ParentBeforeDrag { get; private set; }
        
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
                transform.localScale = Vector3.one;
                break;
            }
            
            _canvasGroup.alpha = CanvasGroupAlphaOnBeginDrag;

            canvasZooms = FindObjectsOfType<CanvasZoom>();
            foreach (var canvasZoom in canvasZooms)
            {
                canvasZoom.IsActive = true;
                print(1);
            }
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.alpha = CanvasGroupAlphaOnEndDrag;
            _canvasGroup.blocksRaycasts = true;

            canvasZooms = FindObjectsOfType<CanvasZoom>();
            foreach (var canvasZoom in canvasZooms)
            {
                canvasZoom.IsActive = false;
            }

            
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