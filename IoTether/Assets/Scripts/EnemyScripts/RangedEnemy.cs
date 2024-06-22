using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class RangedEnemy : Enemy
{
    public GameObject projectile;
    protected Transform firePoint;
    public float projectileSpeed;
    public float fireRate;
    private float nextFire = 0.1f;
    protected float range;

    protected override void Update()
    {
        base.Update();

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < range && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = EnemyBulletController.Create(projectile, firePoint, damage);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce((player.transform.position - transform.position).normalized * projectileSpeed, ForceMode2D.Impulse);
        // Play audio?
    }
}
