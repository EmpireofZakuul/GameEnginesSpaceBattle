using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform cameraEnd;
    public float speed = 34f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, cameraEnd.position, speed * Time.deltaTime);

        if( transform.position.x <= 11718)
        {
            speed = 80f;
        }
    }
}
