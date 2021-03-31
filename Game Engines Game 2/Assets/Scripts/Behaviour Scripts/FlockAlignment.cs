using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class FlockAlignment : FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return agent.transform.up;

        Vector3 alignmentFlockMove = Vector3.zero;
        foreach (Transform item in context)
        {
            alignmentFlockMove += item.up;
        }

        alignmentFlockMove /= context.Count;

        return alignmentFlockMove;

    }
}
