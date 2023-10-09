using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // this script will make an object follow a path

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 4f;
    private int waypointIndex = 0;


    private void Update()
    {

        // get the current waypoint
        GameObject currentWaypoint = waypoints[waypointIndex];

        // move the object towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.transform.position, speed * Time.deltaTime);

        // if the object is close enough to the waypoint, go to the next waypoint
        if (Vector2.Distance(transform.position, currentWaypoint.transform.position) < 0.1f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }

    }

}
