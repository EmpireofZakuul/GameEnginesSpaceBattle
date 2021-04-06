using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EternalFleet : MonoBehaviour
{
    //[Header("Ship Movment")]
    //public Vector3 shipVelocity;
    //public float shipSpeed;
    //public Vector3 shipAcceleration;
    //public Vector3 shipForce;
    //public float maxSpeed = 10;
    //public float maxForce = 20;
    //public float shipsMass = 1;
    //public float shipSlowingDistance = 80;
    //public float damping = 0.1f;



    public Transform cameraEnd;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*shipAcceleration = shipForce / shipsMass;
        shipVelocity = shipVelocity + shipAcceleration * Time.deltaTime;
        transform.position = transform.position + shipVelocity * Time.deltaTime;
        shipSpeed = shipVelocity.magnitude;
        */

        transform.position = Vector3.MoveTowards(transform.position, cameraEnd.position, speed * Time.deltaTime);


    }
    public void ChangeMaterial()
    {
  
    }

}
