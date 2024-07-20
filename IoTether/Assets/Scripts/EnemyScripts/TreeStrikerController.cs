using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeStrikerController : RangedEnemy
{
    private bool active = true;
    protected override void Init()
    {
        base.Init();
        health = 10;
        ai.speed = 0;
        damage = 1;

        energyDrop = 20;
        healthDrop = 0;

        projectileSpeed = 6;
        fireRate = 3f;
        firePoint = transform.Find("FirePoint");
        range = 20f;
    }

    protected override void Shoot()
    {
        if (active)
        {
            MissileController.Create(projectile, firePoint, damage);
        }
    }

    protected override void KillSelf()
    {
        if (!active)
        {
            return;
        }

        active = false;
        DropEnergy();
        health = 10; // Reset health
        Invoke("Reset", 10f);
    }

    private void Reset()
    {
        active = true;
        ResetMaterial();
    }
}
