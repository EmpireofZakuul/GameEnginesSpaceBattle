using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireFighterFiring : MonoBehaviour
{
    //public Transform target;
    ObjectPool objectPooler;

    #region FIGHTERSHOOTING
    [Header("Ship Firing")]
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public GameObject projectile;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public float speed = 20;
    public bool fire = true;
    private FighterSpawn spawn;
    #endregion

    #region FIGHTER TARGETING
    public Transform Target;
    public float AttackRange = 35;
    public bool inRange = true;
    public float TooClose = 10;
    public float moveToTarget = 300;

    #endregion

    #region AUDIO
    [Header("Ship audio")]
    public AudioSource AudioSource;
    public bool audioOn = false;
    #endregion

    #region FIGHTERMOVING
    public float fighterSpeed = 5f;
    public float fighterTurnSpeed = 5f;
    public bool flyStraight = true;
    public float timeRemaining = 4;
    public bool timerIsRunning = false;
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
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Target.position);

        //if (flyStraight)
        //{
            //transform.position += transform.forward * fighterSpeed * Time.deltaTime;
       // }
        //else if (!flyStraight)
       // {
           // Move();
       // }
        

        if (distance <= AttackRange)
        {
                fire = true;
                if (fire == true)
                    nextTimeToFire += Time.deltaTime;

                if (nextTimeToFire >= fireRate)//testing 
                {
                     Shoot();
                }
        }

        

        if(distance >= moveToTarget)
        {
            inRange = true;
        }

        if (inRange)
        {
            Move();
        }

        if (distance <= TooClose)
        {
            fire = false;
            inRange = false;
            transform.position += transform.forward * fighterSpeed * Time.deltaTime;
        }

        


        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                flyStraight = false;
                timeRemaining = 0;
                timerIsRunning = false;
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

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AttackRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TooClose);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, moveToTarget);
    }

    private void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.position - transform.position), fighterTurnSpeed * Time.deltaTime);
        transform.position += transform.forward * fighterSpeed * Time.deltaTime;
    }
}
