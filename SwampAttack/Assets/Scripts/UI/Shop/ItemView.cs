using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private Item _items;

    public event UnityAction<Item, ItemView> BuyButtonClick;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);
        _buyButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
        _buyButton.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (_items.IsBought)
        {
            _buyButton.interactable = false;
        }
    }

    public void Render(Item item)
    {
        _items = item;

        _label.text = item.Label;
        _price.text = item.Price.ToString();
        _icon.sprite = item.Icon;
    }

    private void OnBuyButtonClick()
    {
        BuyButtonClick?.Invoke(_items, this);
    }
}
