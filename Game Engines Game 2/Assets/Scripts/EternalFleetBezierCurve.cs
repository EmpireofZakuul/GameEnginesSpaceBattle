using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EternalFleetBezierCurve : MonoBehaviour
{
    [Header("Bezier curve")]
    ///public Transform Droid;
    public Transform[] waypointRoutes;
    private int route;
    public float param;
    private Vector3 fighterPosition;
    public float speedModifier = 0.25f;
    public bool courtuneOn;
    public float count = 0f;
    public Camera fighterCamera;
    public Camera bezierCamera;
    public CameraFollowFighter cameraFollow;
    // Start is called before the first frame update
    void Start()
    {
      
        route = 0;
        param = 0f;
        courtuneOn = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (courtuneOn)
        {
            StartCoroutine(StartRoute(route));
        }
       
    }
    public IEnumerator StartRoute(int routeNumber)
    {
        count++;
        courtuneOn = false;
        Vector3 p0 = waypointRoutes[routeNumber].GetChild(0).position;
        Vector3 p1 = waypointRoutes[routeNumber].GetChild(1).position;
        Vector3 p2 = waypointRoutes[routeNumber].GetChild(2).position;
        Vector3 p3 = waypointRoutes[routeNumber].GetChild(3).position;

        while (param < 1)
        {
            param += Time.deltaTime * speedModifier;

            fighterPosition = Mathf.Pow(1 - param, 3) * p0 +
                3 * Mathf.Pow(1 - param, 2) * param * p1 +
                3 * (1 - param) * Mathf.Pow(param, 2) * p2 +
                Mathf.Pow(param, 3) * p3;

            transform.LookAt(fighterPosition);
            transform.position = fighterPosition;
            yield return new WaitForFixedUpdate();
        }

        param = 0f;

        route += 1;

        if (route > waypointRoutes.Length - 1)
            route = 0;
        
        
        if(count == 2)
        {
            courtuneOn = false;

            if(param == 0)
            {
                fighterCamera.enabled = true;
                bezierCamera.enabled = false;
               cameraFollow.lastCameraTime = true;
            }
        }
        else 
        {
            courtuneOn = true;
        }
                
        

       
    }
}
