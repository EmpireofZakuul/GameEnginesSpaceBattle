using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireShipShooting : MonoBehaviour
{
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public GameObject projectile;
    public Transform bulletSpawn;
    public float speed = 20;
    ObjectPool objectPooler;
   
    


    void Start()
    {
        objectPooler = ObjectPool.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)//testing 
         {
             nextTimeToFire = Time.time + 1 / fireRate;
             Shoot();
         }
        */

        nextTimeToFire += Time.deltaTime;
        if (nextTimeToFire >= fireRate)//testing 
        {
            nextTimeToFire = 0;
            Shoot();
        }
    }

    public void Shoot()
    {
        objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
       
    }

    /*public void Shoot()
    {
       
        GameObject bullet = Instantiate(projectile);
       
        bullet.transform.position = bulletSpawn.position;
        Quaternion rotation = transform.rotation;
        //bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * speed, ForceMode.Impulse);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * speed, ForceMode.Impulse);


    }
    */
}

