using UnityEngine;

public class ShopMenuUI : MonoBehaviour {
    [SerializeField] private Animator _animator;
    [SerializeField] private RectTransform _contentTransform;
    [SerializeField] private GameObject _shopItemPrefab;

    // test variables, remove later
    [SerializeField] private Sprite _testSprite;

    private bool _isOpen = false;

    private static readonly int IS_OPEN_ID = Animator.StringToHash("IsOpen");

    private void Start() {
        UpdateAnimator();
        AddItems();
    }

    private void AddItems() {
        GameObject testGo = Instantiate(_shopItemPrefab, _contentTransform);
        testGo.GetComponent<ShopItemUI>().Init(_contentTransform, _testSprite);
    }

    private void UpdateAnimator() {
        _animator.SetBool(IS_OPEN_ID, _isOpen);
    }

    public void Toggle() {
        _isOpen = !_isOpen;
        UpdateAnimator();
    }
}
