using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UZI : Weapon
{
    [SerializeField] private int _burstLength;

    public override void Shoot(Transform shootPosition)
    {
        for (int i = 0; i < _burstLength; i++)
        {
            Instantiate(Bullet, shootPosition.position, Quaternion.identity);
        }
    }
}
