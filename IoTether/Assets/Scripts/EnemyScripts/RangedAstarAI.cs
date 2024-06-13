using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAstarAI : AstarAI
{
    public override void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, targetPosition.transform.position);

        if (distanceToPlayer > 10)
        {
            // if enemy not detected, don't move
            return;
        }
        else if (distanceToPlayer < 3)
        {
            // run away from player when too close
            transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, -speed * Time.deltaTime);
            return;
        }

        // else, move using path given by A* algorithm
        base.Update();
    }
}
