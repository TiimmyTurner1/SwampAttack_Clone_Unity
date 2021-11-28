using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class DiedState : State
{
    private Animator _animator;
    private BoxCollider2D _collider;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        _animator.Play("Died");
        _collider.isTrigger = false;
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = new Vector2(0, 0);

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
