using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] protected Bullet Bullet;
    public abstract void Shoot(Transform shootPosition);    

    public void Bought()
    {
        _isBought = true;
    }
}
