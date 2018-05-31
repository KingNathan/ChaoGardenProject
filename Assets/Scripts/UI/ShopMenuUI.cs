using UnityEngine;
using UnityEngine.UI;

public class ShopMenuUI : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Animator _animator;
    [SerializeField] private RectTransform _contentTransform;
    [SerializeField] private Image _selectedItemImage;
    [SerializeField] private GameObject _shopItemUIPrefab;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private ItemData[] _items;

    private bool _isOpen = false;
    private bool _isClosedTemporarly = false;
    private ItemData _selectedItem;
    private Vector2 _screenMousePosition;

    private static readonly int IS_OPEN_ID = Animator.StringToHash("IsOpen");

    private void Start() {
        SetOpen(_isOpen);
        AddAllItemsToShop();
    }

    private void LateUpdate() {
        UpdateScreenMousePosition();

        if (_selectedItem) {
            _selectedItemImage.transform.position = _screenMousePosition;

            if (Input.GetKeyDown(KeyCode.Escape))
                UnselectItem();

            if (Input.GetKeyDown(KeyCode.Mouse0))
                PlaceDownItem();

            if (_isOpen)
                CloseShopTemporarly();
        }
        else if (_isClosedTemporarly) {
            OpenShop();
        }

        _selectedItemImage.gameObject.SetActive(_selectedItem);
    }

    private void UpdateScreenMousePosition() {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Input.mousePosition, _canvas.worldCamera, out _screenMousePosition);
        _screenMousePosition = _canvas.transform.TransformPoint(_screenMousePosition);
    }

    private Vector2 GetWorldPositionFromMousePosition() {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void AddAllItemsToShop() {
        for (int i = 0; i < _items.Length; i++)
            AddItemToShop(_items[i]);
    }

    private void AddItemToShop(ItemData item) {
        ItemData _item = item;
        GameObject testGo = Instantiate(_shopItemUIPrefab, _contentTransform);
        ShopItemUI shopItem = testGo.GetComponent<ShopItemUI>();
        shopItem.SetItem(_item);
        shopItem.ClickEvent += SelectItem;
    }

    private void UpdateAnimator() {
        _animator.SetBool(IS_OPEN_ID, _isOpen);
    }

    private void SelectItem(ItemData item) {
        _selectedItem = item;
        _selectedItemImage.sprite = item.Sprite;
    }

    private void UnselectItem() {
        _selectedItem = null;
    }

    private void PlaceDownItem() {
        if (_selectedItem) {
            GameObject item = Instantiate(_itemPrefab, GetWorldPositionFromMousePosition(), Quaternion.identity);
            item.GetComponent<SpriteRenderer>().sprite = _selectedItem.Sprite;
        }
        UnselectItem();
        CloseShop();
    }

    private void OpenShop() {
        SetOpen(true);
        _isClosedTemporarly = false;
    }

    private void CloseShop() {
        SetOpen(false);
        _isClosedTemporarly = false;
    }

    private void CloseShopTemporarly() {
        if (!_isClosedTemporarly) {
            SetOpen(false);
            _isClosedTemporarly = true;
        }
    }

    public void SetOpen(bool isOpen) {
        _isOpen = isOpen;
        UpdateAnimator();
    }

    public void Toggle() {
        SetOpen(!_isOpen);
    }
}
