using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : RangedWeapon
{
    protected override void Init()
    {
        base.Init();
        bulletForce = 12f;
        fireRate = 0.4f;
        canFire = 0.1f;
        energyCost = 1;
    }
}
