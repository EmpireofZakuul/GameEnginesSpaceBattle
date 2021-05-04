using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurveWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
    private Vector3 gizmosPosition;

    public void OnDrawGizmos()
    {
        for (float a = 0; a <= 1; a += 0.05f)
        {
               gizmosPosition = Mathf.Pow(1 - a, 3) * waypoints[0].position +
             3 * Mathf.Pow(1 - a, 2) * a * waypoints[1].position +
              3 * (1 - a) * Mathf.Pow(a, 2) * waypoints[2].position +
             Mathf.Pow(a, 3) * waypoints[3].position;

           

            Gizmos.DrawSphere(gizmosPosition, 5f);
        }

        Gizmos.DrawLine(new Vector3(waypoints[0].position.x, waypoints[0].position.y, waypoints[0].position.z),
            new Vector3(waypoints[1].position.x, waypoints[1].position.y, waypoints[1].position.z));

        Gizmos.DrawLine(new Vector3(waypoints[2].position.x, waypoints[2].position.y, waypoints[2].position.z),
            new Vector3(waypoints[3].position.x, waypoints[3].position.y, waypoints[3].position.z));
    }
}
