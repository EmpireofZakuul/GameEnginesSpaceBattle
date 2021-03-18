using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EternalFleetFire : MonoBehaviour
{
    [Header("Ship Tracking")]
    public Transform sensorRay;
    public float RayDist = 10;
    public bool targetFound = false;

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
        RaycastHit hit;

        Debug.DrawRay(this.transform.position, Vector3.left * 10000, Color.green);


        if (Physics.Raycast(this.transform.position, Vector3.left , out hit, RayDist))
        {
            Debug.Log("casting ray");
            
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log(hit.point);
                targetFound = false;
                //transform.Rotate.y = hit.point;
            }

        }
        if (!targetFound)
        {
            //transform.rotation =  Quaternion.Euler(0, hit.point, 0);
           //transform.localEulerAngles = new Vector3(0, hit.point, 0);
            targetFound = true;
        }

        if (targetFound)
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
