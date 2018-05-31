using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ShopItemUI : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private Image _image;

    private ItemData _item;

    public event Action<ItemData> ClickEvent = delegate { };

    public void SetItem(ItemData item) {
        _item = item;
        _image.sprite = item.Sprite;
    }

    public void OnPointerClick(PointerEventData eventData) {
        ClickEvent(_item);
    }
}
