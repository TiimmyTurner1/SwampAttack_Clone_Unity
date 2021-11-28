using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;    

    private Player _target;
    

    public int Health => _health;
    public int Reward => _reward;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    public void Init(Player target)
    {
        _target = target;        
    }

    public void ApplyDamage(int damage)
    {        
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
        }
    }
}
