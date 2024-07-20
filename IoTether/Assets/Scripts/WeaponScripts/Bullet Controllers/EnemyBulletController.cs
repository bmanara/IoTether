using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBulletController : BulletController
{
    public static GameObject Create(GameObject bulletPrefab, Transform firePoint, int damage)
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        EnemyBulletController bulletController = bullet.GetComponent<EnemyBulletController>();
        bulletController.Damage = damage;
        return bullet;
    }


    public override bool CanImpact(Collider2D collision)
    {
        return collision.gameObject.tag != "Enemy"
           && base.CanImpact(collision);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IDamageable damageable = collision.transform.parent.gameObject.GetComponent<IDamageable>();
            Impact();
            damageable.DecreaseHealth(Damage);
        }
        else if (CanImpact(collision))
        {
            Impact();
        }
    }

}

