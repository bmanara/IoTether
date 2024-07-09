using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RifleController : RangedWeapon
{
    protected override void Init()
    {
        base.Init();
        bulletForce = 15f;
        fireRate = 0.4f;
        canFire = 0.1f;
        energyCost = 2;
        damage = 2;
        force = 10f;
    }

    // Update is overriden to allow for automatic fire
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
