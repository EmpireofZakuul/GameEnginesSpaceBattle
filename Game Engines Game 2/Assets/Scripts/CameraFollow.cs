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
    public float smoothSpeed = 10f;
    public Vector3 cameraOffset;
    public Vector3 cameraOffsetNew;
    public ShipMovement ShipMovement;


    void LateUpdate()
    {
        //transform.position = targetObject.position + cameraOffset;
        if (ShipMovement.shipSpeed != 0)
        {
            Vector3 desiredCameraPosition = targetObject.position + cameraOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredCameraPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        else if (ShipMovement.shipSpeed == 0)
        {
            Vector3 newDesiredCameraPosition = targetObject.position + cameraOffsetNew;
            Vector3 newCameraPosition = Vector3.Lerp(transform.position, newDesiredCameraPosition, smoothSpeed * Time.deltaTime);
            transform.position = newCameraPosition;
        }
        transform.LookAt(targetObject);
    }
}
