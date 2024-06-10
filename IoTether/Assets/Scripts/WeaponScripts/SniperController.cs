using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperController : RangedWeapon
{
    protected override void Init()
    {
        base.Init();
        bulletForce = 30f;
        fireRate = 2f;
        canFire = 0.1f;
        energyCost = 3;
        damage = 4;
        force = 15f;
    }
}
