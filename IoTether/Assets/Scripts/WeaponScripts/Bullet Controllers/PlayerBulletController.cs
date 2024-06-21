using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour, IBulletController
{
    public int Damage { get; set; }
    public GameObject ImpactEffect;
    public float KnockbackForce { get; set; }

    public static GameObject Create(GameObject bulletPrefab, Transform firePoint, int damage, float KnockbackForce)
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        PlayerBulletController bulletController = bullet.GetComponent<PlayerBulletController>();
        bulletController.Damage = damage;
        bulletController.KnockbackForce = KnockbackForce;
        return bullet;
    }

    public void Impact()
    {
        Destroy(gameObject);
        Instantiate(ImpactEffect, transform.position, transform.rotation);

    }

    public bool CanImpact(Collider2D collision)
    {
        return collision.gameObject.tag != "Player"
           && collision.gameObject.tag != "Props"
           && collision.gameObject.tag != "Bullet"
           && collision.gameObject.tag != "Ignore";
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            Impact();
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            Vector2 knockback = direction * KnockbackForce;
            damageable.DecreaseHealth(Damage, knockback);
        }
        else if (CanImpact(collision))
        {
            Impact();
        }
    }

}
    
