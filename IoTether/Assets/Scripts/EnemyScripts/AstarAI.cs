using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AstarAI : MonoBehaviour
{
    public Transform targetPosition;
    public Path path;
    protected Seeker seeker;
    protected Animator animator;

    public float speed; // must set to enemy speed instead.
    public float nextWaypointDistance = 0.1f;
    protected int currentWaypoint = 0;
    protected bool reachedEndOfPath;
    protected float updatePathRate = 0.5f;

    public void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        targetPosition = GameObject.Find("PlayerParent").transform;
        seeker = GetComponent<Seeker>();
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
        animator = GetComponentInChildren<Animator>();
        InvokeRepeating("UpdatePath", 0f, updatePathRate); // Better to use coroutine, will do ltr
    }

    protected void UpdatePath()
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

    public virtual void Update()
    {
        if (path == null)
        {
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
        // animator.SetBool("isMoving", true);
    }
}
