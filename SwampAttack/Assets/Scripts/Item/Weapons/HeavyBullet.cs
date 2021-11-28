using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : Bullet
{    
    [SerializeField] private float _forceRange;
    [SerializeField] private float _forceSpread;

    public float Force => _forceRange;

    private void Start()
    {
        _forceRange += Random.Range(-_forceSpread, _forceSpread);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);            
            Destroy(gameObject);
        }
    }
}
