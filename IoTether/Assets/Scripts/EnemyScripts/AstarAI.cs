using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarAI : MonoBehaviour
{
    public Transform targetPosition;
    public Path path;
    private Seeker seeker;
    private Animator animator;

    public float speed; // must set to enemy speed instead.
    public float nextWaypointDistance = 0.1f;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath;
    private float updatePathRate = 0.5f;

    public void Start()
    {
        targetPosition = GameObject.Find("PlayerParent").transform;
        seeker = GetComponent<Seeker>();
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
        animator = GetComponentInChildren<Animator>();
        InvokeRepeating("UpdatePath", 0f, updatePathRate); // Better to use coroutine, will do ltr
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
        }
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        } else
        {
            Debug.Log(p.error);
        }
    }

    public void Update()
    {
        if (path == null)
        {
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, targetPosition.transform.position);

        if (distanceToPlayer > 10)
        {
            animator.SetBool("isMoving", false);
            return;
        }

        reachedEndOfPath = false;
        float distanceToWaypoint;

        while (true)
        {
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    reachedEndOfPath = true;
                    break;
                }
            } else
            {
                break;
            }
        }

        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        Vector3 velocity = dir * speed * speedFactor;

        transform.position += velocity * Time.deltaTime;
        animator.SetBool("isMoving", true);
    }
}
