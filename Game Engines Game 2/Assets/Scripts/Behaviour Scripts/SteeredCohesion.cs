using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/SteeredCohesion")]
public class SteeredCohesion : FlockBehaviour
{

    Vector3 currentVelocity;
    public float agentSmootedTime = 1f;
        public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
                return Vector3.zero;

            Vector3 cohesionFlockMove = Vector3.zero;
            foreach (Transform item in context)
            {
                cohesionFlockMove += item.position;
            }

            cohesionFlockMove /= context.Count;


            cohesionFlockMove -= agent.transform.position;
            cohesionFlockMove = Vector3.SmoothDamp(agent.transform.up, cohesionFlockMove, ref currentVelocity, agentSmootedTime);
            return cohesionFlockMove;

        }
    

}