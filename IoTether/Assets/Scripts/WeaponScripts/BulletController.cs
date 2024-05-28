using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int damage = 5;
    private float knockbackForce = 10f;
    public GameObject impactEffect;

    private void Impact()
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // All enemies will be damageable... right?
            IDamageable damageable = collision.GetComponent<IDamageable>();
            Impact();
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();

            Vector2 direction = (collision.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;
            damageable.DecreaseHealth(damage, knockback);
        }
        else if (collision.gameObject.tag != "Player"
            && collision.gameObject.tag != "Props")
        {
            Impact();
        }

        Destroy(gameObject, 2f);
    }
}
