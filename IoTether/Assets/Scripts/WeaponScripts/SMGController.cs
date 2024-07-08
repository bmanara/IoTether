using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGController : RangedWeapon
{
    protected override void Init()
    {
        base.Init();
        bulletForce = 12f;
        fireRate = 0.2f;
        canFire = 0.1f;
        energyCost = 1;
        damage = 1; // should buff rifle?

        force = 6f;

    }

    protected override void Update()
    {
        if (GameManager.manager.gameIsPaused)
        {
            return;
        }

        if (Input.GetButton("Fire1") && Time.time > canFire)
        {
            base.Shoot();
            canFire = Time.time + fireRate;
        }
    }
}
