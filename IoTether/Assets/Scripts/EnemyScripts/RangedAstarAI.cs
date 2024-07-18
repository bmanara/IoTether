using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAstarAI : AstarAI
{
    public int detectionRange;
    public int avoidRange;

    public override void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, targetPosition.transform.position);

        if (distanceToPlayer > detectionRange)
        {
            // if enemy not detected, don't move
            animator.SetBool("isMoving", false);
            return;
        }
        else if (distanceToPlayer < avoidRange)
        {
            // run away from player when too close
            transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, -speed * Time.deltaTime);
            return;
        }

        // else, move using path given by A* algorithm
        base.Update();
    }
}
