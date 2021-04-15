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
    public GameManager GameManager;
    public GameObject Camera2;

    public Camera firstCamera;
    public Camera secondCamera;
    public Vector3 targetRotation;

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
            transform.Rotate(1.279f, -101.471f, 6.09f);
            //StartCoroutine(LerpFunction(Quaternion.Euler(targetRotation), 3));
            Invoke("LookAtEternalFleet", changeTargetTime);
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
