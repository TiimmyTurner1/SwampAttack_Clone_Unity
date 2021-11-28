using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected string _label;
    [SerializeField] protected int _price;
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected bool _isBought = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBought => _isBought;
}
