using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera")]
    public Transform targetObject;
    public Transform newTargetObject;
    public float changeTargetTime = 3;
    public float smoothSpeed = 10f;
    public float smoothSpeedCameraPan = 10f;
    public Vector3 cameraOffset;
    public Vector3 cameraOffsetNew;
    public Vector3 finalCameraOffset;
    public ShipMovement ShipMovement;
    public bool changeTarget = false;
    public GameManager GameManager;
    public GameObject Camera2;

    public Camera firstCamera;
    public Camera secondCamera;
    public Camera topDownCamera;
    public Vector3 targetRotation;
    public GameObject camerTopDown;

    [Header("Timer")]
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    public bool startTimer = false;

    private void Start()
    {
        firstCamera.enabled = true;
        secondCamera.enabled = false;
        topDownCamera.enabled = false;
        timerIsRunning = true;
    }
    void LateUpdate()
    {
        if (timerIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
               
                timeRemaining = 0;
                //camerTopDown.SetActive(true);
                topDownCamera.enabled = true;
                firstCamera.enabled = false;
                timerIsRunning = false;
                startTimer = true;

            }
        }

        //transform.position = targetObject.position + cameraOffset;
        if (ShipMovement.shipSpeed != 0)
        {
            Vector3 desiredCameraPosition = targetObject.position + cameraOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredCameraPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;


            transform.LookAt(targetObject);

        }

        else if (ShipMovement.shipSpeed <= 10)
        {
            Vector3 newDesiredCameraPosition = targetObject.position + cameraOffsetNew;
            Vector3 newCameraPosition = Vector3.Lerp(transform.position, newDesiredCameraPosition, smoothSpeedCameraPan * Time.deltaTime);
            transform.position = newCameraPosition;


            transform.LookAt(targetObject);


            changeTarget = true;
            //Invoke("LookAtEternalFleet", changeTargetTime);
        }


        if (transform.position.x >= 74 && transform.position.y >= 45 && transform.position.z >= 8365 && changeTarget)
        {
            changeTarget = false;
            GameManager.startMoving = true;
            Camera2.SetActive(true);
            //transform.Rotate(1.279f, -101.471f, 6.09f);
            StartCoroutine(LerpFunction(Quaternion.Euler(targetRotation), 5));
           //Invoke("LookAtEternalFleet", changeTargetTime);
        }   
        
    }

    IEnumerator LerpFunction(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = transform.rotation;

        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endValue;
    }

    void LookAtEternalFleet()
    {
        firstCamera.enabled = false;
        secondCamera.enabled = true;
    }
}
