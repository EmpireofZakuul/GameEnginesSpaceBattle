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
    public GameObject finalCamera;
    public Camera SecondCamera;
    public float smoothSpeed = 10f;
    public Vector3 cameraOffset;
    public AudioManager AudioManager;
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
        finalCamera.SetActive(false);

        AudioManager.Play("BackGroundMusic");
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
                    finalCamera.SetActive(true);
                    SecondCamera.enabled = false;
                    last = true;
                    timeRemaining = 0;
                    StartCoroutine(LastShip());


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



        /*if (last)
        {
            Vector3 desiredCameraPosition = ship.transform.position + cameraOffset;
            Vector3 smoothedPosition = Vector3.Lerp(ship.transform.position, desiredCameraPosition, smoothSpeed * Time.deltaTime);
            ship.transform.position = smoothedPosition;


            transform.LookAt(ship.transform);

        }
       */
        
       // if (shipCounter == 1 && last)
       // {
           
           // last = false;
      //  }

        IEnumerator LastShip()
        {
            yield return new WaitForSeconds(1f);
            AudioManager.Play("180degrees");
            yield return new WaitForSeconds(4f);
            AudioManager.Play("engines");
        }
        


    }
    
           
}
