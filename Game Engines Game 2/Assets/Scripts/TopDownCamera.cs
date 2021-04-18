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

    [Header("Timer")]
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    public Camera firstCamera;
    public Camera topDownCamera;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
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
    }
}
