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
        fireRate = 0.2f;
        canFire = 0.1f;
        energyCost = 1;
    }

    // Update is overriden to allow for automatic fire
    protected override void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > canFire)
        {
            base.Shoot();
            canFire = Time.time + fireRate;
        }
    }
}
