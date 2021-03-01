using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();

    public int wayPointNext = 0;
    public bool loopedWaypoint = true;


    // Use this for initialization
    void Start()
    {
        waypoints.Clear();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            waypoints.Add(transform.GetChild(i).position);
        }
    }

    public Vector3 NextPoint()
    {
        return waypoints[wayPointNext];
    }

    public void MoveToNext()
    {
        if (loopedWaypoint)
        {
            wayPointNext = (wayPointNext + 1) % waypoints.Count;
        }
        else
        {
            if (wayPointNext != waypoints.Count - 1)
            {
                wayPointNext++;
            }
        }
    }

    public bool LastPoint()
    {
        return wayPointNext == waypoints.Count - 1;
    }

    public void OnDrawGizmos()
    {
        int count = loopedWaypoint ? (transform.childCount + 1) : transform.childCount;
        Gizmos.color = Color.cyan;
        for (int i = 1; i < count; i++)
        {
            Transform prevousPoint = transform.GetChild(i - 1);
            Transform nextPoint = transform.GetChild(i % transform.childCount);
            Gizmos.DrawLine(prevousPoint.transform.position, nextPoint.transform.position);
            Gizmos.DrawSphere(prevousPoint.position, 1);
            Gizmos.DrawSphere(nextPoint.position, 1);
        }
    }

}
