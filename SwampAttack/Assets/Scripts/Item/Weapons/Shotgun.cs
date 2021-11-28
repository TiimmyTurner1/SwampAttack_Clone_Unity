using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform shootPosition)
    {
        Instantiate(Bullet, shootPosition.position, Quaternion.identity);
    }
}
