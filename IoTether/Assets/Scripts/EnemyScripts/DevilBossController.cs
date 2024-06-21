using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBossController : Enemy
{
    public GameObject projectile;
    protected Transform firePoint;

    protected override void Init()
    {
        base.Init();
        health = 120;
        // ai.speed = 1;
        damage = 1;

        energyDrop = 100;
        healthDrop = 2;

        firePoint = transform.Find("FirePoint");
    }

    public void Attack()
    {
        GameObject bullet = EnemyBulletController.Create(projectile, firePoint, damage);
    }
}
