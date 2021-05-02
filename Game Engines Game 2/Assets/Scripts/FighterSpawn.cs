using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSpawn : MonoBehaviour
{
    public int enemyAmoundMax = 10;
    public int totalcount = 0;
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;
    private GameObject currentPoint;
    private int EnemyIndex;
    public bool isFound;
    public bool spawning = false;

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
       while(totalcount <= 20)
       {
            EnemyIndex = Random.Range(0, spawnPoints.Length);
            currentPoint = spawnPoints[EnemyIndex];
            enemyPrefab = Instantiate(enemyPrefab, currentPoint.transform.position, currentPoint.transform.rotation) as GameObject;
            totalcount++;
            enemyPrefab.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(2);
       }

    }
}
