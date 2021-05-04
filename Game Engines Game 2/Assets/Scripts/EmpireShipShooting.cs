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

    #region EmpireShipFiring
    [Header("Ship Firing")]
    public float fireRate = 15f;
    public float GunfireRate = 4f;
    private float nextTimeToFire = 0f;
    public GameObject projectile;
    public float speed = 20;
    [Header("Ship Firing Turret 1")]
    public Transform bulletSpawn;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
    public Transform bulletSpawn4;
    public Transform bulletSpawn5;
    public Transform bulletSpawn6;
    public Transform bulletSpawn7;
    [Header("Ship Firing Turret 2")]
    public Transform bulletSpawn8;
    public Transform bulletSpawn9;
    public Transform bulletSpawn10;
    public Transform bulletSpawn11;
    public Transform bulletSpawn12;
    public Transform bulletSpawn13;
    public Transform bulletSpawn14;
    public Transform bulletSpawn15;
    [Header("Ship Firing Turret 3")]
    public Transform bulletSpawn16;
    public Transform bulletSpawn17;
    public Transform bulletSpawn18;
    public Transform bulletSpawn19;
    public Transform bulletSpawn20;
    public Transform bulletSpawn21;
    public Transform bulletSpawn22;
    public Transform bulletSpawn23;
     [Header("Ship Firing Turret 4")]
    public Transform bulletSpawn24;
    public Transform bulletSpawn25;
    public Transform bulletSpawn26;
    public Transform bulletSpawn27;
    public Transform bulletSpawn28;
    public Transform bulletSpawn29;
    public Transform bulletSpawn30;
    public Transform bulletSpawn31;
    [Header("Ship Firing Turret 5")]
    public Transform bulletSpawn32;
    public Transform bulletSpawn33;
    public Transform bulletSpawn34;
    public Transform bulletSpawn35;
    public Transform bulletSpawn36;
    public Transform bulletSpawn37;
    public Transform bulletSpawn38;
    public Transform bulletSpawn39;
    [Header("Ship Firing Turret 6")]
    public Transform bulletSpawn40;
    public Transform bulletSpawn41;
    public Transform bulletSpawn42;
    public Transform bulletSpawn43;
    public Transform bulletSpawn44;
    public Transform bulletSpawn45;
    public Transform bulletSpawn46;
    public Transform bulletSpawn47;
    [Header("Ship Firing Turret 7")]
    public Transform bulletSpawn48;
    public Transform bulletSpawn49;
    public Transform bulletSpawn50;
    public Transform bulletSpawn51;
    public Transform bulletSpawn52;
    public Transform bulletSpawn53;
    public Transform bulletSpawn54;
    public Transform bulletSpawn55;
    [Header("Ship Firing Turret 8")]
    public Transform bulletSpawn56;
    public Transform bulletSpawn57;
    public Transform bulletSpawn58;
    public Transform bulletSpawn59;
    public Transform bulletSpawn60;
    public Transform bulletSpawn61;
    public Transform bulletSpawn62;
    public Transform bulletSpawn63;

    #endregion

    // public GameObject[] empties;

   // public GameObject[,] fireSquence;  
   // public int numberOfRows;
    //public int numberOfColumns;

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
               // Debug.Log(hit.point);
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
            objectPooler.SpawnFromPool("Bullet", bulletSpawn1.position, bulletSpawn1.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn2.position, bulletSpawn2.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn3.position, bulletSpawn3.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn4.position, bulletSpawn4.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn5.position, bulletSpawn5.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn6.position, bulletSpawn6.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn7.position, bulletSpawn7.rotation);
            AudioSource.Play();

            yield return new WaitForSeconds(GunfireRate);

            GunFiringLoop = true;
            objectPooler.SpawnFromPool("Bullet", bulletSpawn8.position, bulletSpawn8.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn9.position, bulletSpawn9.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn10.position, bulletSpawn10.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn11.position, bulletSpawn11.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn12.position, bulletSpawn12.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn13.position, bulletSpawn13.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn14.position, bulletSpawn14.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn15.position, bulletSpawn15.rotation);
            AudioSource.Play();

            yield return new WaitForSeconds(GunfireRate);

            GunFiringLoop = true;
            objectPooler.SpawnFromPool("Bullet", bulletSpawn16.position, bulletSpawn16.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn17.position, bulletSpawn17.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn18.position, bulletSpawn18.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn19.position, bulletSpawn19.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn20.position, bulletSpawn20.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn21.position, bulletSpawn21.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn22.position, bulletSpawn22.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn23.position, bulletSpawn23.rotation);
            AudioSource.Play();

            yield return new WaitForSeconds(GunfireRate);
            GunFiringLoop = true;
            objectPooler.SpawnFromPool("Bullet", bulletSpawn24.position, bulletSpawn24.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn25.position, bulletSpawn25.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn26.position, bulletSpawn26.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn27.position, bulletSpawn27.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn28.position, bulletSpawn28.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn29.position, bulletSpawn29.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn30.position, bulletSpawn30.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn31.position, bulletSpawn31.rotation);
            AudioSource.Play();

            yield return new WaitForSeconds(GunfireRate);
            GunFiringLoop = true;
            objectPooler.SpawnFromPool("Bullet", bulletSpawn32.position, bulletSpawn32.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn33.position, bulletSpawn33.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn34.position, bulletSpawn34.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn35.position, bulletSpawn35.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn36.position, bulletSpawn36.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn37.position, bulletSpawn37.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn38.position, bulletSpawn38.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn39.position, bulletSpawn39.rotation);
            AudioSource.Play();

            yield return new WaitForSeconds(GunfireRate);
            GunFiringLoop = true;
            objectPooler.SpawnFromPool("Bullet", bulletSpawn40.position, bulletSpawn40.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn41.position, bulletSpawn41.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn42.position, bulletSpawn42.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn43.position, bulletSpawn43.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn44.position, bulletSpawn44.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn45.position, bulletSpawn45.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn46.position, bulletSpawn46.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn47.position, bulletSpawn47.rotation);
            AudioSource.Play();

            yield return new WaitForSeconds(GunfireRate);
            GunFiringLoop = true;
            objectPooler.SpawnFromPool("Bullet", bulletSpawn48.position, bulletSpawn48.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn49.position, bulletSpawn49.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn50.position, bulletSpawn50.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn51.position, bulletSpawn51.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn52.position, bulletSpawn52.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn53.position, bulletSpawn53.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn54.position, bulletSpawn54.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn55.position, bulletSpawn55.rotation);
            AudioSource.Play();

            yield return new WaitForSeconds(GunfireRate);
            GunFiringLoop = true;
            objectPooler.SpawnFromPool("Bullet", bulletSpawn56.position, bulletSpawn56.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn57.position, bulletSpawn57.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn58.position, bulletSpawn58.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn59.position, bulletSpawn59.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn60.position, bulletSpawn60.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn61.position, bulletSpawn61.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn62.position, bulletSpawn62.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn63.position, bulletSpawn63.rotation);
            AudioSource.Play();

            yield return new WaitForSeconds(4f);


        }

    }

   /* public void Firing()
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
   */

}

