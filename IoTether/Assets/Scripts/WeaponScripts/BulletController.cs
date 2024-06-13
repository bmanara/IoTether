using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int damage; // damage will be determined by the weapon
    private float knockbackForce; // knockbackForce will be determined by the weapon
    public GameObject impactEffect;
    private bool isFriendly;

    public static GameObject Create(GameObject bulletPrefab, Transform firePoint, int damage, float knockbackForce, bool isFriendly)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletController>().damage = damage;
        bullet.GetComponent<BulletController>().knockbackForce = knockbackForce;
        bullet.GetComponent<BulletController>().isFriendly = isFriendly;
        return bullet;
    }

    private void Impact()
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
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
            else if (collision.gameObject.tag != "Player"
                && collision.gameObject.tag != "Props"
                && collision.gameObject.tag != "Bullet")
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
            else if (collision.gameObject.tag != "Enemy"
                && collision.gameObject.tag != "Props"
                && collision.gameObject.tag != "Bullet")
            {
                Impact();
            }
        }


        Destroy(gameObject, 5f);
    }
}
