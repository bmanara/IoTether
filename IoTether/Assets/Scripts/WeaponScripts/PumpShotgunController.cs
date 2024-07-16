using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpShotgunController : RangedWeapon
{
    protected override void Init()
    {
        base.Init();
        bulletForce = 20f;
        fireRate = 1.6f;
        canFire = 0.1f;
        energyCost = 3;
        damage = 1;
        force = 10f;
    }

    public override void Shoot()
    {
        bool canShoot = PlayerControllers.Instance.GetComponent<PlayerEnergy>().DecreaseEnergy(energyCost);
        if (canShoot)
        {
            float spreadAngle = -15;
            for (int i = 0; i < 5; i++)
            {
                GameObject bullet = PlayerBulletController.Create(bulletPrefab, firePoint, damage, force);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                bullet.transform.rotation *= Quaternion.Euler(0, 0, spreadAngle);
                Vector3 dir = bullet.transform.right;

                rb.AddForce(dir * bulletForce, ForceMode2D.Impulse);
                GetComponent<AudioSource>().Play();

                spreadAngle += 9;
            }
        }
    }
}
