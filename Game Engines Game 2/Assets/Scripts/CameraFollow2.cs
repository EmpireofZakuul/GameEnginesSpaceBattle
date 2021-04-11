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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, cameraEnd.position, speed * Time.deltaTime);

        if( transform.position.x <= 11718 && !newSpeed)
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
    }
}
