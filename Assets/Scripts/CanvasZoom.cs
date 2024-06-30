using UnityEngine;

public class CanvasZoom : MonoBehaviour
{
    [SerializeField] private RectTransform canvasTransform;
    [SerializeField] private RectTransform canvasParentTransform;

    private float zoomSpeed = 0.1f;
    private float minZoom = 0.5f;
    private float maxZoom = 2f;

    private bool isDragging = false;
    private Vector2 lastMousePosition;
    private Vector3 originalPosition;

    public bool IsActive { get; set; }

    void Start()
    {
        originalPosition = canvasTransform.localPosition; // Store the initial position
    }

    void Update()
    {
        HandleZoom();
        if (!IsActive)
            HandleDrag();
    }

    private void HandleZoom()
    {
        float zoom = Input.mouseScrollDelta.y;

        if (zoom != 0)
        {
            Vector3 scale = canvasTransform.localScale;
            scale += Vector3.one * zoom * zoomSpeed;
            scale = new Vector3(
                Mathf.Clamp(scale.x, minZoom, maxZoom),
                Mathf.Clamp(scale.y, minZoom, maxZoom),
                scale.z
            );

            canvasTransform.localScale = scale;
            if (canvasTransform.localScale.x < 1)
            {
                canvasTransform.localScale = new Vector3(1, 1, 1);
            }

            if (scale.x == 1 && scale.y == 1)
            {
                canvasTransform.localPosition = originalPosition;
            }
            else
            {
                // Constrain movement within bounds after scaling
                ConstrainCanvasPosition();
            }
        }
    }

    private void HandleDrag()
    {
        if (Input.GetMouseButtonDown(0) && !IsActive)
        {
            print(2);
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 delta = currentMousePosition - lastMousePosition;
            Vector3 newPosition = canvasTransform.localPosition + new Vector3(delta.x, delta.y, 0);

            canvasTransform.localPosition = newPosition;
            lastMousePosition = currentMousePosition;

            // Constrain movement within bounds
            ConstrainCanvasPosition();
        }
    }

    private void ConstrainCanvasPosition()
    {
        Vector3 pos = canvasTransform.localPosition;
        Vector3 scale = canvasTransform.localScale;

        float canvasWidth = canvasTransform.rect.width * scale.x;
        float canvasHeight = canvasTransform.rect.height * scale.y;
        float parentWidth = canvasParentTransform.rect.width;
        float parentHeight = canvasParentTransform.rect.height;

        float clampedX = Mathf.Clamp(pos.x, (parentWidth - canvasWidth) / 2, (canvasWidth - parentWidth) / 2);
        float clampedY = Mathf.Clamp(pos.y, (parentHeight - canvasHeight) / 2, (canvasHeight - parentHeight) / 2);

        canvasTransform.localPosition = new Vector3(clampedX, clampedY, pos.z);

    }
}