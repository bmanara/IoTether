using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSkeletonController : Enemy
{
    protected override void Init()
    {
        base.Init();
        health = 2;
        speed = 3;
        damage = 1;
    }
}
