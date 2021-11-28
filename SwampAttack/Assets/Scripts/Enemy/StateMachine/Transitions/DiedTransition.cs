using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedTransition : Transition
{
    private int _enemyHealth;
    
    void Update()
    {
        _enemyHealth = GetComponent<Enemy>().Health;

        if (_enemyHealth <= 0)
        {
            NeedTransit = true;
        }
    }
}
