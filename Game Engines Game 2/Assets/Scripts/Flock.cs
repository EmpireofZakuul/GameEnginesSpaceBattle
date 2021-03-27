using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
     [Header("Flocking")]
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;

    [Range(10,100)]
    public int shipStartCount = 40;
    const float shipDensity = 0.0f;
    [Range(1f,100f)]
    public float driveFactor = 10f;
    [Range(1f,10f)]
    public float ShipMaxSpeed = 10;
    public float neighborRadius = 1.5f; 
     [Range(1f,1f)]
    public float ShipAdvidanceRadiusMultiplier = 0.5f; 
  
    float neighborRadiusSquared;
    float ShipAdvidanceRadiusSquared;


    [Header("Spawning Ships")]
    public int enemyAmoundMax = 10;
    
    public  int count = 0;
    public  int totalcount = 0;
    public GameObject[] spawnPoints;
    private GameObject currentPoint;
    private int EnemyIndex;
    public bool spawning =  true;
      ObjectPool objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        neighborRadiusSquared = neighborRadius * neighborRadius;
        ShipAdvidanceRadiusSquared = neighborRadiusSquared * ShipAdvidanceRadiusMultiplier * ShipAdvidanceRadiusMultiplier;


        
        InvokeRepeating("SpawnEnemy", 2f,2f);
         objectPooler = ObjectPool.Instance;
    }
    
 
    // Update is called once per frame
      void Update()
    {



        #region total amount
        if(totalcount == 20)
        {
            spawning = false;
        
        }
        #endregion
    }
  
    #region  spawning
   public void SpawnEnemy()
   {
       if(totalcount < enemyAmoundMax && spawning == true)
        {
        
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        EnemyIndex = Random.Range(0, spawnPoints.Length);
        objectPooler.SpawnFromPool("Fighter", transform.position, transform.rotation);
        currentPoint = spawnPoints[EnemyIndex];
        totalcount++;
        }return;

   }
   #endregion

}

