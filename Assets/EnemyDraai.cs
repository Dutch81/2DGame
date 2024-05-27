using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipAtWaypoints : MonoBehaviour
{
    [SerializeField] private WaypointFollower waypoint;
    [SerializeField] private int waypointAIndex = 0;
    [SerializeField] private int waypointBIndex = 1;

    private bool isFacingRight = true;

    private void Update()
    {
        if (waypoint != null)
        {
            if (waypoint.currentWaypointIndex == waypointAIndex && !isFacingRight)
            {
                Flip();
            }
            else if (waypoint.currentWaypointIndex == waypointBIndex && isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            Debug.LogWarning("WaypointFollower is not assigned in the FlipAtWaypoints script.");
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
