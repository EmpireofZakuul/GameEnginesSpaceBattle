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

    [Header("Ship audio")]
    public AudioSource AudioSource;
    public AudioSource AudioSource2;
    public bool audioOn = false;


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
       

        Debug.DrawRay(this.transform.position, Vector3.right * RayDist, Color.red);


        if (Physics.Raycast(this.transform.position, Vector3.right, out hit, RayDist))
        {
            

            if (hit.collider.gameObject.tag == "EternalEnemy")
            {
                Debug.Log(hit.point);
                targetFound = true;

                if(targetFound && !audioOn )
                {
                    AudioSource2.Play();
                    audioOn = true;
                    
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
}

