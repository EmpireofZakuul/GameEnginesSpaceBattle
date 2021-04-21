using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireShipShooting : MonoBehaviour
{
    [Header("Ship Tracking")]
    public Transform sensorRay;
    public float RayDist = 10;
    public bool targetFound = false;
    public bool GunsRotated = false;
    public bool GunFiringLoop = false;
    public RaycastHit hit;


    [Header("Ship Firing")]
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public GameObject projectile;
    public Transform bulletSpawn;
    public float speed = 20;

    public GameObject[] empties;
    public GameObject[,] fireSquence;
    public int numberOfRows;
    public int numberOfColumns;

    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    [Header("Ship audio")]
    public AudioSource AudioSource;
    public AudioSource AudioSource2;
    public bool audioOn = false;
    public AudioManager AudioManager;


    ObjectPool objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPool.Instance;
        AudioSource.GetComponent<AudioSource>();
        AudioSource2.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       

        Debug.DrawRay(this.transform.position, transform.forward * RayDist, Color.red);


        if (Physics.Raycast(this.transform.position, transform.forward, out hit, RayDist))
        {
            

            if (hit.collider.gameObject.tag == "EternalEnemy")
            {
                Debug.Log(hit.point);
                targetFound = true;

                if(targetFound && !audioOn )
                {
                   
                    audioOn = true;
                    AudioSource2.Play();
                    timerIsRunning = true;
                }
                
            }

        }
        

        if (targetFound && !GunFiringLoop)
        {
            nextTimeToFire += Time.deltaTime;
            if (nextTimeToFire >= fireRate)//testing 
            {
                nextTimeToFire = 0;
                StartCoroutine(Fire());

            }
        }

        /*if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                
                timeRemaining = 0;
                timerIsRunning = false;
                AudioManager.Play("MaximumFire");
            }
        }
        */

    }


    public IEnumerator Fire()
    {
        
        GunFiringLoop = true;
        while (true)
        {
            GunFiringLoop = true;
            objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
            AudioSource.Play();

            yield return new WaitForSeconds(1.5f);

         
        }

    }

    public void Firing()
    {
        fireSquence = new GameObject[numberOfRows,numberOfColumns];

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
               //an array of empties numbering from 0 to 64
               // add empties to turrets
               // then cycle through each turret and fire its guns in squence
               // and use object pooling to fire the guns
            }
        }
    }

}

