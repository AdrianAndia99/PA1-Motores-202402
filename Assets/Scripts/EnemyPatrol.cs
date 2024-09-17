using UnityEngine;
using System.Collections.Generic;

public class EnemyPatrol : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed = 5f;
    public float waitTime = 0.1f;
    private int currentWaypointIndex = 0;
    private bool isWaiting = false;
    private float waitTimer = 0f;
    public float rotationSpeed = 5f;

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                isWaiting = false;
                waitTimer = 0f;
            }
            return;
        }

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            RotateTowardsNextWaypoint();

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;

            isWaiting = true;
        }
    }

    void RotateTowardsNextWaypoint()
    {
        transform.Rotate(0f, 90f, 0f);
    }
}
