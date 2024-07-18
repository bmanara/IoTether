using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizardController : RangedEnemy
{
    protected override void Init()
    {
        base.Init();

        health = 6;
        ai.speed = 3;
        damage = 1;

        energyDrop = 6;
        healthDrop = 0;

        projectileSpeed = 10;
        fireRate = 1.5f;
        firePoint = transform.Find("Weapon").transform.Find("FirePoint");
        range = 10f;
    }
}
