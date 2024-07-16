using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBulletController : BulletController
{
    public int Damage { get; set; }
    public float KnockbackForce { get; set; }

    // unsupported, getting rid
    public static GameObject Create(GameObject bulletPrefab, Transform firePoint, int damage, float KnockbackForce)
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        PlayerBulletController bulletController = bullet.GetComponent<PlayerBulletController>();
        bulletController.Damage = damage;
        bulletController.KnockbackForce = KnockbackForce;
        return bullet;
    }

    public static GameObject Create(GameObject bulletPrefab, Vector3 pos, Quaternion rot, int damage, float KnockbackForce)
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, pos, rot);
        PlayerBulletController bulletController = bullet.GetComponent<PlayerBulletController>();
        bulletController.Damage = damage;
        bulletController.KnockbackForce = KnockbackForce;
        return bullet;
    }


    public override bool CanImpact(Collider2D collision)
    {
        return collision.gameObject.tag != "Player"
           && base.CanImpact(collision);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
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
    
