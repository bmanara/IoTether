using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDevilController : Enemy
{
    protected override void Init()
    {
        base.Init();
        health = 4;
        ai.speed = 2;
        damage = 1;
        ammoDrop = 6;
        healthDrop = 0;
    }

}
