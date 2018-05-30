using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour, IDragHandler, IEndDragHandler {
    [SerializeField] private Image _image;
    [SerializeField] private Color _dragValidColor = Color.white;
    [SerializeField] private Color _dragInvalidColor = Color.white;

    private bool _isDragged = false;
    private RectTransform _parentRect;
    private Color _defaultColor = Color.white;
    private Camera _camera;

    private void Start() {
        _camera = GetComponentInParent<Canvas>().worldCamera;
    }

    public void Init(RectTransform parentRect, Sprite sprite) {
        _image.sprite = sprite;
        _parentRect = parentRect;
    }

    public void OnDrag(PointerEventData eventData) {
        _isDragged = true;
        UpdateImage();

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRect, Input.mousePosition, _camera, out position);
        position = position - new Vector2(0f, 250f);
        SetImagePosition(position);
    }

    public void OnEndDrag(PointerEventData eventData) {
        Vector3 worldDropPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        worldDropPosition.z = 0f;

        if (IsValidDropPosition()) {
            // quick test code, remove later
            GameObject item = new GameObject(_image.sprite.name);
            item.transform.position = worldDropPosition;
            item.AddComponent<SpriteRenderer>().sprite = _image.sprite;
            item.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
        }

        _isDragged = false;
        ResetImage();
    }

    private void ResetImage() {
        SetImagePosition(Vector3.zero);
        UpdateImage();
    }

    private void UpdateImage() {
        SetImageColor(_isDragged ? (IsValidDropPosition() ? _dragValidColor : _dragInvalidColor) : _defaultColor);
    }

    private bool IsValidDropPosition() {
        return !(Input.mousePosition.x >= 750 && Input.mousePosition.x <= 800 &&
                Input.mousePosition.y >= 0 && Input.mousePosition.y <= 50);
    }

    private void SetImagePosition(Vector3 position) {
        _image.transform.localPosition = position;
    }

    private void SetImageColor(Color color) {
        _image.color = color;
    }
}
