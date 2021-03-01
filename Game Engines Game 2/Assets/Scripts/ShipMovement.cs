using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Vector3 shipVelocity;
    public float shipSpeed;
    public Vector3 shipAcceleration;
    public Vector3 shipForce;
    public float maxSpeed = 10;
    public float maxForce = 20;

    public float shipsMass = 1;

   // public bool seekEnabled = true;
   // public Transform seekTargetTransform;
   // public Vector3 seekTarget;

    public float shipSlowingDistance = 80;
    public WayPoints points;
    public bool pathFollowingEnabled = false;
    public float waypointAmount = 3;
    // Banking
    public float shipBanking = 0.1f;

    public float damping = 0.1f;
  
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + shipVelocity);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + shipAcceleration);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + shipForce * 10);

    }


    public Vector3 PathFollow()
    {
        Vector3 nextWaypoint = points.NextPoint();
        if (!points.loopedWaypoint && points.LastPoint())
        {
            return Arrive(nextWaypoint);
        }
        else
        {
            if (Vector3.Distance(transform.position, nextWaypoint) < waypointAmount)
            {
                points.MoveToNext();
            }
            return Seek(nextWaypoint);
        }
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        Vector3 desired = toTarget.normalized * maxSpeed;

        return (desired - shipVelocity);
    }

    public Vector3 Arrive(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        float distance = toTarget.magnitude;
        float ramped = (distance / shipSlowingDistance) * maxSpeed;
        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desired = (toTarget / distance) * clamped;

        return desired - shipVelocity;
    }

    public Vector3 CalculateForce()
    {
        Vector3 d = Vector3.zero;
        /*if (seekEnabled)
        {
            if (seekTargetTransform != null)
            {
                seekTarget = seekTargetTransform.position;
            }
            f += Seek(seekTarget);
        }
        */
       

        if (pathFollowingEnabled)
        {
            d += PathFollow();
        }

        return d;
    }

    // Update is called once per frame
    void Update()
    {
        shipForce = CalculateForce();
        shipAcceleration = shipForce / shipsMass;
        shipVelocity = shipVelocity + shipAcceleration * Time.deltaTime;
        transform.position = transform.position + shipVelocity * Time.deltaTime;
        shipSpeed = shipVelocity.magnitude;
        if (shipSpeed > 1)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (shipAcceleration * shipBanking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + shipVelocity, tempUp);
       
            shipVelocity -= (damping * shipVelocity * Time.deltaTime);
        }
        else
        {
            shipSpeed = 0;
        }

        
    }
}
