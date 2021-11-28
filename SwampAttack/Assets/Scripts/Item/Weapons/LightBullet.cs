using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBullet : Bullet
{
    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);

            Destroy(gameObject);
        }
    }
}
