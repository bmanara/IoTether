using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int damage = 1;
    private float knockbackForce = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // All enemies will be damageable... right?
            IDamageable damageable = collision.GetComponent<IDamageable>();
            Destroy(gameObject);
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();

            Vector2 direction = (collision.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;
            damageable.DecreaseHealth(damage, knockback);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 2f);
    }
}
