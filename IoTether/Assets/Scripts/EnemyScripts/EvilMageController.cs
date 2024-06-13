using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMageController : Enemy
{
    protected override void Init()
    {
        base.Init();
        health = 3;
        ai.speed = 2;
        damage = 1;
    }
}
