using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
public class FlockAvoidance : FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return Vector3.zero;

        Vector3 avoidanceFlockMove = Vector3.zero;
        int numberToAvoid = 0;
        foreach (Transform item in context)
        {
            //might have to change to greater then or less then, video used less then
            if(Vector3.SqrMagnitude(item.position - agent.transform.position) < flock._squaredAdvanceRadius)
            {
                numberToAvoid++;
                avoidanceFlockMove += agent.transform.position = item.position;
            }
           
        }

        if (numberToAvoid > 0)
            avoidanceFlockMove /= numberToAvoid;

            return avoidanceFlockMove;

    }
}
