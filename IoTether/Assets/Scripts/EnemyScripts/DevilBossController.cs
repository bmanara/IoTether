using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBossController : Enemy
{
    protected override void Init()
    {
        base.Init();
        health = 120;
        // ai.speed = 1;
        damage = 1;

        energyDrop = 100;
        healthDrop = 2;
    }
}
