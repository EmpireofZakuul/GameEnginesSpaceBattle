using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform cameraEnd;
    public float speed = 34f;
    public float rotateSpeed = 5;
    public bool roated = false;
    public bool newSpeed = false;
    public bool position = false;
    public float time = 2f;
    public bool timeIsRunning = false;
    public bool moving = true;
    public Vector3 positionToMoveTo;
    public Vector3 targetRot;
    public Camera EternalCamera;
    public GameObject FighterCamera;
    public float fighterTime = 2f;
    public bool fighterTimeIsRunning = false;




    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


        /* if( transform.position.x <= 11718 && !newSpeed)
         {
             speed = 120f;
         }

         if(transform.position.x <= 6793 && !roated)
         {
             speed = 50;
             roated = true;
             newSpeed = true;
             transform.Rotate(15 , 90 , 0);
         }
        */

        if (transform.position != cameraEnd.position && !position)
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraEnd.position, speed * Time.deltaTime);

        }

        if (transform.position == cameraEnd.position && !roated)
        {
            position = true;
            roated = true;
            newSpeed = true;
            transform.Rotate(15, 90, 0);
            timeIsRunning = true;
        }

        if (timeIsRunning)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = 0;
                timeIsRunning = false;
            }

            if (time == 0 && moving)
            {
                moving = false;
                StartCoroutine(LerpPosition(positionToMoveTo, 4));
                StartCoroutine(LerpCamera(Quaternion.Euler(targetRot), 8));
            }
        }

        if (fighterTimeIsRunning)
        {
            if (fighterTime >= 0)
            {
                fighterTime -= Time.deltaTime;
            }
            else
            {
                fighterTime = 0;
                fighterTimeIsRunning = false;
                FighterCamera.SetActive(true);
                EternalCamera.enabled = false;
            }
        }
      
       
    }
    IEnumerator LerpPosition(Vector3 targetPos, float duration)
    {
        float moveTime = 0;
        Vector3 startPos = transform.position;

        while (moveTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, moveTime / duration);
            moveTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
    }

    IEnumerator LerpCamera(Quaternion endValue, float duration)
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
        fighterTimeIsRunning = true;
    }

   
}
