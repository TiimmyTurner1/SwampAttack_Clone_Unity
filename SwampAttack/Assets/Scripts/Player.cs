using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _money;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private DiedPanel _diedPanel;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
    private Animator _animator;
    
    public int Money => _money;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<Weapon> WeaponChanged;

    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
            _animator.Play("GunShoot");
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            _diedPanel.ActivatePanel();
        }
                 
    }

    public void Heal(int value)
    {
        if (_health - _currentHealth <= value)
        {
            _currentHealth = _health;
        }
        else
        {
            _currentHealth += value;
        }

        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        _money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChanged?.Invoke(Money);
    }

    public void BuyPotion(HealthPotion potion)
    {
        _money -= potion.Price;        
        MoneyChanged?.Invoke(Money);        
    }

    public void NextWeapon()
    {
        if(_currentWeaponNumber == _weapons.Count - 1)        
            _currentWeaponNumber = 0;        
        else        
            _currentWeaponNumber++;        

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)        
            _currentWeaponNumber = _weapons.Count - 1;        
        else        
            _currentWeaponNumber--;        

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;        
        WeaponChanged?.Invoke(weapon);
    }
}
