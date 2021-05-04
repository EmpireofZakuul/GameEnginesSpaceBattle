using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireFighterFiring : MonoBehaviour
{
    public Transform target;
    ObjectPool objectPooler;

    #region FIGHTERSHOOTING
    [Header("Ship Firing")]
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public GameObject projectile;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public float speed = 20;
    public bool fire = false;
    private FighterSpawn spawn;


    #endregion

    #region FIGHTER TARGETING
    public Transform Target;
    public float AttackRange = 35;
    public bool inRange;
    public float TooClose = 10;

    #endregion

    #region AUDIO
    [Header("Ship audio")]
    public AudioSource AudioSource;
    public bool audioOn = false;
    #endregion

    // Start is called before the first frame update
    public void OnEnable()
    {
        objectPooler = ObjectPool.Instance;
        AudioSource.GetComponent<AudioSource>();
        GameObject.Find("Spawn").GetComponents<FighterSpawn>();
        spawn = FindObjectOfType<FighterSpawn>();
        spawn.isFound = true;
        Target = GameObject.FindWithTag("Finish").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Target.position);
   
            if (distance <= AttackRange)
            {
                if (fire == true)
                    nextTimeToFire += Time.deltaTime;
                if (nextTimeToFire >= fireRate)//testing 
                {
                     Shoot();
                }
                else if (distance <= TooClose)
                {
                 return;
                }

            }
        

      

    }

    public void Shoot()
    {
        nextTimeToFire = 0;
        objectPooler.SpawnFromPool("BulletFighter", bulletSpawn.position, bulletSpawn.rotation);
        AudioSource.Play();
        objectPooler.SpawnFromPool("BulletFighter", bulletSpawn2.position, bulletSpawn.rotation);
    }

    public void Waypoints()
    {

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AttackRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TooClose);
    }

    private void Move()
    {
        
    }
}
