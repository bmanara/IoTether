using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailController : Enemy
{
    protected override void Init()
    {
        base.Init();
        health = 150;
        ai.speed = 0.5f;
        damage = 10;
        energyDrop = 150;
        healthDrop = 0;
    }
}
