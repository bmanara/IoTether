using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBulletController : MonoBehaviour
{
    private int damage; // damage will be determined by the weapon
    private float knockbackForce; // knockbackForce will be determined by the weapon
    public GameObject impactEffect;
    private bool isFriendly;

    public static GameObject Create(GameObject bulletPrefab, Transform firePoint, int damage, float knockbackForce, bool isFriendly)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<OldBulletController>().damage = damage;
        bullet.GetComponent<OldBulletController>().knockbackForce = knockbackForce;
        bullet.GetComponent<OldBulletController>().isFriendly = isFriendly;
        return bullet;
    }

    private void Impact()
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }

    private bool CanPlayerImpact(Collider2D collision)
    {
        return collision.gameObject.tag != "Player"
            && collision.gameObject.tag != "Props"
            && collision.gameObject.tag != "Bullet"
            && collision.gameObject.tag != "Ignore";
    }

    private bool CanEnemyImpact(Collider2D collision)
    {
        return collision.gameObject.tag != "Enemy"
            && collision.gameObject.tag != "Props"
            && collision.gameObject.tag != "Bullet"
            && collision.gameObject.tag != "Ignore";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFriendly)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                // All enemies will be damageable... right?
                IDamageable damageable = collision.GetComponent<IDamageable>();
                Impact();

                Vector2 direction = (collision.transform.position - transform.position).normalized;
                Vector2 knockback = direction * knockbackForce;
                damageable.DecreaseHealth(damage, knockback);
            } 
            else if (CanPlayerImpact(collision))
            {
                Impact();
            }
        }
        else if (!isFriendly)
        {
            if (collision.gameObject.tag == "Player")
            {
                // ok wtf is this
                IDamageable damageable = collision.transform.parent.gameObject.GetComponent<IDamageable>();
                Impact();

                damageable.DecreaseHealth(damage);
            }
            else if (CanEnemyImpact(collision))
            {
                Impact();
            }
        }


        Destroy(gameObject, 5f);
    }
}
