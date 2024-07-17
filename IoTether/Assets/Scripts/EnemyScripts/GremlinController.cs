using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinController : Enemy
{
    protected override void Init()
    {
        base.Init();
        health = 6;
        ai.speed = 2;
        damage = 1;
        energyDrop = 8;
        healthDrop = 0;
    }
}
