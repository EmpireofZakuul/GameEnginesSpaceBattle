using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/Behaviour/Cohesion")]
public class FlockCohesion : FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if(context.Count == 0)
            return Vector3.zero;

            Vector3 cohesionFlockMove = Vector3.zero;
            foreach(Transform item in context)
            {
            cohesionFlockMove += item.position;
            }

        cohesionFlockMove /= context.Count;

        
        cohesionFlockMove -= agent.transform.position;
        return cohesionFlockMove;

    }

}
