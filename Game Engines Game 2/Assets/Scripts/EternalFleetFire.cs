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
                WeaponFirePosition();
                targetFound = false;
            }

        }
        if (!targetFound)
        {
            WeaponFirePosition();
        }

        if (targetFound)
        {
            nextTimeToFire += Time.deltaTime;
            if (nextTimeToFire >= fireRate)//testing 
            {
                nextTimeToFire = 0;
                Fire();
            }
        }
        
    }
    public void WeaponFirePosition()
    {

    }
    public void Fire()
    {
        objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
    }
}
