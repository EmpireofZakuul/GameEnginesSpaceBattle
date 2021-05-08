using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Stay In Border")]
public class StayWithinBorders : FlockBehaviour
{

  public Vector3 center;
  public float radius = 15f;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector3 centerPoint = center - agent.transform.position;
        float t = centerPoint.magnitude / radius;
        if(t < 0.8f)
        {
            return Vector3.zero;
        }
        return centerPoint * Mathf.Pow(t, 2);
    }
}
