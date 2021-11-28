using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private Player _player;
    [SerializeField] private ItemView _itemTemplate;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            AddItem(_items[i]);
        }
    }

    private void AddItem(Item item)
    {
        var view = Instantiate(_itemTemplate, _itemContainer.transform);
        view.BuyButtonClick += OnBuyButtonClick;
        view.Render(item);
    }

    private void OnBuyButtonClick(Item item, ItemView view)
    {
        if(item is Weapon)
        {
            TryBuyWeapon((Weapon)item, view);
        }
        else if(item is HealthPotion)
        {
            BuyPotion((HealthPotion)item);
        }
        
    }

    private void TryBuyWeapon(Weapon weapon, ItemView view)
    {
        if(weapon.Price <= _player.Money)
        {            
            _player.BuyWeapon(weapon);
            weapon.Bought();
            view.BuyButtonClick -= OnBuyButtonClick;
        }
    }

    private void BuyPotion(HealthPotion healthPotion)
    {
        _player.BuyPotion(healthPotion);
        healthPotion.Heal(_player);
    }
}
