using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBossController : RangedEnemy
{
    protected override void Init()
    {
        base.Init();
        health = 100;
        // ai.speed = 1;
        damage = 1;

        energyDrop = 100;
        healthDrop = 2;

        projectileSpeed = 6;
        fireRate = 0.5f;
        firePoint = transform.Find("FirePoint");

        range = 30f;
    }
}
