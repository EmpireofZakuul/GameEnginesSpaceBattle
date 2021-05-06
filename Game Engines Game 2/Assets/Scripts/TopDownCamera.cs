using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public CameraFollow CameraFollow;
    public bool topDown = true;
    public Vector3 cameraOffset;
    public Transform targetObject;
    public float smoothSpeed = 10f;
    [Header("Droid")]
    public Transform Droid;
    public Transform[] waypointRoutes;
    private int route;
    public float param;
    private Vector3 fighterPosition;
    public float speedModifier = 0.25f;
    public bool courtuneOn;
    public bool TrackOn = false;

    [Header("Timer")]
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    public Camera firstCamera;
    public Camera topDownCamera;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        route = 0;
        param = 0f;
        courtuneOn = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (timerIsRunning && CameraFollow.startTimer == true)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {

                timeRemaining = 0;
                //camerTopDown.SetActive(true);
                topDownCamera.enabled = false;
                firstCamera.enabled = true;
                timerIsRunning = false;

            }
        }
        if (topDown)
        {
            Vector3 desiredCameraPosition = targetObject.position + cameraOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredCameraPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;


            transform.LookAt(targetObject);
        }

        if (courtuneOn)
        {
            StartCoroutine(StartRoute(route));
            topDown = false;
            TrackOn = true;
        }
        if (TrackOn)
        {
            transform.LookAt(Droid);
        }
    }

    public IEnumerator StartRoute(int routeNumber)
    {
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
           
            //transform.LookAt(fighterPosition);
            transform.position = fighterPosition;
            yield return new WaitForEndOfFrame();
        }
    }
}
