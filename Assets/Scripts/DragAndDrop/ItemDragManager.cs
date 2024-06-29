using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DragAndDrop
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasGroup))]
    public class ItemDragManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private const float CanvasGroupAlphaOnBeginDrag = .6f;
        private const float CanvasGroupAlphaOnEndDrag = 1f;
        
        [SerializeField] private Canvas canvas;
        [SerializeField] private AudioSource audioSource;
        
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private bool _isInventoryFull;
        
        public Vector3 PositionBeforeDrag { get; private set; }
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            
            audioSource.Play();
            PositionBeforeDrag = transform.position;
            
            var levelBackgrounds = FindObjectsOfType<LevelBackground>();
            
            foreach (var level in levelBackgrounds)
            {
                if (!level.gameObject.activeSelf) continue;
                
                transform.SetParent(level.transform); 
                break;
            }
            
            _canvasGroup.alpha = CanvasGroupAlphaOnBeginDrag;
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.alpha = CanvasGroupAlphaOnEndDrag;
            _canvasGroup.blocksRaycasts = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}