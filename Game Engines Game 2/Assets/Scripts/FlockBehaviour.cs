using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviour : ScriptableObject
{
    //TODO:was a vector 2, but i changed it to vector 3
    public abstract Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock);
}
