using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstRifleController : RangedWeapon
{
    protected override void Init()
    {
        base.Init();

        bulletForce = 15f;
        fireRate = 0.7f;
        canFire = 0.1f;
        energyCost = 1;
        damage = 1;
        force = 7f;
    }

    public override void Shoot()
    {
        Debug.Log("Shoot");
        StartCoroutine("BurstShot");
    }

    private IEnumerator BurstShot()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(i);
            base.Shoot();
            yield return new WaitForSeconds(0.15f);
        }
    }
}
