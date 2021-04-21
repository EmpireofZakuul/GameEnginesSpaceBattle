using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int shipCounter = 5;
    public bool last = false;
    private GameObject my;
    public Transform cameraEnd;
    public GameObject holder;
    public float speed = 600f;
    public bool arrived = true;
    public bool startMoving = false;
    public bool audioOn = false;
   // public AudioManager AudioManager;

    public void Start()
    {
        holder.SetActive(false);
        

    }
    // Update is called once per frame
    void Update()
    {
        if (shipCounter == 1 && !last)
        {
            
            Debug.Log("Runing ");
            my = GameObject.FindWithTag("EmpireEnemy");
            Debug.Log(my = null);
            Debug.Log("finding tag ");
            my.GetComponentInChildren<ShipMovement>().pathFollowingEnabled = false;
            Debug.Log("changed pathfollowing ");
            my.GetComponentInChildren<ShipMovement>().seekEnabled= true;
            Debug.Log("changed seek ");
            last = true;
        }

        if (holder.transform.position != cameraEnd.position && startMoving)
        {
            holder.transform.position = Vector3.MoveTowards(holder.transform.position, cameraEnd.position, speed * Time.deltaTime);
            
        }


        if(holder.transform.position == cameraEnd.position && arrived )
        {
            startMoving = false;
            holder.SetActive(true);
            arrived = false;
        }

       // if(shipCounter == 4 && !audioOn)
        //{
            //AudioManager.Play("DeployTheGarrision");
           // audioOn = true;
           
       // }
    }
    
           
}
