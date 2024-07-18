using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinController : Enemy
{
    protected override void Init()
    {
        base.Init();
        health = 6;
        ai.speed = 3;
        damage = 2;
        energyDrop = 8;
        healthDrop = 0;
    }
}
