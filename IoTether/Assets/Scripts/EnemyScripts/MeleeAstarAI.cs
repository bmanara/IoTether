using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAstarAI : AstarAI
{
    public int range;
    public override void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, targetPosition.transform.position);
        if (distanceToPlayer > range)
        {
            // if enemy not detected, don't move
            animator.SetBool("isMoving", false);
            return;
        }

        base.Update();
    }
}
