using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RangedEnemy : Enemy
{
    public GameObject projectile;
    protected Transform firePoint;
    public float projectileSpeed;
    public float fireRate;
    private float nextFire = 0.1f;

    protected override void Update()
    {
        base.Update();

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
        GameObject bullet = BulletController.Create(projectile, firePoint, damage, 0f, false);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce((player.transform.position - transform.position).normalized * projectileSpeed, ForceMode2D.Impulse);
        // Play audio?
    }
}
