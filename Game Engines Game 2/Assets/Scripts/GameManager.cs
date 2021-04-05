using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int shipCounter = 5;
    public bool last = false;
    private GameObject my;

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
    }
    
           
}
