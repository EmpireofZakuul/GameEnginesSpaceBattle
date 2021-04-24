using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int shipCounter = 5;
    public bool last = false;
    private GameObject ship;
    public Transform cameraEnd;
    public GameObject holder;
    public float speed = 600f;
    public bool arrived = true;
    public bool startMoving = false;
    public bool audioOn = false;
    public float timeRemaining = 1;
    public bool timerIsRunning = false;

    public static GameManager Instance { get; private set; }
    

    public void Start()
    {
        if( Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        timerIsRunning = true;
        holder.SetActive(false);
       
    }
    // Update is called once per frame
    void Update()
    {
        if (shipCounter == 1 && !last && timerIsRunning)
        {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    ship = GameObject.FindGameObjectWithTag("EmpireEnemy");
                   // Debug.Log(ship.name);
                    ship.GetComponent<ShipMovement>().pathFollowingEnabled = false;
                    ship.GetComponent<ShipMovement>().seekEnabled = true;
                    ship.GetComponent<EmpireShipHealth>().maxHealth = 1000;
                    last = true;
                    timeRemaining = 0;
                  
                }

        }

        if (holder.transform.position != cameraEnd.position && startMoving)
        {
            holder.transform.position = Vector3.MoveTowards(holder.transform.position, cameraEnd.position, speed * Time.deltaTime);

        }


        if (holder.transform.position == cameraEnd.position && arrived)
        {
            startMoving = false;
            holder.SetActive(true);
            arrived = false;
        }


    }
    
           
}
