using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeaponView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.WeaponChanged += ChangeWeaponIcon;
    }

    private void OnDisable()
    {
        _player.WeaponChanged -= ChangeWeaponIcon;
    }

    private void ChangeWeaponIcon(Weapon weapon)
    {
        _icon.sprite = weapon.Icon;
    }
}
