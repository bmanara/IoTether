using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailController : Enemy
{
    protected override void Init()
    {
        base.Init();
        health = 150;
        ai.speed = 0.3f;
        damage = 10;
        energyDrop = 150;
        healthDrop = 0;
    }
}
