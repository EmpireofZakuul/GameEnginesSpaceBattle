using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /* public Transform targetObject;
     public float smoothSpeed = 10f;
     public Vector3 cameraOffset;
     public Vector3 cameraOffsetNew;
     public ShipMovement ShipMovement;


     void LateUpdate()
     {
         //transform.position = targetObject.position + cameraOffset;

          Vector3 desiredCameraPosition = targetObject.position + cameraOffset;
          Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredCameraPosition, smoothSpeed * Time.deltaTime);
         transform.position = smoothedPosition;

          transform.LookAt(targetObject);

        if(ShipMovement.shipSpeed == 0)
         {
             Vector3 newDesiredCameraPosition = targetObject.position + cameraOffsetNew;
             Vector3 newCameraPosition = Vector3.Lerp(transform.position, newDesiredCameraPosition, smoothSpeed * Time.deltaTime);
             transform.position = newCameraPosition;
         }
     }
    */

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


    public Camera firstCamera;
    public Camera secondCamera;

    private void Start()
    {
        firstCamera.enabled = true;
        secondCamera.enabled = false;
    }
    void LateUpdate()
    {
        //transform.position = targetObject.position + cameraOffset;
        if (ShipMovement.shipSpeed != 0)
        {
            Vector3 desiredCameraPosition = targetObject.position + cameraOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredCameraPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;


            transform.LookAt(targetObject);

        }

        else if (ShipMovement.shipSpeed <= 2)
        {
            Vector3 newDesiredCameraPosition = targetObject.position + cameraOffsetNew;
            Vector3 newCameraPosition = Vector3.Lerp(transform.position, newDesiredCameraPosition, smoothSpeedCameraPan * Time.deltaTime);
            transform.position = newCameraPosition;


            transform.LookAt(targetObject);


            changeTarget = true;
            Invoke("LookAtEternalFleet", changeTargetTime);
        }

/*
        if (transform.position.x >= 74 && transform.position.y >= 45 && transform.position.z >= 8365 && changeTarget)
        {
            transform.Rotate(1.279f, -101.471f, 0f);
            Invoke("LookAtEternalFleet", changeTargetTime);
        }
       //Invoke("LookAtEternalFleet", changeTargetTime);
        
        */
    }
    
    void LookAtEternalFleet()
    {
        firstCamera.enabled = false;
        secondCamera.enabled = true;
    }
}
