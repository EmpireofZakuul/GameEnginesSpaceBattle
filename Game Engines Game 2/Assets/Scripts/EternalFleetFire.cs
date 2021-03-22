using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EternalFleetFire : MonoBehaviour
{
    [Header("Ship Tracking")]
    public Transform sensorRay;
    public Transform gunPosition;
    public float RayDist = 10;
    public bool targetFound =  false;
    public bool GunsRotated = false;
    public bool GunFiringLoop = false;
    public RaycastHit hit;


    [Header("Ship Firing")]
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public GameObject projectile;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
    public Transform bulletSpawn4;
    public float speed = 20;


    ObjectPool objectPooler;
   
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPool.Instance;

        
       
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;

        Debug.DrawRay(this.transform.position, Vector3.left * 10000, Color.green);


        if (Physics.Raycast(this.transform.position, Vector3.left , out hit, RayDist))
        {
           
            
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log(hit.point);
                targetFound = true;
            }

        }
        if (targetFound )
        {
            //transform.rotation =  Quaternion.Euler(0, hit.point, 0);
            //transform.localEulerAngles = new Vector3(0, hit.point, 0);

            //Vector3 targetDir = hit.point - gunPosition.position;
           //transform.rotation =  Vector3.Angle(targetDir, Vector3.forward);

            //transform.rotation = Vector3.Angle(gunPosition, hit.point);

            // float angleToTarg = Vector3.Angle(transform.forward, gunPosition.transform.position - hit.point);
            // transform.rotation = angleToTarg;
            targetFound = true;
            GunsRotated = true;
        }
        //if any ships raycast hits the target, all ships roatae there guns and fire

       // else if ()
       //{

       //}

        if (targetFound && GunsRotated && !GunFiringLoop)
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

            yield return new WaitForSeconds(1.5f);

            objectPooler.SpawnFromPool("Bullet", bulletSpawn2.position, bulletSpawn.rotation);

            yield return new WaitForSeconds(1.5f);

            objectPooler.SpawnFromPool("Bullet", bulletSpawn3.position, bulletSpawn.rotation);

            yield return new WaitForSeconds(1.5f);

            objectPooler.SpawnFromPool("Bullet", bulletSpawn4.position, bulletSpawn.rotation);

            yield return new WaitForSeconds(1.5f);
        }
       
    }
   
}
