using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepBackState : State
{
    [SerializeField] private HeavyBullet _heavyBullet;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-_heavyBullet.Force, 0));
    }
}
