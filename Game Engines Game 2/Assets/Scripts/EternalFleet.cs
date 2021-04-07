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

    [Header("Health")]
    public int maxHealth = 100;
    public int health;
    public bool explode = true;
    public Transform effect;


    public Transform cameraEnd;
    public float speed = 1f;
    public bool isFound;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
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

        if (health <= 0 && explode)
        {
            Dead();
            explode = false;
        }
    }
    public void ChangeMaterial()
    {
  
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EmpireEnemy")
        {
            TakeDamage(100);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Dead()
    {

        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject, .5f);
    }

}
