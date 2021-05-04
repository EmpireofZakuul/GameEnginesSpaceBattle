using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireShipHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int health;
    public bool explode;
    public Transform effect;
   // public GameManager game;
    public GameObject cameraHolder;
    public Transform brokenShip;
    public GameObject topDownCamera;
    public bool stop = false;
    public float timeRemaining = 1;
    public bool timerIsRunning = false;
    public AudioManager AudioManager;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        explode = true;
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.shipCounter == 1 && !stop)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                health = maxHealth;
                stop = true;
                timeRemaining = 0;
               
            }
        }
        
        if (health <= 0 && explode)
        {
            Dead();
            explode = false;
        }

        /*if ( !explode)//testing
        {
            Dead();
            explode = true;
        }
        */
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(7);     
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Dead()
    {
       
        Instantiate(effect, transform.position, transform.rotation);
        AudioManager.Play("Explode");
        //Instantiate(brokenShip, transform.position, transform.rotation);
        Destroy(cameraHolder);
        Destroy(topDownCamera);
        Destroy(gameObject);
        Instantiate(brokenShip, transform.position, transform.rotation);
        GameManager.Instance.shipCounter--;
    }
}
