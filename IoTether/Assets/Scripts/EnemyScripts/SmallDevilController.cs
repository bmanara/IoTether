using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDevilController : Enemy
{
    protected override void Init()
    {
        base.Init();
        health = 4;
        speed = 2;
        damage = 1;
    }

}
