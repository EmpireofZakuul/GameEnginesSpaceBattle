using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireFighterFiring : MonoBehaviour
{
    public Transform target;
    ObjectPool objectPooler;


    [Header("Ship Firing")]
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public GameObject projectile;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public float speed = 20;
    public bool fire = false;

    [Header("Ship audio")]
    public AudioSource AudioSource;
    public bool audioOn = false;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPool.Instance;
        AudioSource.GetComponent<AudioSource>();      
    }

    // Update is called once per frame
    void Update()
    {
        if(fire == true)
        nextTimeToFire += Time.deltaTime;
        if (nextTimeToFire >= fireRate)//testing 
        {
            nextTimeToFire = 0;
            objectPooler.SpawnFromPool("BulletFighter", bulletSpawn.position, bulletSpawn.rotation);
            AudioSource.Play();
            objectPooler.SpawnFromPool("BulletFighter", bulletSpawn2.position, bulletSpawn.rotation);


        }
    }
}
