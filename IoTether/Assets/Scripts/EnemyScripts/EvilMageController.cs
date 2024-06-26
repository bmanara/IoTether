using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMageController : RangedEnemy
{
    protected override void Init()
    {
        base.Init();
        health = 3;
        ai.speed = 3;
        damage = 1;

        energyDrop = 2;
        healthDrop = 0;

        projectileSpeed = 6;
        fireRate = 2;
        firePoint = transform.Find("FirePoint");
        range = 7f;
    }
}
