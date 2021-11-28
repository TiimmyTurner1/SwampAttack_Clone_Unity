using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private int _healValue;    

    public void Heal(Player player)
    {
        player.Heal(_healValue);
    }
}
