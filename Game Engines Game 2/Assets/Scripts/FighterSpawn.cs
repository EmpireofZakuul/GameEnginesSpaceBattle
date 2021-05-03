using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSpawn : MonoBehaviour
{
    public int enemyAmoundMax = 10;
    public int totalcount = 100;
    public int count = 0;
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;
    private GameObject currentPoint;
    private int EnemyIndex;
    public bool isFound;
    public bool spawning = false;
    public float waitTime = 1;

    public void OnEnable()
    {
      
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    public void Update()
    {
       
        if (spawning)
        {
            StartCoroutine(SpawnFigters());
            spawning = false;

        }

    }

    IEnumerator SpawnFigters()
    {
       while(count < totalcount)
       {
            EnemyIndex = Random.Range(0, spawnPoints.Length);
            currentPoint = spawnPoints[EnemyIndex];
            enemyPrefab = Instantiate(enemyPrefab, currentPoint.transform.position, currentPoint.transform.rotation) as GameObject;
            count++;
            enemyPrefab.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(waitTime);
       }

    }
}
