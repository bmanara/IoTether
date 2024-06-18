using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MeleeWeapon
{
    protected override void Init()
    {
        base.Init();
        attackSpeed = 0.2f;
        delay = 0.5f;
        damage = 1;
        force = 8f;
    }
}
