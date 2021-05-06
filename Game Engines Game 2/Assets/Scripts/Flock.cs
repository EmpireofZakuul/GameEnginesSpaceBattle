using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [Header("Flocking")]
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;

    [Range(10,200)]
    public int shipStartCount = 40;
    [Range(0f, 10f)]
    public float shipDensity = 0.1f;
    [Range(1f,100f)]
    public float driveFactor = 10f;
    [Range(1f,100f)]
    public float ShipMaxSpeed = 10;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f; 
    [Range(0f,1f)]
    public float ShipAdvidanceRadiusMultiplier = 0.5f; 
  
    float _neighborRadiusSquared;
    float _ShipAdvidanceRadiusSquared;
    float _squaredMaxSpeed;
    public float _squaredAdvanceRadius { get { return _neighborRadiusSquared; } }

  //  public Transform target;
   // public bool getTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        _squaredMaxSpeed = ShipMaxSpeed * ShipMaxSpeed;
        _neighborRadiusSquared = neighborRadius * neighborRadius;
        _ShipAdvidanceRadiusSquared = _neighborRadiusSquared * ShipAdvidanceRadiusMultiplier * ShipAdvidanceRadiusMultiplier;

        for (int i = 0; i < shipStartCount; i++)
        {
            FlockAgent shipAgent = Instantiate(
                agentPrefab,
                //transform.position,
                Random.insideUnitSphere * shipStartCount * shipDensity, 
                Quaternion.Euler(Vector3.zero),
                //transform.rotation,
                transform
                ); 

            shipAgent.name = "ShipAgent" + i;
            agents.Add(shipAgent);
        }
        
       
    }
    
 
    // Update is called once per frame
      void FixedUpdate()
      { 

       foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearByObjects(agent);

            Vector3 shipMove = behaviour.CalculateMove(agent, context, this);
            shipMove *= driveFactor;
            if (shipMove.sqrMagnitude > _squaredMaxSpeed)
            {
                shipMove = shipMove.normalized * ShipMaxSpeed;
            }
            agent.MoveShip(shipMove);

          //  if (getTarget)
           // {
              //  agent.TargetShip();
           // }
        }

       
       
      }

  
   List<Transform> GetNearByObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] colliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
        foreach(Collider collider in colliders)
        {
            if(collider != agent.AgentCollider)
            {
                context.Add(collider.transform);//is this adding the collider to the fighter,if is its not 
            }
        }
        return context;
    }
       

}

