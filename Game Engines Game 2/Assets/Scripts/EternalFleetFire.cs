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
    public bool targetFound = false;
    public bool GunsRotated = false;
    public bool GunFiringLoop = false;
    public RaycastHit hit;



    [Header("Ship Firing")]
    public float fireRate = 15f;
   // private float nextTimeToFire = 0f;
    public GameObject projectile;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
    public Transform bulletSpawn4;
    public float speed = 20;
    private Coroutine _fire;


    [Header("Timer")]
    public float timeRemaining = 20;
    public bool timerIsRunning = false;

    ObjectPool objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPool.Instance;
        timerIsRunning = true;


    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;




        if (Physics.Raycast(this.transform.position, Vector3.left, out hit, RayDist))
        {
            Debug.DrawRay(this.transform.position, Vector3.left * hit.distance, Color.green);

            if (hit.collider.gameObject.tag == "EmpireEnemy")
            {
                Debug.Log(hit.point);

                if (!targetFound)
                {
                    targetFound = true;
                    GunsRotated = true;
                    //RotateTurrets();
                    WhatEverShipoDoing(hit.transform);
                }
            }

        }

       /* if (timerIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {

                timeRemaining = 20;
                targetFound = false;
                //timerIsRunning = false;

            }
        }
       */


    }

    public void RotateTurrets(Transform target)
    {

        gunPosition.LookAt(target);
        gunPosition.localEulerAngles = new Vector3(0, gunPosition.localEulerAngles.y, 0);
    }

    public void WhatEverShipoDoing(Transform target)
    {
        for (int row = 0; row < EternalFleetSpawn.Instance.numberOfRows; row++)
        {
            for (int col = 0; col < EternalFleetSpawn.Instance.numberOfColumns; col++)
            {
                EternalFleetFire shipChan = EternalFleetSpawn.Instance.eternalFleet[row, col];

                if (shipChan)
                {
                    shipChan.RotateTurrets(target);
                    shipChan.InitFire();
                }

            }

        }
    }

    public IEnumerator Fire()
    {

       // GunFiringLoop = true;
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
        //_fire = null;

    }

    public void InitFire()
    {
        if (_fire == null)
            _fire = StartCoroutine(Fire());
        

    }

}
     
   

