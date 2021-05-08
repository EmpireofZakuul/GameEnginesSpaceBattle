using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFighter : MonoBehaviour
{
    //public Transform targetObject;
    public Vector3 cameraOffset;
    public float smoothSpeed = 10f;
   [SerializeField] private GameObject fighter;
    public Camera topCamera;
    public Camera fighterCamera;
    public float fighterTimeRemaining = 10;
    public bool fighterTimerIsRunning = false;
    public bool lastCameraTime = false;
    public float lastCameraTimeRemaining = 15;
    public GameObject panCamera;
    public PanCameraSwap panCameraSwap;

    // Start is called before the first frame update
    void OnEnable()
    {
        fighter = GameObject.FindGameObjectWithTag("Fighter");
       fighterTimerIsRunning = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredCameraPosition = fighter.transform.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredCameraPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;


        transform.LookAt(fighter.transform.position);


        if (fighterTimerIsRunning)
        {
            if (fighterTimeRemaining > 0)
            {
                fighterTimeRemaining -= Time.deltaTime;
            }
            else
            {
                topCamera.enabled = true;
                fighterCamera.enabled = false;
                fighterTimeRemaining = 0;
                fighterTimerIsRunning = false;
            }
        }



        if (lastCameraTime)
        {
            if (lastCameraTimeRemaining > 0)
            {
                lastCameraTimeRemaining -= Time.deltaTime;
            }
            else
            {
                fighterCamera.enabled = false;
                panCamera.SetActive(true);
                panCameraSwap.timerIsRunning = true;
                lastCameraTimeRemaining = 0;
                lastCameraTime = false;
            }
        }
    }
}
